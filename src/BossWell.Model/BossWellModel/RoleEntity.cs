using Chloe.Entity;
using BossWellModel.Enum;
namespace BossWellModel
{
    /// <summary>
    /// 角色表
    /// </summary>
    [Table("Role")]
    public class RoleEntity : BaseEntity
    {
        /// <summary>
          /// 角色名称
          /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// 角色编号
        /// </summary>
        public string EnCode { get; set; }

        /// <summary>
        /// 组织机构
        /// </summary>
        public string OrganizeName { get; set; }

        /// <summary>
        /// 组织机构Sid
        /// </summary>
        public string OrganizeId { get; set; }

        /// <summary>
        /// 角色类型
        /// </summary>
        public RoleCateEnum Category { get; set; }
        /// <summary>
        /// 允许编辑
        /// </summary>
        public bool AllowEdit { get; set; }
        /// <summary>
        /// 允许删除
        /// </summary>
        public bool AllowDelete { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsEnable { get; set; }
        /// <summary>
        /// 简介
        /// </summary>
        public string Description { get; set; }
    }
}
