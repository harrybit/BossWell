using BossWellService;
using IBossWellService;
using BossWellORM;
namespace BossWellFactory
{
    /// <summary>
    /// 系统权限工厂
    /// </summary>
    public class SysAutoFactory
    {
        public static IAreaService GetAreaService()
        {
            return new AreaService();
        }
        public static IAdminUserService GetAdminUserService()
        {
            return new AdminUserService();
        }
        public static ILogService GetLogService()
        {
            return new LogService();
        }
        public static IModuleButtonService GetModuleButtonService()
        {
            return new ModuleButtonService();
        }
        public static IModuleService GetModuleService()
        {
            return new ModuleService();
        }
        public static IOrganizeService GetOrganizeService()
        {
            return new OrganizeService();
        }
        public static IRoleAuthorizeService GetRoleAuthorizeService()
        {
            return new RoleAuthorizeService();
        }
        public static IRoleService GetRoleService()
        {
            return new RoleService();
        }
        public static IComClassService GetComClassService()
        {
            return new ComClassService();
        }

        public static ISystemConfigService GetSysConfig()
        {
            return new SystemConfigService();
        }
    }
}
