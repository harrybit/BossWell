using System.Net.Http;
using System.Web.Http;
using BossWellApp;
using System.Web;
using BossWellModel;
using System.Threading.Tasks;
using WebApi.OutputCache.V2;

namespace BossWellApi.Controllers
{
    /// <summary>
    /// 上传文件
    /// </summary>
    [AllowAnonymous]
    public class UpLoadController : ApiController
    {
        ClientApp cltAPP = new ClientApp();
        UpLoadFileApp fileAPP = new UpLoadFileApp();
        JObjectResult result = new JObjectResult();
        public UpLoadController()
        {
            result.code = 200;
            result.msg = "Success";
        }

        /// <summary>
        /// 获取上传许可证
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/upload/getlicense")]
        [CacheOutput(ClientTimeSpan = 3, ServerTimeSpan = 3)]
        public JObjectResult GetLicense(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                result.code = 500;
                result.msg = "Token Is Null";
                return result;
            }
            ClientEntity cltModel = cltAPP.GetCltEntityByToken(token);
            if (cltModel == null)
            {
                result.code = 501;
                result.msg = "Token失效";
                return result;
            }

            result.data = fileAPP.GetLicenseID(cltModel.AccountNo);
            return result;
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        [HttpPost]
        [Route("api/upload/file")]
        public async Task<JObjectResult> UpLoadFile()
        {
            HttpRequest request = HttpContext.Current.Request;
            if (request == null)
            {
                result.code = 500;
                result.msg = "Upload Error";
                return result;
            }

            HttpFileCollection files = request.Files;
            var heads = request.Headers;
            if (files == null || heads == null || heads.Count < 2 || files.Count < 1)
            {
                result.code = 404;
                result.msg = "请选择上传的文件";
                return result;
            }

            if (!Request.Content.IsMimeMultipartContent() || heads["AFU_License"] == null || heads["Token"] == null)
            {
                result.code = 501;
                result.msg = "Head Error";
                return result;
            }

            string license = heads["AFU_License"].ToString();
            string token = heads["Token"].ToString();

            //效验登录令牌
            ClientEntity cltModel = cltAPP.GetCltEntityByToken(token);
            if (cltModel == null)
            {
                result.code = 502;
                result.msg = "token失效";
                return result;
            }

            //效验文件上传许可证是否正确
            if (!fileAPP.CheckLicense(cltModel.AccountNo, license))
            {
                result.code = 503;
                result.msg = "License错误";
                return result;
            }

            //上传
            string Path = fileAPP.UpLoadFile(request.Files,cltModel.AccountNo);
            if (string.IsNullOrEmpty(Path))
            {
                result.code = 504;
                result.msg = "上传失败";
                return result;
            }
            result.data = Path;
            return result;
        }
    }
}
