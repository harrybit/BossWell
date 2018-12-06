using Chloe.Annotations;
namespace BossWell.Model
{
    /// <summary>
    /// 资讯表
    /// </summary>
    [Table("News")]
    public class NewsEntity : BaseEntity
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 副标题
        /// </summary>
        public string SubTitle { get; set; }
        /// <summary>
        /// 标签
        /// </summary>
        public string Tag { get; set; }
        /// <summary>
        /// 列表图
        /// </summary>
        public string CoverImg { get; set; }
        /// <summary>
        /// 分类名称
        /// </summary>
        public string ComClass { get; set; }
        /// <summary>
        /// 分类Sid
        /// </summary>
        public string ComClassSid { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsEnable { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// 简介
        /// </summary>
        public string Desc { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
    }
}