using ApiHelp;
using BossWellApp.Basic;
using BossWellFactory;
using BossWellModel;
using BossWellModel.Base;
using BossWellModel.BossWellModel;
using IBossWellService;
using System.Collections.Generic;
using System.Linq;

namespace BossWellApp
{
    public class SystemConfigApp
    {
        private ISystemConfigService _service = SysAutoFactory.GetSysConfig();

        public string GetTreeSelectJson()
        {
            List<TreeSelectModel> treeList = new List<TreeSelectModel>();
            List<SystemConfigEntity> list = GetList(string.Empty);
            list.ForEach(delegate (SystemConfigEntity item)
            {
                treeList.Add(new TreeSelectModel()
                {
                    id = item.Sid,
                    parentId = item.ParentId,
                    text = item.Title
                });
            });
            return treeList.TreeSelectJson();
        }

        public string GetTreeGridJson(string keyWord)
        {
            List<TreeGridModel> treeList = new List<TreeGridModel>();
            List<SystemConfigEntity> list = GetList(string.Empty);
            list.ForEach(delegate (SystemConfigEntity item)
            {
                bool isChild = list.Count(t => t.ParentId.Equals(item.Sid)) > 0 ? true : false;
                treeList.Add(new TreeGridModel()
                {
                    id = item.Sid,
                    isLeaf = isChild,
                    parentId = item.ParentId,
                    expanded = isChild,
                    entityJson = ApiHelper.JsonSerial(item)
                });
            });
            return treeList.TreeGridJson();
        }

        public string GetFormJson(string sid)
        {
            return ApiHelper.JsonSerial(_service.GetForm(sid));
        }

        public SystemConfigEntity SaveForm(SystemConfigEntity sysModel, string sid)
        {
            if (!string.IsNullOrEmpty(sid))
            {
                SystemConfigEntity editEntity = _service.GetForm(sid);
                if (editEntity != null)
                {
                    sysModel.Sid = editEntity.Sid;
                    sysModel.CreateDate = editEntity.CreateDate;
                }
            }
            return _service.SaveForm(sysModel);
        }

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

        private List<SystemConfigEntity> GetList(string keyWord)
        {
            QueryRequest<SystemConfigEntity> request = new QueryRequest<SystemConfigEntity>();
            request.expression = (t => t.Title.Contains(keyWord));
            request.Page = 1;
            request.PageSize = 10000;
            request.Sort = (t => t.Sort);
            QueryResponse<SystemConfigEntity> response = _service.GetPageList(request);
            return response.Items;
        }
    }
}