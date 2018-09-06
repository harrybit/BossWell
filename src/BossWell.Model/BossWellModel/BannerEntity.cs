using Chloe.Entity;

namespace BossWellModel
{
    /// <summary>
    /// 轮播图表
    /// </summary>
    [Table("Banner")]
    public class BannerEntity : BaseEntity
    {
        public string Title { get; set; }
        public int Sort { get; set; }
        public string ComClass { get; set; }
        public string ComClassSid { get; set; }
        public string Path { get; set; }
        public bool IsEnable { get; set; }
        public string Link { get; set; }
        public string Remark { get; set; }
    }
}