
using Chloe.Annotations;
namespace BossWell.Model
{
    /// <summary>
    /// 组织架构表
    /// </summary>
    [Table("Organize")]
    public class OrganizeEntity : BaseEntity
    {
        /// <summary>
        /// 组织名称
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// 父级Sid
        /// </summary>
        public string ParentId { get; set; }

        /// <summary>
        /// 负责人
        /// </summary>
        public string Lead { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string TelPhone { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsEnable { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}