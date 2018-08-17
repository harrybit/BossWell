using Chloe.Entity;
using BossWellModel.Enum;
namespace BossWellModel
{
    /// <summary>
    /// 系统日志表
    /// </summary>
    [Table("Log")]
    public class LogEntity : BaseEntity
    {
        /// <summary>
        /// 日志类型
        /// </summary>
        public LogTypeEnum LogType { get; set; }
        /// <summary>
        /// IP
        /// </summary>
        public string IP { get; set; }
        /// <summary>
        /// 来源
        /// </summary>
        public string Source { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 内容简介
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 详细内容
        /// </summary>
        public string Result { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateUser { get; set; }
    }
}
