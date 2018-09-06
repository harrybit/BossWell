﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Chloe.Query.QueryExpressions
{
    internal class JoinQueryExpression : QueryExpression
    {
        private List<JoiningQueryInfo> _joinedQueries;
        private LambdaExpression _selector;

        public JoinQueryExpression(Type elementType, QueryExpression prevExpression, List<JoiningQueryInfo> joinedQueries, LambdaExpression selector)
            : base(QueryExpressionType.JoinQuery, elementType, prevExpression)
        {
            this._joinedQueries = new List<JoiningQueryInfo>(joinedQueries.Count);
            this._joinedQueries.AddRange(joinedQueries);
            this._selector = selector;
        }

        public List<JoiningQueryInfo> JoinedQueries { get { return this._joinedQueries; } }
        public LambdaExpression Selector { get { return this._selector; } }

        public override T Accept<T>(QueryExpressionVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}