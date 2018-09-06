using BossWellModel;
using BossWellModel.Base;
using Chloe;
using Chloe.MySql;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace BossWellORM
{
    public class ChloeClient : IDisposable
    {
        public readonly MySqlContext context;

        public ChloeClient()
        {
            lock (this)
            {
                if (context == null)
                {
                    context = new MySqlContext(new MySqlConnectionFactory(DBHelperConnect.ConnectionString));
                }
            }
        }

        public virtual QueryResponse<T> Query<T>(QueryRequest<T> request)
        {
            QueryResponse<T> response = new QueryResponse<T>();

            var query = context.Query<T>().Where(request.expression);
            query = string.IsNullOrEmpty(request.SortTp) ? query.OrderBy(request.Sort) : query.OrderByDesc(request.Sort);
            response.TotalCount = query.Count();//总页码

            request.Page = request.Page < 1 ? 1 : request.Page;
            request.PageSize = request.PageSize < 1 ? 20 : request.PageSize;
            response.Items = query.Skip((request.Page - 1) * request.PageSize).Take(request.PageSize).ToList();

            return response;
        }

        public virtual T Sing<T>(Expression<Func<T, bool>> expression)
        {
            return context.Query<T>().Where(expression).FirstOrDefault();
        }

        public virtual QueryResponse<T> QuerySkipSql<T>(string sql, DbParam[] param, int page = 1, int pageSize = 20)
        {
            QueryResponse<T> response = new QueryResponse<T>();

            var query = context.SqlQuery<T>(sql, param);
            response.TotalCount = query.Count();
            response.Items = query.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return response;
        }

        public virtual T Save<T>(T saveModel, string tit = "") where T : BaseEntity
        {
            T model;
            if (string.IsNullOrEmpty(saveModel.Sid) || saveModel.Sid.Length < 16)
            {
                saveModel.Sid = ApiHelp.ApiHelper.CreateRandomString(32, tit);
                saveModel.CreateDate = DateTime.Now;
                model = context.Insert<T>(saveModel);
            }
            else
            {
                context.Update<T>(saveModel);
                model = saveModel;
            }
            return model;
        }

        public void Dispose()
        {
            this.context.Dispose();
        }
    }
}