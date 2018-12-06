using BossWell.Model.Enum;
using Chloe.Annotations;
namespace BossWell.Model
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
        /// Icon
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 菜单类型
        /// </summary>
        public ModuleEnum Type { get; set; }

        /// <summary>
        /// 父级ID
        /// </summary>
        public string ParentId { get; set; }

        /// <summary>
        /// 菜单路径
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// 是否有效
        /// </summary>
        public bool IsEnable { get; set; }

        /// <summary>
        /// 位置
        /// </summary>
        public ModuleBtnEnum Location { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        public string Encode { get; set; }

        /// <summary>
        /// 事件
        /// </summary>
        public string JsEvent { get; set; }

        /// <summary>
        /// 简介
        /// </summary>
        public string Remark { get; set; }
    }
}