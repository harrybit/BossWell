﻿using Chloe.DbExpressions;
using Chloe.Query.QueryExpressions;
using System;

namespace Chloe.Query.QueryState
{
    internal sealed class LimitQueryState : SubQueryState
    {
        private int _skipCount;
        private int _takeCount;

        public LimitQueryState(ResultElement resultElement, int skipCount, int takeCount)
            : base(resultElement)
        {
            this.SkipCount = skipCount;
            this.TakeCount = takeCount;
        }

        public int SkipCount
        {
            get
            {
                return this._skipCount;
            }
            set
            {
                this.CheckInputCount(value, "skip");
                this._skipCount = value;
            }
        }

        public int TakeCount
        {
            get
            {
                return this._takeCount;
            }
            set
            {
                this.CheckInputCount(value, "take");
                this._takeCount = value;
            }
        }

        private void CheckInputCount(int count, string name)
        {
            if (count < 0)
            {
                throw new ArgumentException(string.Format("The {0} count could not less than 0.", name));
            }
        }

        public override IQueryState Accept(TakeExpression exp)
        {
            if (exp.Count < this.TakeCount)
                this.TakeCount = exp.Count;

            return this;
        }

        public override IQueryState CreateQueryState(ResultElement result)
        {
            return new LimitQueryState(result, this.SkipCount, this.TakeCount);
        }

        public override DbSqlQueryExpression CreateSqlQuery()
        {
            DbSqlQueryExpression sqlQuery = base.CreateSqlQuery();

            sqlQuery.TakeCount = this.TakeCount;
            sqlQuery.SkipCount = this.SkipCount;

            return sqlQuery;
        }
    }
}