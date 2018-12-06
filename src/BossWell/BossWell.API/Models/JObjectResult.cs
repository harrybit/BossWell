namespace BossWell.API
{
    /// <summary>
    /// 接口统一返回基类
    /// </summary>
    public class JObjectResult
    {
        /// <summary>
        /// 参数
        /// </summary>
        public string CMD { get; set; }
        /// <summary>
        /// 返回状态码
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 提示
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        public object Data { get; set; }
    }
}