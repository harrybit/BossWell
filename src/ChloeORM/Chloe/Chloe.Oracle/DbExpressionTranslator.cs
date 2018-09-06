using Chloe.DbExpressions;
using Chloe.Infrastructure;
using System.Collections.Generic;

namespace Chloe.Oracle
{
    internal class DbExpressionTranslator : IDbExpressionTranslator
    {
        public static readonly DbExpressionTranslator Instance = new DbExpressionTranslator();

        public string Translate(DbExpression expression, out List<DbParam> parameters)
        {
            SqlGenerator generator = SqlGenerator.CreateInstance();
            expression.Accept(generator);

            parameters = generator.Parameters;
            string sql = generator.SqlBuilder.ToSql();

            return sql;
        }
    }

    internal class DbExpressionTranslator_ConvertToUppercase : IDbExpressionTranslator
    {
        public static readonly DbExpressionTranslator_ConvertToUppercase Instance = new DbExpressionTranslator_ConvertToUppercase();

        public string Translate(DbExpression expression, out List<DbParam> parameters)
        {
            SqlGenerator_ConvertToUppercase generator = new SqlGenerator_ConvertToUppercase();
            expression.Accept(generator);

            parameters = generator.Parameters;
            string sql = generator.SqlBuilder.ToSql();

            return sql;
        }
    }
}