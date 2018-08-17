using Chloe.Entity;
using System;
namespace BossWellModel
{
    /// <summary>
    /// 模型基类
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// 逻辑主键
        /// </summary>
        [Column(IsPrimaryKey = true)]
        public string Sid { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }
        
    }
}
