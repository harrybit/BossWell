using BossWellApp;
using System.Web.Http;
using WebApi.OutputCache.V2;

namespace BossWellApi.Controllers
{
    /// <summary>
    /// 轮播图
    /// </summary>
    public class BannerController : ApiController
    {
        private JObjectResult result = new JObjectResult();
        private BannerApp bannerApp = new BannerApp();

        public BannerController()
        {
            result.code = 200;
            result.msg = "Success";
        }

        /// <summary>
        /// 分页列表
        /// </summary>
        [HttpGet]
        [Route("api/banner/getlist")]
        [CacheOutput(ClientTimeSpan = 5, ServerTimeSpan = 5)]
        public JObjectResult GetPageList(int page, int pageSize, string comclassSid)
        {
            if (page < 1 || pageSize < 1 || string.IsNullOrEmpty(comclassSid))
            {
                result.code = 500;
                result.msg = "参数异常";
                return result;
            }
            result.data = bannerApp.GetPageList(page, pageSize, comclassSid);
            return result;
        }
    }
}