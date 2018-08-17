namespace Cache.Base
{
    /// <summary>
    /// 缓存库分配
    /// </summary>
    public static class CacheId
    {
        #region 0号库
        /// <summary>
        /// 系统配置
        /// </summary>
        public static int SystemConfig { get { return 0; } }

        /// <summary>
        /// 后台验证码
        /// </summary>
        public static int BossWell_Verifycode { get { return 0; } }
        #endregion

        #region 1号库

        /// <summary>
        /// 用户权限
        /// </summary>
        public static int RoleAuthorize { get { return 1; } }

        #endregion

        #region 2号库
        /// <summary>
        /// 文件上传许可证
        /// </summary>
        public static int AFU_FileLicense { get { return 2; } }

        #endregion

        #region 3号库

        /// <summary>
        /// 短信验证码
        /// </summary>
        public static int SMSTempCode { get { return 3; } }

        #endregion

        #region 14号库-不限时

        /// <summary>
        /// 后台线程池环境，不限时
        /// </summary>
        public static int Hangfire { get { return 14; } }
        #endregion

        #region 15号库

        public static int ListId { get { return 15; } }

        #endregion


    }
}
