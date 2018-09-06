using BossWellApp;
using System.Web.Http;
using WebApi.OutputCache.V2;

namespace BossWellApi.Controllers
{
    /// <summary>
    /// 资讯新闻
    /// </summary>
    public class NewsController : ApiController
    {
        private JObjectResult result = new JObjectResult();
        private NewsApp newsAPP = new NewsApp();

        public NewsController()
        {
            result.code = 200;
            result.msg = "Success";
        }

        /// <summary>
        /// 资讯分页列表
        /// </summary>
        [HttpGet]
        [Route("api/news/getlist")]
        [CacheOutput(ClientTimeSpan = 5, ServerTimeSpan = 5)]
        public JObjectResult GetPageList(int page, int pageSize, string comclassSid)
        {
            if (page < 1 || pageSize < 1 || string.IsNullOrEmpty(comclassSid))
            {
                result.code = 500;
                result.msg = "参数异常";
                return result;
            }
            result.data = newsAPP.GetPageList(page, pageSize, comclassSid);
            return result;
        }
    }
}