using BossWell.Application;
using BossWell.Model;
using BossWell.Model.Basic;
using System.Collections.Generic;
using System.Web.Http;
using WebApi.OutputCache.V2;
namespace BossWell.API.Controllers
{
    /// <summary>
    /// 轮播图
    /// </summary>
    public class BannerController : ApiController
    {
        private JObjectResult result = new JObjectResult();
        private BannerApplication bannerApp = new BannerApplication();
        public BannerController()
        {
            result.Code = 200;
            result.Msg = "Success";
        }

        /// <summary>
        /// 轮播图分页列表
        /// </summary>
        /// <param name="page">页码</param>
        /// <param name="pageSize">每页条目</param>
        /// <param name="comClassSid">所属分类</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/banner/getpagelist")]
        [CacheOutput(ServerTimeSpan = 10, ClientTimeSpan = 5)]
        public JObjectResult GetPageList(int page, int pageSize, string comClassSid)
        {
            if (page < 1 || pageSize < 1 || string.IsNullOrEmpty(comClassSid))
            {
                result.Code = 500;
                result.Msg = "参数异常";
                return result;
            }

            Pagination pagination = new Pagination();
            pagination.page = page;
            pagination.rows = pageSize;
            result.CMD = "List";

            List<BannerEntity> bannerList = bannerApp.GetBannerPageList(pagination, string.Empty, comClassSid, true);

            result.Data = new QueryResponse<BannerEntity>()
            {
                Items = bannerList,
                TotalCount = pagination.records
            }; ;
            return result;
        }

    }
}
