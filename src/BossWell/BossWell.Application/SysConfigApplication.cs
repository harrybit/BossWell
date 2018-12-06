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
    public class SysConfigApplication
    {
        ISysConfigService _service = SysPublicFactory.GetSysConfigService();

        /// <summary>
        /// 参数配置列表
        /// </summary>
        /// <param name="keyWord">模糊查询</param>
        /// <returns></returns>
        public List<SystemConfigEntity> GetAllSysConfigList(string keyWord)
        {
            QueryRequest<SystemConfigEntity> request = new QueryRequest<SystemConfigEntity>();
            keyWord = string.IsNullOrEmpty(keyWord) ? string.Empty : keyWord;
            request.Expression = (t => t.Title.Contains(keyWord) || t.Cmd.Contains(keyWord));
            request.Page = 1;
            request.PageSize = int.MaxValue;
            request.Sort = "Sort asc";
            return _service.GetPageList(request).Items.ToList();
        }

        /// <summary>
        /// 参数单条信息
        /// </summary>
        /// <param name="sid">条目Sid</param>
        /// <returns></returns>
        public SystemConfigEntity GetEntityBySid(string sid)
        {
            return _service.GetSingle(sid);
        }

        /// <summary>
        /// 保存参数配置
        /// </summary>
        /// <param name="model">信息体</param>
        /// <returns></returns>
        public bool SubmitModule(SystemConfigEntity model)
        {
            //保存失败
            if (model == null) { return false; }

            if (!string.IsNullOrEmpty(model.Sid) && model.Sid.Length > 32)
            {
                SystemConfigEntity moduleEntity = _service.GetSingle(model.Sid);
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
        /// 参数配置所有子级
        /// </summary>
        /// <param name="pid">参数Sid</param>
        /// <returns></returns>
        public List<SystemConfigEntity> GetSysConfigChildList(string pid)
        {
            return _service.GetSysConfigChildListBySid(pid);
        }

        /// <summary>
        /// 批量删除参数配置Child
        /// </summary>
        /// <param name="sid">条目Sid</param>
        /// <returns></returns>
        public bool DeleteForm(string sid)
        {
            List<string> childSid = new List<string>() { sid };
            List<SystemConfigEntity> childList = GetSysConfigChildList(sid);
            if (childList != null && childList.Count > 0)
            {
                childSid.AddRange(childList.Select(t => t.Sid).ToList());
            }
            int result = _service.DeleteFrom(childSid);
            return result > 0 ? true : false;
        }

    }
}
