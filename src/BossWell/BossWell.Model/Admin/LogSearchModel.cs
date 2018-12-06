namespace BossWell.Model.Admin
{
    /// <summary>
    /// 日志搜索条件
    /// </summary>
    public class LogSearchModel
    {
        /// <summary>
        /// 模糊搜索
        /// </summary>
        public string keyWord { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public int timeType { get; set; }
    }
}
