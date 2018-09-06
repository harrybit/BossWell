using Chloe.Entity;

namespace BossWellModel
{
    /// <summary>
    /// 设备版本
    /// </summary>
    [Table("DeviceVersion")]
    public class DeviceVersionEntity : BaseEntity
    {
        public string Title { get; set; }
        public string Version { get; set; }
        public bool IsEnable { get; set; }
        public string Path { get; set; }
        public string Remark { get; set; }
    }
}