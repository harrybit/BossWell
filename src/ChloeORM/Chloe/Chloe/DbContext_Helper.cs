﻿using Chloe.Core.Visitors;
using Chloe.DbExpressions;
using Chloe.Descriptors;
using Chloe.Exceptions;
using Chloe.Extensions;
using Chloe.Infrastructure;
using Chloe.InternalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Chloe
{
    public abstract partial class DbContext : IDbContext, IDisposable
    {
        private static Expression<Func<TEntity, bool>> BuildCondition<TEntity>(object key)
        {
            /*
             * key:
             * 如果实体是单一主键，可以传入的 key 与主键属性类型相同的值，亦可以传一个包含了与实体主键类型相同的属性的对象，如：new { Id = 1 }
             * 如果实体是多主键，则传入的 key 须是包含了与实体主键类型相同的属性的对象，如：new { Key1 = "1", Key2 = "2" }
             */

            Utils.CheckNull(key);

            Type entityType = typeof(TEntity);
            TypeDescriptor typeDescriptor = TypeDescriptor.GetDescriptor(entityType);
            EnsureEntityHasPrimaryKey(typeDescriptor);

            ParameterExpression parameter = Expression.Parameter(entityType, "a");
            Expression conditionBody = null;

            Type keyType = key.GetType();
            if (typeDescriptor.PrimaryKeys.Count == 1 && MappingTypeSystem.IsMappingType(keyType))
            {
                MappingMemberDescriptor keyDescriptor = typeDescriptor.PrimaryKeys[0];
                Expression propOrField = Expression.PropertyOrField(parameter, keyDescriptor.MemberInfo.Name);
                Expression wrappedValue = Chloe.Extensions.ExpressionExtension.MakeWrapperAccess(key, keyDescriptor.MemberInfoType);
                conditionBody = Expression.Equal(propOrField, wrappedValue);
            }
            else
            {
                /*
                 * key: new { Key1 = "1", Key2 = "2" }
                 */

                Type keyObjectType = keyType;

                ConstantExpression keyConstantExp = Expression.Constant(key);

                for (int i = 0; i < typeDescriptor.PrimaryKeys.Count; i++)
                {
                    MappingMemberDescriptor keyMemberDescriptor = typeDescriptor.PrimaryKeys[i];
                    MemberInfo keyMember = keyMemberDescriptor.MemberInfo;
                    MemberInfo inputKeyMember = keyObjectType.GetMember(keyMember.Name).FirstOrDefault();
                    if (inputKeyMember == null)
                        throw new ArgumentException(string.Format("The input object does not define property for key '{0}'.", keyMember.Name));

                    Expression propOrField = Expression.PropertyOrField(parameter, keyMember.Name);
                    Expression keyValueExp = Expression.MakeMemberAccess(keyConstantExp, inputKeyMember);

                    Type keyMemberType = keyMember.GetMemberType();
                    if (inputKeyMember.GetMemberType() != keyMemberType)
                    {
                        keyValueExp = Expression.Convert(keyValueExp, keyMemberType);
                    }
                    Expression e = Expression.Equal(propOrField, keyValueExp);
                    conditionBody = conditionBody == null ? e : Expression.AndAlso(conditionBody, e);
                }
            }

            Expression<Func<TEntity, bool>> condition = Expression.Lambda<Func<TEntity, bool>>(conditionBody, parameter);
            return condition;
        }

        private static void EnsureEntityHasPrimaryKey(TypeDescriptor typeDescriptor)
        {
            if (!typeDescriptor.HasPrimaryKey())
                throw new ChloeException(string.Format("The entity type '{0}' does not define any primary key.", typeDescriptor.EntityType.FullName));
        }

        private static object ConvertIdentityType(object identity, Type conversionType)
        {
            if (identity.GetType() != conversionType)
                return Convert.ChangeType(identity, conversionType);

            return identity;
        }

        private static KeyValuePairList<JoinType, Expression> ResolveJoinInfo(LambdaExpression joinInfoExp)
        {
            /*
             * Usage:
             * var view = context.JoinQuery<User, City, Province, User, City>((user, city, province, user1, city1) => new object[]
             * {
             *     JoinType.LeftJoin, user.CityId == city.Id,
             *     JoinType.RightJoin, city.ProvinceId == province.Id,
             *     JoinType.InnerJoin,user.Id==user1.Id,
             *     JoinType.FullJoin,city.Id==city1.Id
             * }).Select((user, city, province, user1, city1) => new { User = user, City = city, Province = province, User1 = user1, City1 = city1 });
             *
             * To resolve join infomation:
             * JoinType.LeftJoin, user.CityId == city.Id               index of joinType is 0
             * JoinType.RightJoin, city.ProvinceId == province.Id      index of joinType is 2
             * JoinType.InnerJoin,user.Id==user1.Id                    index of joinType is 4
             * JoinType.FullJoin,city.Id==city1.Id                     index of joinType is 6
            */

            NewArrayExpression body = joinInfoExp.Body as NewArrayExpression;

            if (body == null)
            {
                throw new ArgumentException(string.Format("Invalid join infomation '{0}'. The correct usage is like: {1}", joinInfoExp, "context.JoinQuery<User, City>((user, city) => new object[] { JoinType.LeftJoin, user.CityId == city.Id })"));
            }

            KeyValuePairList<JoinType, Expression> ret = new KeyValuePairList<JoinType, Expression>();

            if ((joinInfoExp.Parameters.Count - 1) * 2 != body.Expressions.Count)
            {
                throw new ArgumentException(string.Format("Invalid join infomation '{0}'.", joinInfoExp));
            }

            for (int i = 0; i < joinInfoExp.Parameters.Count - 1; i++)
            {
                /*
                 * 0  0
                 * 1  2
                 * 2  4
                 * 3  6
                 * ...
                 */
                int indexOfJoinType = i * 2;

                Expression joinTypeExpression = body.Expressions[indexOfJoinType];
                object inputJoinType = ExpressionEvaluator.Evaluate(joinTypeExpression);
                if (inputJoinType == null || inputJoinType.GetType() != typeof(JoinType))
                    throw new ArgumentException(string.Format("Not support '{0}', please pass correct type of 'Chloe.JoinType'.", joinTypeExpression));

                /*
                 * The next expression of join type must be join condition.
                 */
                Expression joinCondition = body.Expressions[indexOfJoinType + 1].StripConvert();

                if (joinCondition.Type != UtilConstants.TypeOfBoolean)
                {
                    throw new ArgumentException(string.Format("Not support '{0}', please pass correct join condition.", joinCondition));
                }

                ParameterExpression[] parameters = joinInfoExp.Parameters.Take(i + 2).ToArray();

                List<Type> typeArguments = parameters.Select(a => a.Type).ToList();
                typeArguments.Add(UtilConstants.TypeOfBoolean);

                Type delegateType = Utils.GetFuncDelegateType(typeArguments.ToArray());
                LambdaExpression lambdaOfJoinCondition = Expression.Lambda(delegateType, joinCondition, parameters);

                ret.Add((JoinType)inputJoinType, lambdaOfJoinCondition);
            }

            return ret;
        }

        private static Dictionary<MappingMemberDescriptor, object> CreateKeyValueMap(TypeDescriptor typeDescriptor)
        {
            Dictionary<MappingMemberDescriptor, object> keyValueMap = new Dictionary<MappingMemberDescriptor, object>();
            foreach (MappingMemberDescriptor keyMemberDescriptor in typeDescriptor.PrimaryKeys)
            {
                keyValueMap.Add(keyMemberDescriptor, null);
            }

            return keyValueMap;
        }

        private static DbExpression MakeCondition(Dictionary<MappingMemberDescriptor, object> keyValueMap, DbTable dbTable)
        {
            DbExpression conditionExp = null;
            foreach (var kv in keyValueMap)
            {
                MappingMemberDescriptor keyMemberDescriptor = kv.Key;
                object keyVal = kv.Value;

                if (keyVal == null)
                    throw new ArgumentException(string.Format("The primary key '{0}' could not be null.", keyMemberDescriptor.MemberInfo.Name));

                DbExpression left = new DbColumnAccessExpression(dbTable, keyMemberDescriptor.Column);
                DbExpression right = DbExpression.Parameter(keyVal, keyMemberDescriptor.MemberInfoType);
                DbExpression equalExp = new DbEqualExpression(left, right);
                conditionExp = conditionExp == null ? equalExp : DbExpression.And(conditionExp, equalExp);
            }

            return conditionExp;
        }
    }
}