using BossWell.ApiHelp;
using BossWell.Domain;
using BossWell.Interface;
using BossWell.Model;
using System;
using System.Collections.Generic;
using System.Linq;
namespace BossWell.Application
{
    public class RoleApplication
    {
        IRoleService _service = SysAuthFactory.GetRoleService();
        ModuleApplication moduleAPP = new ModuleApplication();

        /// <summary>
        /// 角色列表
        /// </summary>
        /// <param name="moduleType">菜单类型</param>
        /// <returns></returns>
        public List<RoleEntity> GetAllModuleListByType(string keyWord)
        {
            QueryRequest<RoleEntity> request = new QueryRequest<RoleEntity>();
            request.Expression = t => string.IsNullOrEmpty(keyWord) ? true : (t.FullName.Contains(keyWord) || t.FullNameCN.Contains(keyWord));
            request.Page = 1;
            request.PageSize = int.MaxValue;
            request.Sort = "Sort asc";
            return _service.GetPageList(request).Items.ToList();
        }

        /// <summary>
        /// 角色单条信息
        /// </summary>
        /// <param name="sid">条目Sid</param>
        /// <returns></returns>
        public RoleEntity GetEntityBySid(string sid)
        {
            return _service.GetSingle(sid);
        }

        /// <summary>
        /// 保存角色
        /// </summary>
        /// <param name="model">信息体</param>
        /// <param name="authorSid">权限菜单按钮</param>
        /// <returns></returns>
        public bool SubmitModule(RoleEntity model, string authorSid)
        {
            //保存失败
            if (model == null) { return false; }
            string roleSid = string.Empty;
            List<string> roleAuthorSidList = ApiHelper.JsonDeserial<string[]>(authorSid.Replace("-", "_")).ToList();
            if (!string.IsNullOrEmpty(model.Sid) && model.Sid.Length > 32)
            {
                RoleEntity roleEntity = _service.GetSingle(model.Sid);
                if (roleEntity != null)
                {
                    model.CreateDate = roleEntity.CreateDate;
                    model.EditDate = DateTime.Now;
                    model.IsDelete = roleEntity.IsDelete;
                    model.Sid = roleEntity.Sid;
                    roleSid = roleEntity.Sid;
                }
            }
            List<RoleAuthorizeEntity> authorList = new List<RoleAuthorizeEntity>();
            List<ModuleEntity> moduleList = moduleAPP.GetCloneBtnList(roleAuthorSidList);
            moduleList.ForEach(delegate (ModuleEntity item)
            {
                authorList.Add(new RoleAuthorizeEntity()
                {
                    CreateDate = DateTime.Now,
                    IsDelete = false,
                    ModuleId = item.Sid,
                    RoleId = roleSid,
                    Sid = ApiHelper.CreateRandomString(32, "roleauthor_"),
                    Sort = 0
                });
            });
            _service.SaveFrom(model, authorList);
            return true;
        }

        /// <summary>
        /// 删除角色
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
