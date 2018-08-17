namespace SystemConfig
{
    /// <summary>
    /// 平台全局配置
    /// </summary>
    public class PlatPublicConfig
    {
        /// <summary>
        /// 平台名称
        /// </summary>
        public static string AppName { get { return "孢子物语"; } }
        /// <summary>
        /// 管理员账号
        /// </summary>
        public static string AdminName { get { return "admin"; } }

        /// <summary>
        /// 是否开启短信验证码
        /// </summary>
        public static bool IsOpenSMS { get { return false; } }
    }
}
