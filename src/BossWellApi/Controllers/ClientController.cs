using BossWellApp;
using BossWellModel.BossWellModel;
using System.Web.Http;
using ApiHelp;
using BossWellModel;
namespace BossWellApi.Controllers
{
    /// <summary>
    /// 会员控制
    /// </summary>
    public class ClientController : ApiController
    {
        ClientApp cltAPP = new ClientApp();
        JObjectResult result = new JObjectResult();
        public ClientController()
        {
            result.code = 200;
            result.msg = "Success";
        }

        /// <summary>
        /// 会员注册
        /// </summary>
        [HttpPost]
        [Route("api/client/register")]
        public JObjectResult Register(RegisterModel model)
        {
            if (model == null || string.IsNullOrEmpty(model.Account) ||
                string.IsNullOrEmpty(model.PassWord) || string.IsNullOrEmpty(model.Code))
            {
                result.code = 500;
                result.msg = "参数异常";
                return result;
            }

            //手机号码格式
            if (!RegularHelp.CheckMobile(model.Account))
            {
                result.code = 501;
                result.msg = "手机号码格式错误";
                return result;
            }

            //验证码是否正确
            object resultCode = CaCheApp.ReadCache(model.Account);
            if (resultCode == null || string.IsNullOrEmpty(resultCode.ToString()) || !resultCode.ToString().Equals(model.Code))
            {
                result.code = 502;
                result.msg = "验证码错误";
                return result;
            }
            ClientEntity cltModel = cltAPP.Register(model);
            if (cltModel == null)
            {
                result.code = 503;
                result.msg = "请勿重复注册，注册失败";
                return result;
            }
            //清除验证码缓存
            CaCheApp.RemoveCache(model.Account);
            result.data = cltModel;
            return result;
        }

        /// <summary>
        /// 会员登录
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("api/client/signin")]
        public JObjectResult SignIn(SignInModel model)
        {
            if (model == null || string.IsNullOrEmpty(model.Account) ||
                string.IsNullOrEmpty(model.PassWord))
            {
                result.code = 500;
                result.msg = "参数异常";
                return result;
            }

            ClientEntity actEntity = cltAPP.GetEntityByAccount(model.Account);
            if (actEntity == null)
            {
                result.code = 501;
                result.msg = "账户不存在";
                return result;
            }

            ClientEntity cltEntity = cltAPP.GetLoginEntity(model.Account, model.PassWord);
            if (cltEntity == null)
            {
                result.code = 502;
                result.msg = "密码错误";
                return result;
            }
            result.data = cltEntity;
            return result;
        }

    }
}
