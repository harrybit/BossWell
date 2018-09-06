using System;
using System.Linq.Expressions;

namespace BossWellModel.Base
{
    /// <summary>
    /// 查询分页列表
    /// </summary>
    public class QueryRequest<T>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public Expression<Func<T, bool>> expression { get; set; }
        public Expression<Func<T, object>> Sort { get; set; }
        public string SortTp { get; set; }
    }
}