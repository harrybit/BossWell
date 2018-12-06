using BossWell.Model.Enum;
using System;

namespace BossWell.Model.Admin
{
    /// <summary>
    /// 角色权限树模型
    /// </summary>
    public class RoleAuthorTreeModel
    {
        /// <summary>
        /// 权限Sid
        /// </summary>
        public string Sid { get; set; }
        /// <summary>
        /// 模块名称
        /// </summary>
        public string ModuleName { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }
        /// <summary>
        /// 模块类型
        /// </summary>
        public ModuleEnum ModuleType { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
