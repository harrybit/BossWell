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
    public class OrganizeApp
    {
        private readonly IOrganizeService _service = SysAutoFactory.GetOrganizeService();
        private readonly IComClassService _comClaService = SysAutoFactory.GetComClassService();

        public string GetSelectTreeJson()
        {
            List<OrganizeEntity> allList = GetAllList();
            List<TreeSelectModel> treeList = new List<TreeSelectModel>();
            allList.ForEach(delegate (OrganizeEntity item)
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

        public string GetTreeJson()
        {
            List<OrganizeEntity> allList = GetAllList();
            List<TreeViewModel> treeList = new List<TreeViewModel>();
            allList.ForEach(delegate (OrganizeEntity item)
            {
                int childCount = allList.Where(t => t.ParentId.Equals(item.Sid)).Count();
                treeList.Add(new TreeViewModel()
                {
                    id = item.Sid,
                    text = item.FullName,
                    value = item.EnCode,
                    parentId = item.ParentId,
                    isexpand = true,
                    complete = true,
                    hasChildren = childCount > 0 ? true : false
                });
            });
            return treeList.TreeViewJson();
        }

        public string GetGridTreeJson(string keyWord)
        {
            List<OrganizeEntity> allList = GetAllList(keyWord);
            List<TreeGridModel> gridList = new List<TreeGridModel>();
            allList.ForEach(delegate (OrganizeEntity item)
            {
                int childCount = allList.Where(t => t.ParentId.Equals(item.Sid)).Count();

                gridList.Add(new TreeGridModel()
                {
                    id = item.Sid,
                    text = item.FullName,
                    parentId = item.ParentId,
                    isLeaf = childCount > 0 ? true : false,
                    expanded = childCount > 0 ? true : false,
                    entityJson = ApiHelper.JsonSerial(item)
                });
            });
            return gridList.TreeGridJson();
        }

        public string GetFormJson(string sid)
        {
            return ApiHelper.JsonSerial(_service.GetFormData(sid));
        }

        public void SubmitForm(OrganizeEntity organizeEntity, string sid)
        {
            if (!string.IsNullOrEmpty(sid))
            {
                OrganizeEntity entity = _service.GetFormData(sid);
                if (entity != null)
                {
                    organizeEntity.Sid = entity.Sid;
                    organizeEntity.CreateDate = entity.CreateDate;
                }
            }
            _service.SaveForm(organizeEntity);
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
        /// 查询全部组织架构
        /// </summary>
        public List<OrganizeEntity> GetAllList(string keyWord = "")
        {
            QueryRequest<OrganizeEntity> request = new QueryRequest<OrganizeEntity>();
            request.Page = 1;
            request.PageSize = 1000;
            request.Sort = (t => t.CreateDate);
            request.SortTp = "desc";
            if (!string.IsNullOrEmpty(keyWord))
            {
                request.expression = (t => t.FullName.Contains(keyWord) || t.EnCode.Contains(keyWord));
            }
            else
            {
                request.expression = (t => true);
            }

            List<OrganizeEntity> list = _service.GetPageList(request).Items;
            return list;
        }
    }
}