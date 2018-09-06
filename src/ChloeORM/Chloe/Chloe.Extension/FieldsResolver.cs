﻿using Chloe.Descriptors;
using Chloe.Extensions;
using Chloe.InternalExtensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;

namespace Chloe.Extension
{
    internal class FieldsResolver
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="fieldsLambdaExpression">a => new { a.Name, a.Age } or a => new object[] { a.Name, a.Age }</param>
        /// <returns></returns>
        public static List<string> Resolve(LambdaExpression fieldsLambdaExpression)
        {
            ParameterExpression parameterExpression = fieldsLambdaExpression.Parameters[0];

            var body = ExpressionExtension.StripConvert(fieldsLambdaExpression.Body);

            ReadOnlyCollection<Expression> fieldExps = null;

            NewExpression newExpression = body as NewExpression;
            if (newExpression != null && newExpression.Type.IsAnonymousType())
            {
                fieldExps = newExpression.Arguments;
            }
            else
            {
                NewArrayExpression newArrayExpression = body as NewArrayExpression;
                if (newArrayExpression == null)
                    throw new NotSupportedException(fieldsLambdaExpression.ToString());

                fieldExps = newArrayExpression.Expressions;
            }

            Type entityType = parameterExpression.Type;
            TypeDescriptor typeDescriptor = TypeDescriptor.GetDescriptor(entityType);

            List<string> fields = new List<string>(fieldExps.Count);

            foreach (var item in fieldExps)
            {
                MemberExpression memberExp = ExpressionExtension.StripConvert(item) as MemberExpression;
                if (memberExp == null)
                    throw new NotSupportedException(item.ToString());

                if (memberExp.Expression != parameterExpression)
                    throw new NotSupportedException(item.ToString());

                fields.Add(memberExp.Member.Name);
            }

            return fields;
        }
    }
}