using BossWell.ApiHelp;
using BossWell.Domain;
using BossWell.Interface;
using BossWell.Model;
using BossWell.Model.Basic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BossWell.Application
{
    public class AreaApplication
    {
        IAreaService _service = SysPublicFactory.GetAreaService();

        /// <summary>
        /// 行政区域列表
        /// </summary>
        /// <param name="keyWord">模糊查询</param>
        /// <returns></returns>
        public List<AreaEntity> GetAllAreaList(string keyWord)
        {
            QueryRequest<AreaEntity> request = new QueryRequest<AreaEntity>();
            keyWord = string.IsNullOrEmpty(keyWord) ? string.Empty : keyWord;
            request.Expression = (t => t.FullName.Contains(keyWord));
            request.Page = 1;
            request.PageSize = int.MaxValue;
            request.Sort = "Sort asc";
            return _service.GetPageList(request).Items.ToList();
        }

        /// <summary>
        /// 区域单条信息
        /// </summary>
        /// <param name="sid">条目Sid</param>
        /// <returns></returns>
        public AreaEntity GetEntityBySid(string sid)
        {
            return _service.GetSingle(sid);
        }

        /// <summary>
        /// 保存行政区域
        /// </summary>
        /// <param name="model">信息体</param>
        /// <returns></returns>
        public bool SubmitModule(AreaEntity model)
        {
            //保存失败
            if (model == null) { return false; }

            if (!string.IsNullOrEmpty(model.Sid) && model.Sid.Length > 32)
            {
                AreaEntity moduleEntity = _service.GetSingle(model.Sid);
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
        /// 行政区域所有子级
        /// </summary>
        /// <param name="pid">区域Sid</param>
        /// <returns></returns>
        public List<AreaEntity> GetAreaChildList(string pid)
        {
            return _service.GetAreaChildListBySid(pid);
        }

        /// <summary>
        /// 批量删除区域Child
        /// </summary>
        /// <param name="sid">条目Sid</param>
        /// <returns></returns>
        public bool DeleteForm(string sid)
        {
            List<string> childSid = new List<string>() { sid };
            List<AreaEntity> childList = GetAreaChildList(sid);
            if (childList != null && childList.Count > 0)
            {
                childSid.AddRange(childList.Select(t => t.Sid).ToList());
            }
            int result = _service.DeleteFrom(childSid);
            return result > 0 ? true : false;
        }

    }
}
