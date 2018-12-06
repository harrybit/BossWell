using System.Collections.Generic;

namespace BossWell.Model
{
    /// <summary>
    /// 分页列表返回模型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class QueryResponse<T>
    {
        /// <summary>
        /// 总记录
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// 数据集合
        /// </summary>
        public IList<T> Items { get; set; }
    }
}