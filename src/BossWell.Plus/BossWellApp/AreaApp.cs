using BossWellApp.Basic;
using BossWellFactory;
using BossWellModel;
using BossWellModel.BossWellModel;
using IBossWellService;
using System;
using System.Collections.Generic;
using ApiHelp;
using System.Linq;

namespace BossWellApp
{
    public class AreaApp
    {
        private readonly IAreaService _service = SysAutoFactory.GetAreaService();

        /// <summary>
        /// 获取列表树
        /// </summary>
        /// <returns></returns>
        public string GetGridTreeJson(string keyWord)
        {
            List<AreaEntity> list = _service.GetList(keyWord);
            List<TreeGridModel> gridList = new List<TreeGridModel>();
            list.ForEach(delegate (AreaEntity item)
            {
                int childCount = list.Count(t => t.ParentId.Equals(item.Sid));
                gridList.Add(new TreeGridModel()
                {
                    entityJson = ApiHelper.JsonSerial(item),
                    expanded = true,
                    id = item.Sid,
                    isLeaf = (childCount > 0 ? true : false),
                    parentId = item.ParentId,
                    text = item.FullName
                });
            });
            return gridList.TreeGridJson();
        }

        /// <summary>
        /// 获取下拉树
        /// </summary>
        /// <returns></returns>
        public string GetSelectTreeJson()
        {
            List<TreeSelectModel> selectList = new List<TreeSelectModel>();

            List<AreaEntity> list = _service.GetList();
            list.ForEach(delegate (AreaEntity item)
            {
                selectList.Add(new TreeSelectModel()
                {
                    id = item.Sid,
                    parentId = item.ParentId,
                    text = item.FullName
                });
            });
            return selectList.TreeSelectJson();
        }

        /// <summary>
        /// 获取单条记录
        /// </summary>
        /// <returns></returns>
        public string GetFromDate(string Sid)
        {
            return ApiHelper.JsonSerial(_service.FindEntity(Sid));
        }

        /// <summary>
        /// 保存表单数据
        /// </summary>
        public void SubmitForm(AreaEntity areaEntity, string sid)
        {
            if (!string.IsNullOrEmpty(sid))
            {
                AreaEntity item = _service.FindEntity(sid);
                if (item != null)
                {
                    areaEntity.Sid = item.Sid;
                    areaEntity.CreateDate = item.CreateDate;
                }
            }
            _service.SaveModel(areaEntity);
        }

        /// <summary>
        /// 删除全部子级记录
        /// </summary>
        public int DeleteForm(string sid)
        {
            List<string> allList = new List<string>();

            List<string> childList = _service.GetChildNode(sid);
            allList.Add(sid);
            if (childList.Count > 0)
            {
                allList.AddRange(GetAllChild(childList, new List<string>()));
            }
            return _service.Delete(allList);
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
                List<string> childList = _service.GetChildNode(areaSid);
                if (childList.Count < 1) { continue; }
                GetAllChild(childList, allList);
            }
            return allList;
        }
    }
}
