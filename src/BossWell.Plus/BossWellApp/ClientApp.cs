using ApiHelp;
using BossWellFactory;
using BossWellModel;
using BossWellModel.Base;
using BossWellModel.BossWellModel;
using IBossWellService;
using System;
using System.Collections.Generic;

namespace BossWellApp
{
    public class ClientApp
    {
        private IClientService _service = PublicFactory.GetClientService();
        private IComClassService _comService = SysAutoFactory.GetComClassService();

        #region 后台管理

        public string GetGridJson(Pagination pagination, string keyword)
        {
            List<ClientEntity> list = GetPageList(pagination, keyword);
            var data = new
            {
                rows = list,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return ApiHelper.JsonSerial(data);
        }

        public string GetFormJson(string sid)
        {
            ClientEntity cltEntity = _service.GetFormJson(sid);
            var data = new { model = cltEntity, Birthday = cltEntity.Birthday.ToString("yyyy-MM-dd HH:mm:ss") };
            return ApiHelper.JsonSerial(data);
        }

        public ClientEntity SubmitForm(ClientEntity cltEntity, string sid)
        {
            if (!string.IsNullOrEmpty(cltEntity.RoleID))
            {
                ComClassEntity comEntity = _comService.GetFormData(cltEntity.RoleID);
                cltEntity.Role = (comEntity == null ? string.Empty : comEntity.Title);
            }
            if (!string.IsNullOrEmpty(sid))
            {
                ClientEntity editEntity = _service.GetFormJson(sid);
                if (editEntity != null)
                {
                    cltEntity.Sid = editEntity.Sid;
                    cltEntity.CreateDate = editEntity.CreateDate;
                    cltEntity.SpreadCode = editEntity.SpreadCode;
                    cltEntity.Token = editEntity.Token;
                }
            }
            else
            {
                cltEntity.AccountNo = ApiHelper.CreateRandom(16, 10, string.Empty);
                cltEntity.Token = ApiHelper.SHA256(cltEntity.AccountNo + "-" + ApiHelper.GetTimgLongUnix(DateTime.Now, 1));
                cltEntity.PassWord = ApiHelper.MD5Encrypt(cltEntity.PassWord);
                cltEntity.SpreadCode = ApiHelper.CreateRandomString(6);
            }
            return _service.SaveFormJson(cltEntity);
        }

        public int DeleteForm(string sid)
        {
            return _service.DeleteForm(sid);
        }

        private List<ClientEntity> GetPageList(Pagination pagination, string keyword)
        {
            QueryRequest<ClientEntity> request = new QueryRequest<ClientEntity>();
            request.expression = (t => t.NickName.Contains(keyword) || t.AccountNo.Contains(keyword) || t.Mobile.Contains(keyword));
            request.Page = pagination.page;
            request.PageSize = pagination.rows;
            request.Sort = (t => t.CreateDate);
            request.SortTp = "desc";
            QueryResponse<ClientEntity> response = _service.GetPageList(request);
            pagination.records = response.TotalCount;
            return response.Items;
        }

        #endregion 后台管理

        #region API

        public ClientEntity GetCltEntityByToken(string token)
        {
            return _service.GetEntityByToken(token);
        }

        public ClientEntity GetEntityByAccount(string accountNo)
        {
            return _service.GetEntityByAccount(accountNo);
        }

        public List<ClientEntity> GetPageList(int page, int PageSize)
        {
            return GetPageList(new Pagination()
            {
                page = page,
                rows = PageSize
            }, string.Empty);
        }

        public ClientEntity Register(RegisterModel model)
        {
            ClientEntity isInEntity = _service.GetEntityByAccount(model.Account);
            if (isInEntity != null)
            {
                return null;
            }
            string AccountNo = ApiHelper.CreateRandom(16, 10, string.Empty);
            string Token = ApiHelper.SHA256(AccountNo + "-" + ApiHelper.GetTimgLongUnix(DateTime.Now, 1));
            string PassWord = ApiHelper.MD5Encrypt(model.PassWord);
            return _service.SaveFormJson(new ClientEntity()
            {
                AccountNo = AccountNo,
                Token = Token,
                PassWord = PassWord,
                Mobile = model.Account
            });
        }

        public ClientEntity GetLoginEntity(string accountNo, string passWord)
        {
            ClientEntity cltModel = _service.GetLoginEntity(accountNo, ApiHelper.MD5Encrypt(passWord));
            if (cltModel != null)
            {
                string Token = ApiHelper.SHA256(cltModel.AccountNo + "-" + ApiHelper.GetTimgLongUnix(DateTime.Now, 1));
                _service.ModifyCltToken(cltModel.AccountNo, Token);
            }
            return cltModel;
        }

        #endregion API
    }
}