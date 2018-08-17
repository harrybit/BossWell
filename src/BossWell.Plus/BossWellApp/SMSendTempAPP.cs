using BossWellApp.SMSend;
namespace BossWellApp
{
    /// <summary>
    /// 短信模板发送
    /// </summary>
    public class SMSendTempAPP
    {
        readonly static ISMS_AliSend _service = SMS_Factory.SMS_AliTempSend();

        /// <summary>
        /// 短信验证码
        /// </summary>
        public static bool SendVerCode(string mobile, string code)
        {
            string tempCode = "SMS_133266418";
            string tempJson = "{\"code\":\"" + code + "\"}";
            return _service.SMSTempSend(mobile, tempCode, tempJson);
        }

    }
}
