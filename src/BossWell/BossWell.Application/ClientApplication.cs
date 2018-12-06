using BossWell.ApiHelp;
using BossWell.Domain;
using BossWell.Interface;
using BossWell.Model;
using BossWell.Model.Basic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BossWell.Application
{
    public class ClientApplication
    {
        IClientService _service = SysPublicFactory.GetCltService();
        IComClassService _comService = SysPublicFactory.GetComClassService();
        /// <summary>
        /// 客户会员后台分页
        /// </summary>
        /// <param name="keyWord">模糊查询</param>
        /// <returns></returns>
        public List<ClientEntity> GetCltPageList(Pagination pagination, string keyWord)
        {
            QueryRequest<ClientEntity> request = new QueryRequest<ClientEntity>();
            keyWord = string.IsNullOrEmpty(keyWord) ? string.Empty : keyWord;
            request.Expression = (t => t.AccountNo.Contains(keyWord) || t.NickName.Contains(keyWord) || t.Mobile.Contains(keyWord));
            request.Page = pagination.page;
            request.PageSize = pagination.rows;
            request.Sort = "CreateDate desc";
            QueryResponse<ClientEntity> response = _service.GetPageList(request);
            pagination.records = response.TotalCount;
            return response.Items.ToList();
        }

        /// <summary>
        /// 会员单条信息
        /// </summary>
        /// <param name="sid">条目Sid</param>
        /// <returns></returns>
        public ClientEntity GetEntityBySid(string sid)
        {
            return _service.GetSingle(sid);
        }

        /// <summary>
        /// 保存会员信息
        /// </summary>
        /// <param name="model">信息体</param>
        /// <returns></returns>
        public bool SubmitModule(ClientEntity model)
        {
            //保存失败
            if (model == null) { return false; }

            if (!string.IsNullOrEmpty(model.RoleID))
            {
                ComClassEntity comEntity = _comService.GetSingle(model.RoleID);
                model.Role = comEntity == null ? String.Empty : comEntity.Title;
            }

            if (!string.IsNullOrEmpty(model.Sid) && model.Sid.Length >= 32)
            {
                ClientEntity moduleEntity = _service.GetSingle(model.Sid);
                if (moduleEntity != null)
                {
                    model.CreateDate = moduleEntity.CreateDate;
                    model.EditDate = DateTime.Now;
                    model.IsDelete = moduleEntity.IsDelete;
                }
            }
            else
            {
                model.AccountNo = ApiHelper.CreateRandom(10, 10, string.Empty);
                model.SpreadCode = ApiHelper.CreateRandom(6, 10, string.Empty);
                model.Token = ApiHelper.MD5Encrypt(model.AccountNo + DateTime.Now.ToLongTimeString() + model.SpreadCode);
                model.PassWord = ApiHelper.MD5Encrypt(model.PassWord, "MD5");
            }
            _service.SaveFrom(model);
            return true;
        }

        /// <summary>
        /// 删除会员记录
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
