namespace BossWell.Model.Other
{
    /// <summary>
    /// 模型树
    /// </summary>
    public class ComClassTreeModel
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 副标题
        /// </summary>
        public string Subtitle { get; set; }

        /// <summary>
        /// 背景图
        /// </summary>
        public string BGImages { get; set; }

        /// <summary>
        /// Logo
        /// </summary>
        public string Logo { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 子级
        /// </summary>
        public object Child { get; set; }

    }
}
