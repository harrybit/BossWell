using Chloe.Entity;
using BossWellModel.Enum;
namespace BossWellModel
{
    /// <summary>
    /// 菜单按钮表
    /// </summary>
    [Table("ModuleButton")]
    public class ModuleButtonEntity : BaseEntity
    {
        /// <summary>
        /// 按钮名称
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// 菜单Sid
        /// </summary>
        public string ModuleSid { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 按钮代码
        /// </summary>
        public string EnCode { get; set; }
        /// <summary>
        /// 按钮位置
        /// </summary>
        public ModuleButtonLocationEnum Location { get; set; }
        /// <summary>
        /// JS事件
        /// </summary>
        public string JsEvent { get; set; }
        /// <summary>
        /// 链接
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// 分割线
        /// </summary>
        public bool Isplit { get; set; }
        /// <summary>
        /// 是否为公共
        /// </summary>
        public bool IsPublic { get; set; }
        /// <summary>
        /// 允许编辑
        /// </summary>
        public bool AllowEdit { get; set; }
        /// <summary>
        /// 允许删除
        /// </summary>
        public bool AllowDelete { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool EnabledMark { get; set; }
        /// <summary>
        /// 简介
        /// </summary>
        public string Description { get; set; }
       
    }
}
