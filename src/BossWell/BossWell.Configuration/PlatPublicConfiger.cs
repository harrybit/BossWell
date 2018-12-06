namespace BossWell.Configuration
{
    /// <summary>
    /// 平台公共配置
    /// </summary>
    public class PlatPublicConfiger
    {
        /// <summary>
        /// 平台名称
        /// </summary>
        public static string PlatName { get { return "孢子物语"; } }

        /// <summary>
        /// 后台登录信息Cookie
        /// </summary>
        public static string PlatAdminCookieName { get { return "bosswell_loginpermit"; } }
        
    }
}