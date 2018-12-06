using BossWell.ApiHelp;
using BossWell.Domain;
using BossWell.Interface;
using BossWell.Model;
using BossWell.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BossWell.Application
{
    public class ModuleApplication
    {
        IModuleService _service = SysAuthFactory.GetModuleService();

        /// <summary>
        /// 菜单列表
        /// </summary>
        /// <param name="moduleType">菜单类型</param>
        /// <returns></returns>
        public List<ModuleEntity> GetAllModuleListByType(ModuleEnum moduleType, string keyWord)
        {
            QueryRequest<ModuleEntity> request = new QueryRequest<ModuleEntity>();
            keyWord = string.IsNullOrEmpty(keyWord) ? string.Empty : keyWord;
            if (moduleType == ModuleEnum.未知)
                request.Expression = (t => t.FullName.Contains(keyWord));
            else
                request.Expression = t => (t.Type == moduleType && t.FullName.Contains(keyWord));
            request.Page = 1;
            request.PageSize = int.MaxValue;
            request.Sort = "Sort asc";
            return _service.GetPageList(request).Items.ToList();
        }

        /// <summary>
        /// 菜单单条信息
        /// </summary>
        /// <param name="sid">条目Sid</param>
        /// <returns></returns>
        public ModuleEntity GetEntityBySid(string sid)
        {
            return _service.GetSingle(sid);
        }

        /// <summary>
        /// 保存菜单
        /// </summary>
        /// <param name="model">信息体</param>
        /// <returns></returns>
        public bool SubmitModule(ModuleEntity model)
        {
            //保存失败
            if (model == null) { return false; }

            if (!string.IsNullOrEmpty(model.Sid) && model.Sid.Length > 32)
            {
                ModuleEntity moduleEntity = _service.GetSingle(model.Sid);
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
        /// 菜单所有子级
        /// </summary>
        /// <param name="pid">菜单Sid</param>
        /// <returns></returns>
        public List<ModuleEntity> GetModuleChildList(string pid)
        {
            return _service.GetModuleChildListBySid(pid);
        }

        /// <summary>
        /// 获取选中菜单集合
        /// </summary>
        /// <param name="btnList">菜单Sid集合</param>
        /// <returns></returns>
        public List<ModuleEntity> GetCloneBtnList(List<string> btnList)
        {
            QueryRequest<ModuleEntity> request = new QueryRequest<ModuleEntity>();
            request.Expression = (t => btnList.Contains(t.Sid));
            request.Page = 1;
            request.PageSize = int.MaxValue;
            request.Sort = "Sort asc";
            return _service.GetPageList(request).Items.ToList();
        }

        /// <summary>
        /// 批量删除菜单Child
        /// </summary>
        /// <param name="sid">条目Sid</param>
        /// <returns></returns>
        public bool DeleteForm(string sid)
        {
            List<string> childSid = new List<string>() { sid };
            List<ModuleEntity> childList = GetModuleChildList(sid);
            if (childList != null && childList.Count > 0)
            {
                childSid.AddRange(childList.Select(t => t.Sid).ToList());
            }
            int result = _service.DeleteFrom(childSid);
            return result > 0 ? true : false;
        }

        /// <summary>
        /// 克隆菜单
        /// </summary>
        /// <param name="moduleId">菜单Sid</param>
        /// <param name="btnSids">克隆按钮集合</param>
        /// <returns></returns>
        public bool CloneModuleButton(string moduleId, string btnSids)
        {
            List<string> arrayBtnSid = ApiHelper.JsonDeserial<string[]>(btnSids).ToList();
            if (arrayBtnSid == null || arrayBtnSid.Count < 1) { return false; }
            List<ModuleEntity> btnList = GetCloneBtnList(arrayBtnSid);
            if (btnList == null || btnList.Count < 1)
            {
                return false;
            }
            btnList.ForEach(t =>
            {
                t.Sid = ApiHelper.CreateRandomString(32, "module_");
                t.CreateDate = DateTime.Now;
                t.ParentId = moduleId;
            });
            int result = _service.SaveBatch(btnList);
            return result < 1 ? false : true;
        }

    }
}
