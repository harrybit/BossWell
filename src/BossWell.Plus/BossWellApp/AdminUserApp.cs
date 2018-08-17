using BossWellFactory;
using IBossWellService;
using System;
using System.Collections.Generic;
using BossWellModel;
using BossWellModel.Base;
using BossWellApp.Basic;
using ApiHelp;
using BossWellModel.BossWellModel;

namespace BossWellApp
{
    public class AdminUserApp
    {
        private readonly IAdminUserService _service = SysAutoFactory.GetAdminUserService();
        private readonly IOrganizeService _organizeService = SysAutoFactory.GetOrganizeService();
        private readonly IRoleService _roleService = SysAutoFactory.GetRoleService();

        public string GetGridJsonList(Pagination pagination, string keyWord)
        {
            QueryRequest<AdminUserEntity> request = new QueryRequest<AdminUserEntity>();
            request.expression = (t => true);
            request.Page = pagination.page;
            request.PageSize = pagination.rows;
            request.Sort = (t => t.CreateDate);
            request.SortTp = "desc";
            if (!string.IsNullOrEmpty(keyWord))
            {
                request.expression = (t => t.Account.Contains(keyWord) || t.NickName.Contains(keyWord) || t.TelPhone.Contains(keyWord));
            }
            
            QueryResponse<AdminUserEntity> response = _service.GetList(request);

            pagination.records = response.TotalCount;
            var JObject = new
            {
                rows = response.Items,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return ApiHelper.JsonSerial(JObject);
        }
        public string GetFormJsonData(string sid)
        {
            return ApiHelper.JsonSerial(_service.GetFromData(sid));
        }
        public void SubmitForm(AdminUserEntity saveEntity, string sid)
        {
            //组织架构
            if (!string.IsNullOrEmpty(saveEntity.OrganizeSid))
            {
                saveEntity.OrganizeName = GetOrganizeName(saveEntity.OrganizeSid);
            }
            //角色
            if (!string.IsNullOrEmpty(saveEntity.RoleSid))
            {
                saveEntity.RoleName = GetRoleName(saveEntity.RoleSid);
            }

            saveEntity.PassWord = ApiHelper.MD5Encrypt(saveEntity.PassWord);
            //编辑
            if (!string.IsNullOrEmpty(sid))
            {
                AdminUserEntity item = _service.GetFromData(sid);
                if (item != null)
                {
                    saveEntity.CreateDate = item.CreateDate;
                    saveEntity.Sid = item.Sid;
                    saveEntity.PassWord = item.PassWord;
                }
            }
            _service.SubmitForm(saveEntity);
        }
        public int ResetPwd(string passWord, string sid)
        {
            return _service.ResetPwd(ApiHelper.MD5Encrypt(passWord), sid);
        }
        public int DeleteForm(string sid)
        {
            return _service.DeleteForm(sid);
        }
        public int DisEnableAccount(bool isEnable, string sid)
        {
            return _service.DisEnableAccount(isEnable, sid);
        }
        public AdminUserEntity CheckLogin(string AccountNo, string PassWord, ref int code)
        {
            AdminUserEntity entity = _service.GetFormByAccount(AccountNo, PassWord);

            //账号、密码错误
            if (entity == null) { code = 500; return null; }
            //账号已禁用
            if (!entity.IsEnable) { code = 501; return null; }

            code = 200;
            return entity;
        }

        #region Get Other
        /// <summary>
        /// 组织结构名称
        /// </summary>
        private string GetOrganizeName(string organizeSid)
        {
            OrganizeEntity organizeEntity = _organizeService.GetFormData(organizeSid);
            return organizeEntity == null ? string.Empty : organizeEntity.FullName;
        }
        /// <summary>
        /// 角色名称
        /// </summary>
        private string GetRoleName(string roleSid)
        {
            RoleEntity roleEntity = _roleService.GetFormData(roleSid);
            return roleEntity == null ? string.Empty : roleEntity.FullName;
        }
        #endregion

    }
}
