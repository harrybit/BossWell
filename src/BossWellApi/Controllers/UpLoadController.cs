using ApiHelp;
using BossWellApp;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using WebApi.OutputCache.V2;

namespace BossWellApi.Controllers
{
    /// <summary>
    /// 上传文件
    /// </summary>
    [AllowAnonymous]
    public class UpLoadController : ApiController
    {
        private ClientApp cltAPP = new ClientApp();
        private UpLoadFileApp fileAPP = new UpLoadFileApp();
        private JObjectResult result = new JObjectResult();

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
        [CacheOutput(ServerTimeSpan = 1, ClientTimeSpan = 1)]
        public JObjectResult GetLicense()
        {
            //许可证
            string GuId = ApiHelper.CreateRandomString(32, "AFU_");
            string licenseKey = ApiHelper.SHA256(GuId);

            //写入缓存
            fileAPP.WriteLicenseKey(GuId, licenseKey);

            result.data = new { GUID = GuId, AFU_License = licenseKey };
            return result;
        }

        /// <summary>
        /// 上传文件
        /// Head信息体:
        /// AFU_Guid：  加密签名
        /// AFU_License:上传许可证
        /// </summary>
        /// <returns></returns>
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

            if (!Request.Content.IsMimeMultipartContent() || heads["AFU_License"] == null || heads["AFU_Guid"] == null)
            {
                result.code = 501;
                result.msg = "Head Error";
                return result;
            }

            string license = heads["AFU_License"].ToString();
            string GuId = heads["AFU_Guid"].ToString();

            //效验文件上传许可证是否正确
            if (!fileAPP.CheckLicense(GuId, license))
            {
                result.code = 503;
                result.msg = "License错误";
                return result;
            }

            //上传
            result.data = fileAPP.UpLoadFile(request.Files, GuId);
            return result;
        }
    }
}