using BossWellFactory;
using IBossWellService;
using BossWellModel;
using BossWellModel.Enum;
using System.Collections.Generic;
using System.Linq;
using System;
using BossWellApp.Basic;
using BossWellModel.Base;
using ApiHelp;
using BossWellModel.BossWellModel;

namespace BossWellApp
{
    public class RoleApp
    {
        private IRoleService _service = SysAutoFactory.GetRoleService();
        private IOrganizeService _organService = SysAutoFactory.GetOrganizeService();
        private ModuleApp moduleAPP = new ModuleApp();
        private ModuleButtonApp moduleButtonAPP = new ModuleButtonApp();
        public string GetGridListJson(string keyWord)
        {
            return ApiHelper.JsonSerial(GetPageListByKeyWord(keyWord));
        }

        public string GetTreeSelectJson()
        {
            List<RoleEntity> roleList = GetPageListByKeyWord(string.Empty);
            List<TreeSelectModel> treeList = new List<TreeSelectModel>();
            roleList.ForEach(delegate (RoleEntity item)
            {
                treeList.Add(new TreeSelectModel()
                {
                    id = item.Sid,
                    text = item.FullName,
                    parentId = "0"
                });
            });
            return treeList.TreeSelectJson();
        }

        public string GetFormData(string sid)
        {
            return ApiHelper.JsonSerial(_service.GetFormData(sid));
        }

        public int SubmitForm(RoleEntity roleEntity, string moduleLst, string sid)
        {
            moduleLst = moduleLst.Replace('-', '_');
            List<string> moduleIDList = ApiHelper.JsonDeserial<string[]>(moduleLst).ToList();

            if (moduleIDList == null || moduleIDList.Count < 1)
            {
                //Module ID IS Null
                return 501;
            }

            if (!string.IsNullOrEmpty(roleEntity.OrganizeId))
            {
                OrganizeEntity organEntity = _organService.GetFormData(roleEntity.OrganizeId);
                roleEntity.OrganizeName = (organEntity == null ? string.Empty : organEntity.FullName);
            }

            if (!string.IsNullOrEmpty(sid))
            {
                RoleEntity editEntity = _service.GetFormData(sid);
                if (editEntity != null)
                {
                    roleEntity.Sid = editEntity.Sid;
                    roleEntity.CreateDate = editEntity.CreateDate;
                }
            }

            List<RoleAuthorizeEntity> authorList = new List<RoleAuthorizeEntity>();
            List<ModuleEntity> moduleList = moduleAPP.GetModuleListByIDS(moduleIDList);
            List<ModuleButtonEntity> moduleButtonList = moduleButtonAPP.GetListByButtonID(moduleIDList);
            if ((moduleList.Count + moduleButtonList.Count) != moduleIDList.Count)
            {
                // ModuleID Not
                return 502;
            }

            int sortAPPLocation = 0;
            moduleIDList.ForEach(delegate (string t)
            {
                RoleAuthorizeModuleEnum authorEnum = RoleAuthorizeModuleEnum.列表;
                if (moduleList.Select(c => c.Sid).Contains(t))
                {
                    authorEnum = RoleAuthorizeModuleEnum.模块;
                }
                else if (moduleButtonList.Select(c => c.Sid).Contains(t))
                {
                    authorEnum = RoleAuthorizeModuleEnum.按钮;
                }
                authorList.Add(new RoleAuthorizeEntity()
                {
                    Sid = string.Empty,
                    CreateDate = DateTime.Now,
                    ModuleId = t,
                    ModulType = authorEnum,
                    RoleId = roleEntity.Sid,
                    RoleType = RoleCateEnum.系统管理员,
                    Sort = sortAPPLocation
                });
                sortAPPLocation++;
            });
            _service.SubmitForm(roleEntity, authorList);
            return 200;
        }

        public int DeleteForm(string sid)
        {
            return _service.Delete(sid);
        }

        private List<RoleEntity> GetPageListByKeyWord(string keyWord)
        {
            QueryRequest<RoleEntity> request = new QueryRequest<RoleEntity>();
            request.expression = (t => true);
            if (!string.IsNullOrEmpty(keyWord))
            {
                request.expression = (t => t.FullName.Contains(keyWord));
            }
            request.Page = 1;
            request.PageSize = 10000;
            request.Sort = (t => t.Sort);
            return _service.GetPageList(request).Items;
        }

    }
}
