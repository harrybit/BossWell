using BossWell.Service;
using BossWell.Interface;
namespace BossWell.Domain
{
    /// <summary>
    /// 系统权限
    /// </summary>
    public class SysAuthFactory
    {
        /// <summary>
        /// 系统管理员
        /// </summary>
        /// <returns></returns>
        public static IAdminUserService GetAdminUserService()
        {
            return new AdminUserService();
        }

        /// <summary>
        /// 后台菜单
        /// </summary>
        /// <returns></returns>
        public static IModuleService GetModuleService()
        {
            return new ModuleService();
        }

        /// <summary>
        /// 系统日志
        /// </summary>
        /// <returns></returns>
        public static ILogService GetLogService()
        {
            return new LogService();
        }

        /// <summary>
        /// 角色权限
        /// </summary>
        /// <returns></returns>
        public static IRoleAuthorizeService GetRoleAuthorService()
        {
            return new RoleAuthorizeService();
        }

        /// <summary>
        /// 系统角色
        /// </summary>
        /// <returns></returns>
        public static IRoleService GetRoleService()
        {
            return new RoleService();
        }

    }
}
