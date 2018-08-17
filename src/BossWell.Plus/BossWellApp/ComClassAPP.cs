using BossWellFactory;
using IBossWellService;
using BossWellModel;
using BossWellModel.Base;
using System;
using System.Collections.Generic;
using BossWellApp.Basic;
using BossWellModel.BossWellModel;
using System.Linq;
using ApiHelp;
namespace BossWellApp
{
    public class ComClassAPP
    {
        IComClassService _service = SysAutoFactory.GetComClassService();

        /// <summary>
        /// Get TreeSelect By Parent
        /// </summary>
        public string GetTreeSelectJson(string parentId)
        {
            List<TreeSelectModel> treeList = new List<TreeSelectModel>();
            List<ComClassEntity> list = GetAllList(parentId);
            list.ForEach(delegate (ComClassEntity item)
            {
                string Pid = "0";
                if (string.IsNullOrEmpty(parentId) || !parentId.Equals(item.ParentId))
                {
                    Pid = item.ParentId;
                }

                treeList.Add(new TreeSelectModel()
                {
                    id = item.Sid,
                    parentId = Pid,
                    text = item.Title
                });
            });
            return treeList.TreeSelectJson();
        }

        /// <summary>
        /// Get Tree Parent
        /// </summary>
        /// <returns></returns>
        public string GetParentTree()
        {
            List<TreeViewModel> treeList = new List<TreeViewModel>();
            List<ComClassEntity> list = GetAllList("0");
            list.ForEach(delegate (ComClassEntity item)
            {
                treeList.Add(new TreeViewModel()
                {
                    id = item.Sid,
                    text = item.Title,
                    value = item.Subtitle,
                    parentId = item.ParentId,
                    isexpand = false,
                    complete = true,
                    hasChildren = false
                });
            });
            return treeList.TreeViewJson();
        }

        /// <summary>
        /// Get Grid Parent
        /// </summary>
        /// <returns></returns>
        public string GetParentGrid()
        {
            List<TreeGridModel> treeList = new List<TreeGridModel>();
            List<ComClassEntity> list = GetAllList("0");
            list.ForEach(delegate (ComClassEntity item)
            {
                treeList.Add(new TreeGridModel()
                {
                    id = item.Sid,
                    text = item.Title,
                    parentId = item.ParentId,
                    isLeaf = true,
                    expanded = true,
                    entityJson = ApiHelper.JsonSerial(item)
                });
            });
            return treeList.TreeGridJson();
        }

        /// <summary>
        /// Get TreeGrid Child
        /// </summary>
        /// <returns></returns>
        public string GetTreeGridJson(string parentId)
        {
            List<ComClassEntity> childList = _service.GetAllChildByParentId(parentId);
            List<TreeGridModel> list = new List<TreeGridModel>();
            childList.ForEach(delegate (ComClassEntity item)
            {
                bool isChild = childList.Count(t => t.ParentId.Equals(item.Sid)) > 0 ? true : false;
                list.Add(new TreeGridModel()
                {
                    id = item.Sid,
                    isLeaf = isChild,
                    parentId = (item.ParentId.Equals(parentId) ? "0" : item.ParentId),
                    expanded = isChild,
                    entityJson = ApiHelper.JsonSerial(item)
                });
            });
            return list.TreeGridJson();
        }

        public string GetFormJson(string sid)
        {
            return ApiHelper.JsonSerial(_service.GetFormData(sid));
        }

        public string GetSelectJsonByParent(string parentId)
        {
            return ApiHelper.JsonSerial(_service.GetAllChildByParentId(parentId).Select(t => new { id = t.Sid, text = t.Title }).ToList());
        }

        public ComClassEntity SaveForm(ComClassEntity saveModel, string sid)
        {
            if (!string.IsNullOrEmpty(sid))
            {
                ComClassEntity editEntity = _service.GetFormData(sid);
                if (editEntity != null)
                {
                    saveModel.Sid = editEntity.Sid;
                    saveModel.CreateDate = editEntity.CreateDate;
                }
            }
            return _service.SaveForm(saveModel);
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

        private List<ComClassEntity> GetAllList(string parentId)
        {
            QueryRequest<ComClassEntity> request = new QueryRequest<ComClassEntity>();
            request.expression = (t => true);
            if (!string.IsNullOrEmpty(parentId))
            {
                request.expression = (t => t.ParentId.Equals(parentId));
            }

            request.Page = 1;
            request.PageSize = 10000;
            request.Sort = (t => t.Sort);
            QueryResponse<ComClassEntity> response = _service.GetPageList(request);
            return response.Items;
        }

    }
}
