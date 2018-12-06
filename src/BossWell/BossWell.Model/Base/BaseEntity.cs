using Chloe.Annotations;
using System;

namespace BossWell.Model
{
    /// <summary>
    /// 模型基类
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// 逻辑主键
        /// </summary>
        [ColumnAttribute(IsPrimaryKey = true, Name = "Sid")]
        public string Sid { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? EditDate { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDelete { get; set; }
    }
}