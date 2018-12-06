using System;
using System.Linq.Expressions;

namespace BossWell.Model
{
    /// <summary>
    /// 分页列表查询模型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class QueryRequest<T>
    {
        /// <summary>
        /// 页码
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// 每页条目
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 筛选条件
        /// </summary>
        public Expression<Func<T, bool>> Expression { get; set; }

        /// <summary>
        /// 排序字段(a asc,b desc)
        /// </summary>
        public string Sort { get; set; }
    }
}