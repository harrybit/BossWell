using BossWellFactory;
using IBossWellService;
using BossWellModel.BossWellModel;
using BossWellModel;
using System;
using System.Collections.Generic;
using BossWellApp.Basic;
using BossWellModel.Base;
using ApiHelp;
using System.Linq;

namespace BossWellApp
{
    public class ModuleButtonApp
    {
        private readonly IModuleButtonService _service = SysAutoFactory.GetModuleButtonService();
        private readonly IModuleService _moduleService = SysAutoFactory.GetModuleService();
        private readonly ModuleApp moduleAPP = new ModuleApp();
        public string GetTreeSelectJson(string moduleId = "")
        {
            List<ModuleButtonEntity> allList = GetButtonListByModuleId(moduleId);
            List<TreeSelectModel> treeList = new List<TreeSelectModel>();
            allList.ForEach(delegate (ModuleButtonEntity item)
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

        public string GetTreeGridJson(string moduleId = "")
        {
            List<ModuleButtonEntity> allList = GetButtonListByModuleId(moduleId);
            List<TreeGridModel> treeList = new List<TreeGridModel>();
            allList.ForEach(delegate (ModuleButtonEntity item)
            {
                treeList.Add(new TreeGridModel()
                {
                    id = item.Sid,
                    text = item.FullName,
                    parentId = "0",
                    isLeaf = false,
                    expanded = false,
                    entityJson = ApiHelper.JsonSerial(item)
                });
            });
            return treeList.TreeGridJson();
        }

        public string GetTreeCloneButtonJson()
        {
            List<ModuleEntity> moduleList = moduleAPP.GetAllList();
            List<ModuleButtonEntity> buttonList = GetButtonListByModuleId();
            List<TreeViewModel> treeList = new List<TreeViewModel>();
            //Module
            moduleList.ForEach(delegate (ModuleEntity item)
            {
                treeList.Add(new TreeViewModel()
                {
                    id = item.Sid,
                    text = item.FullName,
                    value = item.EnCode,
                    parentId = item.ParentId,
                    isexpand = true,
                    complete = true,
                    hasChildren = true
                });
            });
            //ModuleButton
            buttonList.ForEach(delegate (ModuleButtonEntity t)
            {
                treeList.Add(new TreeViewModel()
                {
                    id = t.Sid,
                    text = t.FullName,
                    value = t.EnCode,
                    parentId = t.ModuleSid,
                    isexpand = true,
                    complete = true,
                    showcheck = true,
                    hasChildren = true,
                    img = string.Empty
                });
            });
            return treeList.TreeViewJson();
        }

        public string GetFormJson(string sid)
        {
            return ApiHelper.JsonSerial(_service.GetFormData(sid));
        }

        public int DeleteForm(string sid)
        {
            return _service.DeleteForm(sid);
        }

        public void SubmitForm(ModuleButtonEntity moduleButtonEntity, string sid)
        {
            if (!string.IsNullOrEmpty(sid))
            {
                ModuleButtonEntity editModel = _service.GetFormData(sid);
                if (editModel != null)
                {
                    moduleButtonEntity.CreateDate = editModel.CreateDate;
                    moduleButtonEntity.Sid = editModel.Sid;
                }
            }
            _service.SubmitForm(moduleButtonEntity);
        }

        //Clone
        public int SubmitCloneButton(string moduleId, string buttonIDS)
        {
            ModuleEntity entity = _moduleService.GetFormData(moduleId);
            if (entity == null)
            {
                //Module Is Null
                return 501;
            }

            List<string> buttonList = ApiHelper.JsonDeserial<string[]>(buttonIDS).ToList();
            List<ModuleButtonEntity> allList = GetListByButtonID(buttonList);
            if (allList.Count < 1)
            {
                //Button Is Null
                return 502;
            }

            allList.ForEach(t =>
            {
                t.Sid = string.Empty;
                t.CreateDate = DateTime.Now;
                t.ModuleSid = moduleId;
            });

            int resultCount = _service.SubmitBatchForm(allList);
            if (resultCount < 1)
            {
                // Save Error
                return 503;
            }
            return 200;
        }

        //Get Button By ModuleID
        public List<ModuleButtonEntity> GetButtonListByModuleId(string moduleId = "")
        {
            QueryRequest<ModuleButtonEntity> request = new QueryRequest<ModuleButtonEntity>();
            request.expression = t => true;
            if (!string.IsNullOrEmpty(moduleId))
            {
                request.expression = (t => t.ModuleSid.Equals(moduleId));
            }
            request.Sort = (t => t.Sort);
            request.Page = 1;
            request.PageSize = 10000;
            return _service.GetList(request).Items;
        }

        // Get List By ButtonIDs
        public List<ModuleButtonEntity> GetListByButtonID(List<string> idLst)
        {
            QueryRequest<ModuleButtonEntity> request = new QueryRequest<ModuleButtonEntity>();
            request.expression = (t => idLst.Contains(t.Sid));
            request.Sort = (t => t.Sort);
            request.Page = 1;
            request.PageSize = 3000;
            return _service.GetList(request).Items;
        }

        public List<ModuleButtonEntity> GetAllList()
        {
            QueryRequest<ModuleButtonEntity> request = new QueryRequest<ModuleButtonEntity>();
            request.Page = 1;
            request.PageSize = 10000;
            request.expression = (t => t.EnabledMark);
            request.Sort = (t => t.Sort);
            return _service.GetList(request).Items;
        }

    }
}
