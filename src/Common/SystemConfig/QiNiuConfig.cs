namespace SystemConfig
{
    public class QiNiuConfig
    {
        /// <summary>
        /// AccessKey
        /// </summary>
        public static string AccessKey { get { return "9x4dvx5lZyz5U6iEbe93HoNZoBKaDJl3htdonLni"; } }

        /// <summary>
        /// SecretKey
        /// </summary>
        public static string SecretKey { get { return "GRHbwa24cxkguPSV8cc6eLUHaSIUGLGurvvuTxSL"; } }

        /// <summary>
        /// Bucket 对象存储空间名称
        /// </summary>
        public static string Bucket { get { return "bosswell"; } }

        /// <summary>
        /// 图片外部访问域名
        /// </summary>
        public static string Domain { get { return "http://p8pmfndis.bkt.clouddn.com/"; } }

        /// <summary>
        /// 图片最大定义MB
        /// </summary>
        public static int MaxImageSize { get { return 255; } }

        /// <summary>
        /// 文件最大定义MB
        /// </summary>
        public static int MaxFileSize { get { return 1024; } }
    }
}
