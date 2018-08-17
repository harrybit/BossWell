using System;
using System.Text.RegularExpressions;

namespace ApiHelp
{
    /// <summary>
    /// 正则帮助类
    /// </summary>
    public class RegularHelp
    {
        static string reg = string.Empty;

        /// <summary>
        /// 检测手机号码是否正确
        /// </summary>
        /// <param name="mobile">手机号</param>
        /// <returns></returns>
        public static bool CheckMobile(string mobile)
        {
            reg = @"^(13[0-9]|14[579]|15[0-3,5-9]|16[6]|17[0135678]|18[0-9]|19[89])\d{8}$";

            return Regex.IsMatch(mobile, reg);
        }

        /// <summary>
        /// 检测身份证号码是否正确
        /// </summary>
        /// <param name="idCard">身份证号</param>
        /// <returns></returns>
        public static bool CheckIDCard(string idCard)
        {
            reg = @"^\d{15}|\d{18}$";
            string charReg = @"^\d{8,18}|[0-9x]{8,18}|[0-9X]{8,18}?$";

            //不符合短身份证、正常身份证判定为无效
            if (!Regex.IsMatch(idCard, reg) && !Regex.IsMatch(idCard, charReg))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 检测邮箱是否正确
        /// </summary>
        /// <param name="email">邮箱号码</param>
        /// <returns></returns>
        public static bool CheckEmail(string email)
        {
            reg = @"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

            return Regex.IsMatch(email, reg);
        }

        /// <summary>
        /// 检测邮编是否正确
        /// </summary>
        /// <param name="zCode">邮编号码</param>
        /// <returns></returns>
        public static bool CheckZCode(string zCode)
        {
            reg = @"[1-9]\d{5}(?!\d)";
            return Regex.IsMatch(zCode, reg);
        }

        /// <summary>
        /// 检测IP地址是否正确
        /// </summary>
        /// <param name="ip">IP</param>
        /// <returns></returns>
        public static bool CheckIp(string ip)
        {
            reg = @"\d+\.\d+\.\d+\.\d+";

            return Regex.IsMatch(ip, reg);
        }

    }
}
