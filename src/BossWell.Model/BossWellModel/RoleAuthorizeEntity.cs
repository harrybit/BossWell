using Chloe.Entity;
using BossWellModel.Enum;
namespace BossWellModel
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
        /// 模块类型
        /// </summary>
        public RoleAuthorizeModuleEnum ModulType { get; set; }
        /// <summary>
        /// 模块类型Sid
        /// </summary>
        public string ModuleId { get; set; }
        /// <summary>
        /// 角色Id
        /// </summary>
        public string RoleId { get; set; }
        /// <summary>
        /// 角色类型
        /// </summary>
        public RoleCateEnum RoleType { get; set; }
    }
}
