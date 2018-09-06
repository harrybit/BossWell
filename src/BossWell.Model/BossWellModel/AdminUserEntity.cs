using Chloe.Entity;
using System;

namespace BossWellModel
{
    /// <summary>
    /// 系统管理员表
    /// </summary>
    [Table("AdminUser")]
    public class AdminUserEntity : BaseEntity
    {
        /// <summary>
        /// 账号
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string PassWord { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public string HeadIcon { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public int Gender { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string TelPhone { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 组织结构名称
        /// </summary>
        public string OrganizeName { get; set; }

        /// <summary>
        /// 组织结构Id
        /// </summary>
        public string OrganizeSid { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// 角色Id
        /// </summary>
        public string RoleSid { get; set; }

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