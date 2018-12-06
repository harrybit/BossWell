namespace BossWell.Cache
{
    public class CacheId
    {
        /// <summary>
        /// 系统配置 0号库
        /// </summary>
        public static int SystemConfig { get { return 0; } }

        /// <summary>
        /// 用户权限 1号库
        /// </summary>
        public static int RoleAuthorize { get { return 1; } }

        /// <summary>
        /// 验证码 2号库
        /// </summary>
        public static int SMSVCode { get { return 2; } }

        /// <summary>
        /// 文件上传许可证 3号库
        /// </summary>
        public static int AFU_FileLicense { get { return 3; } }

        /// <summary>
        /// Hangfire 14号库
        /// </summary>
        public static int Hangfire { get { return 14; } }


    }
}
