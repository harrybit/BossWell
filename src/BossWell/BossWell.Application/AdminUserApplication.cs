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
    public class AdminUserApplication
    {
        IAdminUserService _service = SysAuthFactory.GetAdminUserService();
        IRoleService _roleService = SysAuthFactory.GetRoleService();

        /// <summary>
        /// 后台管理员分页列表
        /// </summary>
        /// <param name="pagination">分页模型</param>
        /// <param name="keyWord">模糊查询</param>
        /// <returns></returns>
        public List<AdminUserEntity> GetList(Pagination pagination, string keyWord)
        {
            QueryRequest<AdminUserEntity> request = new QueryRequest<AdminUserEntity>();
            request.Expression = t => string.IsNullOrEmpty(keyWord) ? true : (t.NickName.Contains(keyWord) || t.TelPhone.Contains(keyWord) || t.Account.Contains(keyWord));
            request.Page = pagination.page;
            request.PageSize = pagination.rows;
            request.Sort = "Sort asc";
            QueryResponse<AdminUserEntity> response = _service.GetPageList(request);
            pagination.records = response.TotalCount;
            return response.Items.ToList();

        }

        /// <summary>
        /// 管理员单条信息
        /// </summary>
        /// <param name="sid">条目Sid</param>
        /// <returns></returns>
        public AdminUserEntity GetEntityBySid(string sid)
        {
            return _service.GetSingle(sid);
        }

        /// <summary>
        /// 保存管理员
        /// </summary>
        /// <param name="model">信息体</param>
        /// <returns></returns>
        public bool SubmitAdminUser(AdminUserEntity model)
        {
            //保存失败
            if (model == null) { return false; }
            if (!string.IsNullOrEmpty(model.RoleSid))
            {
                RoleEntity roleEntity = _roleService.GetSingle(model.RoleSid);
                model.RoleName = roleEntity == null ? string.Empty : roleEntity.FullName;
            }
            if (string.IsNullOrEmpty(model.Sid)) model.PassWord = ApiHelper.MD5Encrypt(model.PassWord, "MD5");

            if (!string.IsNullOrEmpty(model.Sid) && model.Sid.Length > 32)
            {
                AdminUserEntity adminEntity = _service.GetSingle(model.Sid);
                if (adminEntity != null)
                {
                    model.CreateDate = adminEntity.CreateDate;
                    model.EditDate = DateTime.Now;
                    model.IsDelete = adminEntity.IsDelete;
                    model.Sid = adminEntity.Sid;
                }
            }
            _service.SaveFrom(model);
            return true;
        }

        /// <summary>
        /// 删除管理员
        /// </summary>
        /// <param name="sid">条目Sid</param>
        /// <returns></returns>
        public bool DeleteForm(string sid)
        {
            int result = _service.DeleteFrom(sid);
            return result > 0 ? true : false;
        }

        /// <summary>
        /// 效验后台管理员登录
        /// </summary>
        /// <param name="accountNo"></param>
        /// <param name="passWord"></param>
        /// <returns></returns>
        public AdminUserEntity CheckAdminLoginState(string accountNo, string passWord)
        {
            QueryRequest<AdminUserEntity> request = new QueryRequest<AdminUserEntity>();
            request.Expression = (t => t.Account.Equals(accountNo) && t.PassWord.Equals(passWord) && t.IsEnable);
            request.Page = 1;
            request.PageSize = 1;
            return _service.GetPageList(request).Items.FirstOrDefault();
        }

        /// <summary>
        /// 重置管理员登录密码
        /// </summary>
        /// <param name="adminUserSid">管理员Sid</param>
        /// <param name="passWord">密码</param>
        /// <returns></returns>
        public bool SubmitAdminUserResetPassWord(string adminUserSid, string passWord)
        {
            passWord = ApiHelper.MD5Encrypt(passWord, "MD5");
            AdminUserEntity adminEntity = GetEntityBySid(adminUserSid);
            if (adminEntity == null) return false;
            adminEntity.PassWord = passWord;
            _service.SaveFrom(adminEntity);
            return true;
        }

    }
}
