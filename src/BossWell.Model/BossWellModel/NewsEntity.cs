using Chloe.Entity;

namespace BossWellModel
{
    /// <summary>
    /// 资讯表
    /// </summary>
    [Table("News")]
    public class NewsEntity : BaseEntity
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Tag { get; set; }
        public string CoverImg { get; set; }
        public string ComClass { get; set; }
        public string ComClassSid { get; set; }
        public bool IsEnable { get; set; }
        public string Author { get; set; }
        public string Desc { get; set; }
        public string Content { get; set; }
    }
}