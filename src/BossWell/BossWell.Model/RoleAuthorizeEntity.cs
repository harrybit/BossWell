using Chloe.Annotations;
namespace BossWell.Model
{
    /// <summary>
    /// 角色权限分配表
    /// </summary>
    [Table("RoleAuthorize")]
    public class RoleAuthorizeEntity : BaseEntity
    {
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 模块类型SId
        /// </summary>
        public string ModuleId { get; set; }

        /// <summary>
        /// 角色SId
        /// </summary>
        public string RoleId { get; set; }

    }
}