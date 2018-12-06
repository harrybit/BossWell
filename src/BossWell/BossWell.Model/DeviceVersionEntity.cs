using Chloe.Annotations;
namespace BossWell.Model
{
    /// <summary>
    /// 设备版本
    /// </summary>
    [Table("DeviceVersion")]
    public class DeviceVersionEntity : BaseEntity
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 版本号
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsEnable { get; set; }
        /// <summary>
        /// 文件地址
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}