using System;
using Chloe.Entity;
namespace BossWellModel
{
    /// <summary>
    /// 会员基本信息表
    /// </summary>
    [Table("Client")]
    public class ClientEntity : BaseEntity
    {
        /// <summary>
        /// 账号
        /// </summary>
        public string AccountNo { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public string HeadPortrait { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public int Gender { get; set; }

        /// <summary>
        /// 登录密码
        /// </summary>
        public string PassWord { get; set; }

        /// <summary>
        /// 登录令牌
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// 设备号
        /// </summary>
        public string DeviceNo { get; set; }

        /// <summary>
        /// 推荐码
        /// </summary>
        public string SpreadCode { get; set; }

        /// <summary>
        /// 经度
        /// </summary>
        public string Lat { get; set; }

        /// <summary>
        /// 纬度
        /// </summary>
        public string Lng { get; set; }

        /// <summary>
        /// 积分
        /// </summary>
        public decimal Integral { get; set; }

        /// <summary>
        /// 余额
        /// </summary>
        public decimal Balance { get; set; }

        /// <summary>
        /// 角色
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// 角色ID
        /// </summary>
        public string RoleID { get; set; }

        /// <summary>
        /// 身份证
        /// </summary>
        public string IdCard { get; set; }

        /// <summary>
        /// 微信号
        /// </summary>
        public string WechatNo { get; set; }

        /// <summary>
        /// QQ号
        /// </summary>
        public string QQNumber { get; set; }

        /// <summary>
        /// 省份
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 区域
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// 详细地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
