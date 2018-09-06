using Chloe.Entity;

namespace BossWellModel
{
    /// <summary>
    /// 行政地区表
    /// </summary>
    [Table("Area")]
    public class AreaEntity : BaseEntity
    {
        /// <summary>
        /// 父级ID
        /// </summary>
        public string ParentId { get; set; }

        /// <summary>
        /// 层级
        /// </summary>
        public int Layers { get; set; }

        /// <summary>
        /// 地区代码
        /// </summary>
        public string EnCode { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// 简称
        /// </summary>
        public string SimpleSpelling { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int SortCode { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool EnabledMark { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Description { get; set; }
    }
}