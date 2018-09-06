namespace BossWellModel.BossWellModel
{
    /// <summary>
    /// 注册信息体
    /// </summary>
    public class RegisterModel
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
        /// 验证码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 推荐码-可选
        /// </summary>
        public string ReCode { get; set; }
    }
}