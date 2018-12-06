namespace BossWell.Model.Other
{
    /// <summary>
    /// 七牛云返回模型
    /// </summary>
    public class QiNiuResult
    {
        public string hash { get; set; }

        public string key { get; set; }
    }

    /// <summary>
    /// 七牛云上传文件返回模型
    /// </summary>
    public class QiNiuResultModel
    {
        /// <summary>
        /// 状态 200-成功
        /// </summary>
        public int resultCode { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string resultMsg { get; set; }

        /// <summary>
        /// 文件字节大小 Byte
        /// </summary>
        public int byteSize { get; set; }

        /// <summary>
        /// 文件后缀名
        /// </summary>
        public string fileFix { get; set; }

        /// <summary>
        /// 文件地址
        /// </summary>
        public string path { get; set; }

    }

}
