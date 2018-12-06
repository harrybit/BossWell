using Chloe.Annotations;
namespace BossWell.Model
{
    /// <summary>
    /// 轮播图表
    /// </summary>
    [Table("Banner")]
    public class BannerEntity : BaseEntity
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 分类名称
        /// </summary>
        public string ComClass { get; set; }

        /// <summary>
        /// 分类SID
        /// </summary>
        public string ComClassSid { get; set; }

        /// <summary>
        /// 图片路径
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsEnable { get; set; }

        /// <summary>
        /// 链接地址
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}