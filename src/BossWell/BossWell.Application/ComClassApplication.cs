using BossWell.Domain;
using BossWell.Interface;
using BossWell.Model;
using BossWell.Model.Other;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BossWell.Application
{
    public class ComClassApplication
    {
        IComClassService _service = SysPublicFactory.GetComClassService();

        /// <summary>
        /// 综合分类列表
        /// </summary>
        /// <param name="keyWord">模糊查询</param>
        /// <returns></returns>
        public List<ComClassEntity> GetAllComClassList(string keyWord)
        {
            QueryRequest<ComClassEntity> request = new QueryRequest<ComClassEntity>();
            keyWord = string.IsNullOrEmpty(keyWord) ? string.Empty : keyWord;
            request.Expression = (t => t.Title.Contains(keyWord) || t.Subtitle.Contains(keyWord));
            request.Page = 1;
            request.PageSize = int.MaxValue;
            request.Sort = "Sort asc";
            return _service.GetPageList(request).Items.ToList();
        }

        /// <summary>
        /// 分类单条信息
        /// </summary>
        /// <param name="sid">条目Sid</param>
        /// <returns></returns>
        public ComClassEntity GetEntityBySid(string sid)
        {
            return _service.GetSingle(sid);
        }

        /// <summary>
        /// 保存分类
        /// </summary>
        /// <param name="model">信息体</param>
        /// <returns></returns>
        public bool SubmitModule(ComClassEntity model)
        {
            //保存失败
            if (model == null) { return false; }

            if (!string.IsNullOrEmpty(model.Sid) && model.Sid.Length > 32)
            {
                ComClassEntity moduleEntity = _service.GetSingle(model.Sid);
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
        /// 分类所有子级
        /// </summary>
        /// <param name="pid">菜单Sid</param>
        /// <returns></returns>
        public List<ComClassEntity> GetComClassChildList(string pid)
        {
            return _service.GetComClassChildListBySid(pid);
        }

        /// <summary>
        /// 批量删除分类Child
        /// </summary>
        /// <param name="sid">条目Sid</param>
        /// <returns></returns>
        public bool DeleteForm(string sid)
        {
            List<string> childSid = new List<string>() { sid };
            List<ComClassEntity> childList = GetComClassChildList(sid);
            if (childList != null && childList.Count > 0)
            {
                childSid.AddRange(childList.Select(t => t.Sid).ToList());
            }
            int result = _service.DeleteFrom(childSid);
            return result > 0 ? true : false;
        }

        /// <summary>
        /// 根据父级查询一级子分类
        /// </summary>
        /// <param name="page">页码</param>
        /// <param name="pageSize">每页条目</param>
        /// <param name="parentSid">父级节点</param>
        /// <returns></returns>
        public QueryResponse<ComClassEntity> GetFirstChildByParentId(int page, int pageSize, string parentSid)
        {
            QueryRequest<ComClassEntity> request = new QueryRequest<ComClassEntity>();
            request.Expression = (t => t.ParentId.Equals(parentSid) && t.IsEnable);
            request.Page = page;
            request.PageSize = pageSize;
            request.Sort = "Sort asc";
            return _service.GetPageList(request);

        }

        /// <summary>
        /// 根据父级查询全部子级分类
        /// </summary>
        /// <param name="parentSid"></param>
        /// <returns></returns>
        public IList<ComClassTreeModel> GetAllChildByParentId(string parentSid)
        {
            List<ComClassEntity> allList = GetComClassChildList(parentSid).Where(t => t.IsEnable).ToList();

            return FuncComClassTree(allList, parentSid);//Func 查询树节点
        }

        /// <summary>
        /// Func委托 树节点查询
        /// </summary>
        /// <param name="allList">全部节点</param>
        /// <param name="Pid">父级ID</param>
        /// <returns></returns>
        private List<ComClassTreeModel> FuncComClassTree(List<ComClassEntity> allList, string Pid)
        {
            Func<string, List<ComClassTreeModel>> func = null;
            func = new Func<string, List<ComClassTreeModel>>(m =>
            {
                List<ComClassTreeModel> t = new List<ComClassTreeModel>();
                foreach (var item in allList.Where(h => h.ParentId == m.ToString()))
                {
                    var childs = func(item.Sid);
                    t.Add(new ComClassTreeModel()
                    {
                        Title = item.Title,
                        BGImages = item.BGImages,
                        Logo = item.Logo,
                        Remark = item.Remark,
                        Subtitle = item.Subtitle,
                        Child = childs
                    });
                }
                return t;
            });
            return func(Pid);
        }
    }
}
