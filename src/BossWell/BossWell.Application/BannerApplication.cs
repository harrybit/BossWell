using BossWell.Domain;
using BossWell.Interface;
using BossWell.Model;
using BossWell.Model.Basic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BossWell.Application
{
    public class BannerApplication
    {
        IBannerService _service = SysPublicFactory.GetBannerService();
        IComClassService _comService = SysPublicFactory.GetComClassService();
        /// <summary>
        /// 轮播图后台分页
        /// </summary>
        /// <param name="keyWord">模糊查询</param>
        /// <returns></returns>
        public List<BannerEntity> GetBannerPageList(Pagination pagination, string keyWord, string comClassSid = "",bool isApi=false)
        {
            QueryRequest<BannerEntity> request = new QueryRequest<BannerEntity>();
            keyWord = string.IsNullOrEmpty(keyWord) ? string.Empty : keyWord;
            request.Expression = (t => t.Title.Contains(keyWord));
            if (!string.IsNullOrEmpty(comClassSid)) request.Expression = request.Expression.And(t => t.ComClassSid.Equals(comClassSid));
            if (isApi) request.Expression = request.Expression.And(t => t.IsEnable);
            request.Page = pagination.page;
            request.PageSize = pagination.rows;
            request.Sort = "Sort asc";
            QueryResponse<BannerEntity> response = _service.GetPageList(request);
            pagination.records = response.TotalCount;
            return response.Items.ToList();
        }

        /// <summary>
        /// 轮播图单条信息
        /// </summary>
        /// <param name="sid">条目Sid</param>
        /// <returns></returns>
        public BannerEntity GetEntityBySid(string sid)
        {
            return _service.GetSingle(sid);
        }

        /// <summary>
        /// 保存轮播图
        /// </summary>
        /// <param name="model">信息体</param>
        /// <returns></returns>
        public bool SubmitModule(BannerEntity model)
        {
            //保存失败
            if (model == null) { return false; }

            if (!string.IsNullOrEmpty(model.ComClassSid))
            {
                ComClassEntity comEntity = _comService.GetSingle(model.ComClassSid);
                model.ComClass = comEntity == null ? String.Empty : comEntity.Title;
            }

            if (!string.IsNullOrEmpty(model.Sid) && model.Sid.Length > 32)
            {
                BannerEntity moduleEntity = _service.GetSingle(model.Sid);
                if (moduleEntity != null)
                {
                    model.CreateDate = moduleEntity.CreateDate;
                    model.EditDate = DateTime.Now;
                    model.IsDelete = moduleEntity.IsDelete;
                }
            }
            _service.SaveFrom(model);
            return true;
        }

        /// <summary>
        /// 删除轮播图
        /// </summary>
        /// <param name="sid">条目Sid</param>
        /// <returns></returns>
        public bool DeleteForm(string sid)
        {
            int result = _service.DeleteFrom(sid);
            return result > 0 ? true : false;
        }

    }
}
