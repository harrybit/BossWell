using Chloe.Entity;
namespace BossWellModel
{
    /// <summary>
    /// 后台菜单表
    /// </summary>
    [Table("Module")]
    public class ModuleEntity : BaseEntity
    {
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        public string EnCode { get; set; }

        /// <summary>
        /// Icon
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 父级ID
        /// </summary>
        public string ParentId { get; set; }
        /// <summary>
        /// 菜单层级
        /// </summary>
        public int Layers { get; set; }
        /// <summary>
        /// 菜单路径
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// Open目标
        /// </summary>
        public string Target { get; set; }
        /// <summary>
        /// 是否为菜单
        /// </summary>
        public bool IsMenu { get; set; }
        /// <summary>
        /// 是否为公共
        /// </summary>
        public bool IsPublic { get; set; }
        /// <summary>
        /// 是否展开
        /// </summary>
        public bool IsExpand { get; set; }
        /// <summary>
        /// 是否有效
        /// </summary>
        public bool EnabledMark { get; set; }
        /// <summary>
        /// 允许编辑
        /// </summary>
        public bool AllowEdit { get; set; }
        /// <summary>
        /// 允许删除
        /// </summary>
        public bool AllowDelete { get; set; }
        /// <summary>
        /// 简介
        /// </summary>
        public string Description { get; set; }
    }
}
