using System.Collections.Generic;
namespace BossWellModel.Base
{
    /// <summary>
    /// 返回分页列表
    /// </summary>
    public class QueryResponse<T>
    {
        public int TotalCount { get; set; }
        public List<T> Items { get; set; }
    }
}
