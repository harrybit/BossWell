using BossWell.ApiHelp;
using BossWell.Configuration;
namespace BossWell.Application
{
    public class OperatorProvider
    {
        public static OperatorProvider Provider
        {
            get { return new OperatorProvider(); }
        }

        /// <summary>
        /// 读取缓存管理员登录信息
        /// </summary>
        /// <returns></returns>
        public OperatorModel GetCurrent()
        {
            //读取Cookie
            OperatorModel operatorModel = new OperatorModel();
            string decCodeJson = ApiHelper.InverseDecode(ApiHelper.GetCookie(PlatPublicConfiger.PlatAdminCookieName));
            if (string.IsNullOrEmpty(decCodeJson))
            {
                return operatorModel;
            }
            operatorModel = ApiHelper.JsonDeserial<OperatorModel>(decCodeJson);
            return operatorModel;
        }

        /// <summary>
        /// 登录成功写入缓存
        /// </summary>
        /// <param name="operatorModel"></param>
        public void AddCurrent(OperatorModel operatorModel)
        {
            //写入Cookie
            ApiHelper.WriteCookie(PlatPublicConfiger.PlatAdminCookieName, ApiHelper.InverseEncode(ApiHelper.JsonSerial(operatorModel)), 1440);
        }

        /// <summary>
        /// 移除管理员信息
        /// </summary>
        public void RemoveCurrent()
        {
            ApiHelper.RemoveCookie(PlatPublicConfiger.PlatAdminCookieName);
        }
    }
}