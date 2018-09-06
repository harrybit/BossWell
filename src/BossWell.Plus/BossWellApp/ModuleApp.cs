using ApiHelp;
using BossWellApp.Basic;
using BossWellFactory;
using BossWellModel;
using BossWellModel.Base;
using BossWellModel.BossWellModel;
using IBossWellService;
using System.Collections.Generic;
using SystemConfig;

namespace BossWellApp
{
    public class ModuleApp
    {
        private IModuleService _service = SysAutoFactory.GetModuleService();

        public string GetTreeSelectJson()
        {
            List<ModuleEntity> allList = GetAllList();
            List<TreeSelectModel> treeList = new List<TreeSelectModel>();
            allList.ForEach(delegate (ModuleEntity item)
            {
                treeList.Add(new TreeSelectModel()
                {
                    id = item.Sid,
                    text = item.FullName,
                    parentId = item.ParentId
                });
            });
            return treeList.TreeSelectJson();
        }

        public string GetTreeGridJson()
        {
            List<ModuleEntity> allList = GetAllList();
            List<TreeGridModel> treeList = new List<TreeGridModel>();
            allList.ForEach(delegate (ModuleEntity item)
            {
                int childCount = _service.GetChildCount(item.Sid);
                treeList.Add(new TreeGridModel()
                {
                    id = item.Sid,
                    text = item.FullName,
                    parentId = item.ParentId,
                    isLeaf = childCount > 0 ? true : false,
                    expanded = childCount > 0 ? true : false,
                    entityJson = ApiHelper.JsonSerial(item)
                });
            });
            return treeList.TreeGridJson();
        }

        public string GetFormJson(string sid)
        {
            return ApiHelper.JsonSerial(_service.GetFormData(sid));
        }

        public ModuleEntity SubmitForm(ModuleEntity moduleEntity, string sid)
        {
            if (!string.IsNullOrEmpty(sid))
            {
                ModuleEntity editEntity = _service.GetFormData(sid);
                if (editEntity != null)
                {
                    moduleEntity.Sid = editEntity.Sid;
                    moduleEntity.CreateDate = editEntity.CreateDate;
                }
            }
            return _service.SaveModel(moduleEntity);
        }

        /// <summary>
        /// 删除全部子级记录
        /// </summary>
        public int DeleteForm(string sid)
        {
            List<string> allList = new List<string>();

            List<string> childList = _service.GetChildNodeList(sid);
            allList.Add(sid);
            if (childList.Count > 0)
            {
                allList.AddRange(GetAllChild(childList, new List<string>()));
            }
            return _service.DeleteForm(allList);
        }

        /// <summary>
        /// 递归子级
        /// </summary>
        /// <returns></returns>
        private List<string> GetAllChild(List<string> nodeList, List<string> allList)
        {
            if (nodeList.Count < 1)
            {
                return allList;
            }
            allList.AddRange(nodeList);
            foreach (string areaSid in allList)
            {
                List<string> childList = _service.GetChildNodeList(areaSid);
                if (childList.Count < 1) { continue; }
                GetAllChild(childList, allList);
            }
            return allList;
        }

        /// <summary>
        /// 查询全部菜单集合
        /// </summary>
        public List<ModuleEntity> GetAllList()
        {
            QueryRequest<ModuleEntity> request = new QueryRequest<ModuleEntity>();
            request.Page = 1;
            request.PageSize = 10000;
            request.expression = (t => true);
            request.Sort = (t => t.Sort);
            return _service.GetPageList(request).Items;
        }

        public List<ModuleEntity> GetModuleMenuByRole(string roleId)
        {
            string userName = OperatorProvider.Provider.GetCurrent().UserCode;

            if (PlatPublicConfig.AdminName.Equals(userName))
            {
                return GetAllList();
            }
            return _service.GetModuleMenuByRole(roleId);
        }

        public List<ModuleButtonEntity> GetModuleButtonByRole(string roleId)
        {
            string userName = OperatorProvider.Provider.GetCurrent().UserCode;

            if (PlatPublicConfig.AdminName.Equals(userName))
            {
                ModuleButtonApp buttonAPP = new ModuleButtonApp();
                return buttonAPP.GetAllList();
            }

            return _service.GetModuleButtonByRole(roleId);
        }

        //Get List By IDs
        public List<ModuleEntity> GetModuleListByIDS(List<string> IDs)
        {
            QueryRequest<ModuleEntity> request = new QueryRequest<ModuleEntity>();
            request.expression = (t => IDs.Contains(t.Sid));
            request.Page = 1;
            request.PageSize = 3000;
            request.Sort = (t => t.Sort);
            return _service.GetPageList(request).Items;
        }
    }
}