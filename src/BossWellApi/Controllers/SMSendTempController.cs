using System.Web.Http;
using BossWellApp;
using ApiHelp;
using SystemConfig;
using BossWellModel;

namespace BossWellApi.Controllers
{
    /// <summary>
    /// 短信模板发送
    /// </summary>
    public class SMSendTempController : ApiController
    {
        ClientApp cltAPP = new ClientApp();
        JObjectResult result = new JObjectResult();
        public SMSendTempController()
        {
            result.code = 200;
            result.msg = "Success";
        }

        /// <summary>
        /// 注册
        /// </summary>
        [HttpGet]
        [Route("api/smsendtemp/register")]
        public JObjectResult Register(string mobile)
        {
            bool isSend = false;
            if (string.IsNullOrEmpty(mobile) || !RegularHelp.CheckMobile(mobile))
            {
                result.code = 500;
                result.msg = "手机号码格式错误";
                return result;
            }

            ClientEntity cltModel = cltAPP.GetEntityByAccount(mobile);
            if (cltModel != null)
            {
                result.code = 503;
                result.msg = "请勿重复注册";
                return result;
            }

            string code = ApiHelper.CreateRandom(4, 10, string.Empty);
            //写入缓存
            CaCheApp.WriteCache(mobile, code);

            if (PlatPublicConfig.IsOpenSMS)
            {
                isSend = SMSendTempAPP.SendVerCode(mobile, code);
            }
            result.data = isSend;
            return result;
        }

    }
}
