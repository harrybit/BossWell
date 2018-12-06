using BossWell.Chloe;
using BossWell.Interface;
using BossWell.Model;
using System;
using System.Collections.Generic;

namespace BossWell.Service
{
    /// <summary>
    /// 管理员角色
    /// </summary>
    public class RoleService : ChloeProvider, IRoleService
    {
        public QueryResponse<RoleEntity> GetPageList(QueryRequest<RoleEntity> request)
        {
            return Query<RoleEntity>(request);
        }

        public RoleEntity GetSingle(string sid)
        {
            return QuerySing<RoleEntity>(t => t.Sid.Equals(sid));
        }

        public RoleEntity SaveFrom(RoleEntity saveModel, List<RoleAuthorizeEntity> authList)
        {
            RoleEntity roleEntity = new RoleEntity();
            try
            {
                _context.Session.BeginTransaction();

                //保存角色信息
                roleEntity = Save(saveModel, "role_");

                //清除历史权限
                _context.Delete<RoleAuthorizeEntity>(t => t.RoleId.Equals(roleEntity.Sid));
                
                //替换权限归属
                authList.ForEach(t => { t.RoleId = roleEntity.Sid; });

                //批量添加权限
                _context.InsertRange(authList);

                _context.Session.CommitTransaction();
            }
            catch (Exception ex)
            {
                return null;
            }
            return roleEntity;
        }

        public int DeleteFrom(string sid)
        {
            int result = 0;
            try
            {
                _context.Session.BeginTransaction();
                result = _context.Delete<RoleAuthorizeEntity>(t => t.RoleId.Equals(sid));
                _context.Delete<RoleEntity>(t => t.Sid.Equals(sid));
                _context.Session.CommitTransaction();
            }
            catch (Exception ex)
            {
                result = -1;
            }
            return result;
        }
    }
}
