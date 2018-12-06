using BossWell.Application;
using System.Web.Http;
using WebApi.OutputCache.V2;
namespace BossWell.API.Controllers
{
    /// <summary>
    /// 综合分类
    /// </summary>
    public class ComClassController : ApiController
    {
        private JObjectResult result = new JObjectResult();
        private ComClassApplication comApp = new ComClassApplication();
        public ComClassController()
        {
            result.Code = 200;
            result.Msg = "Success";
        }

        /// <summary>
        /// 综合分类分页列表
        /// </summary>
        /// <param name="page">页码</param>
        /// <param name="pageSize">每页条目</param>
        /// <param name="parentSid">分类节点Sid</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/comclass/getpagelist")]
        [CacheOutput(ServerTimeSpan = 10, ClientTimeSpan = 5)]
        public JObjectResult GetPageList(int page, int pageSize, string parentSid)
        {
            if (page < 1 || pageSize < 1 || string.IsNullOrEmpty(parentSid))
            {
                result.Code = 500;
                result.Msg = "参数异常";
                return result;
            }
            result.CMD = "List";
            result.Data = comApp.GetFirstChildByParentId(page, pageSize, parentSid);
            return result;
        }

        /// <summary>
        /// 综合分类树
        /// </summary>
        /// <param name="parentSid">分类节点</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/comclass/getallchild")]
        [CacheOutput(ServerTimeSpan = 10, ClientTimeSpan = 5)]
        public JObjectResult GetAllChildTree(string parentSid)
        {
            if (string.IsNullOrEmpty(parentSid))
            {
                result.Code = 500;
                result.Msg = "参数异常";
                return result;
            }
            result.CMD = "Tree";
            result.Data = comApp.GetAllChildByParentId(parentSid);
            return result;
        }


    }
}
