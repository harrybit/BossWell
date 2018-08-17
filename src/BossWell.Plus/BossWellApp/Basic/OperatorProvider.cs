using ApiHelp;
using System;

namespace BossWellApp.Basic
{
    public class OperatorProvider
    {
        public static OperatorProvider Provider
        {
            get { return new OperatorProvider(); }
        }
        private string LoginUserKey = "bosswell_adminLogininfo";
        private string LoginProvider = "Cookie";

        public OperatorModel GetCurrent()
        {
            OperatorModel operatorModel = new OperatorModel();
            if (LoginProvider == "Cookie")
            {
                string decryptCookie = DESEncrypt.Decrypt(ApiHelper.GetCookie(LoginUserKey));
                if (string.IsNullOrEmpty(decryptCookie))
                {
                    return operatorModel;
                }
                operatorModel = ApiHelper.JsonDeserial<OperatorModel>(decryptCookie);
            }
            else
            {
                operatorModel = ApiHelper.JsonDeserial<OperatorModel>(DESEncrypt.Decrypt(ApiHelper.GetSession(LoginUserKey).ToString()));
            }
            return operatorModel;
        }
        public void AddCurrent(OperatorModel operatorModel)
        {
            if (LoginProvider == "Cookie")
            {
                ApiHelper.WriteCookie(LoginUserKey, DESEncrypt.Encrypt(ApiHelper.JsonSerial(operatorModel)), 60);
            }
            else
            {
                ApiHelper.WriteSession(LoginUserKey, DESEncrypt.Encrypt(ApiHelper.JsonSerial(operatorModel)));
            }
            ApiHelper.WriteCookie("bosswell_mac", ApiHelper.MD5Encrypt(ApiHelper.JsonSerial(ApiHelper.GetMacByNetworkInterface()), "MD5"));
            ApiHelper.WriteCookie("bosswell_licence", ApiHelper.MD5Encrypt(Guid.NewGuid().ToString(), "MD5"));
        }
        public void RemoveCurrent()
        {
            if (LoginProvider == "Cookie")
            {
                ApiHelper.RemoveCookie(LoginUserKey.Trim());
            }
            else
            {
                ApiHelper.RemoveSession(LoginUserKey.Trim());
            }
        }
    }
}
