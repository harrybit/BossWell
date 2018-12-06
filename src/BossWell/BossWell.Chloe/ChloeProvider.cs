using BossWell.Configuration;
using BossWell.Model;
using Chloe;
using Chloe.MySql;
using System;
using System.Linq.Expressions;

namespace BossWell.Chloe
{
    public abstract class ChloeProvider :IDisposable
    {
        protected readonly MySqlContext _context;
        private readonly object lockObj = new object();

        public ChloeProvider()
        {
            if (_context == null)
            {
                lock (lockObj)
                {
                    if (_context == null)
                    {
                        _context = new MySqlContext(new MySqlConnectionFactory(MySqlConfiger.ConnectionString));
                    }
                }
            }
        }

        public virtual QueryResponse<T> Query<T>(QueryRequest<T> request)
        {
            QueryResponse<T> response = new QueryResponse<T>();
            if (string.IsNullOrEmpty(request.Sort)) request.Sort = "CreateDate desc";
            var query = this._context.Query<T>().Where(request.Expression).OrderBy(request.Sort);
            response.TotalCount = query.Count();
            response.Items = query.TakePage(request.Page, request.PageSize).ToList();
            return response;
        }

        public virtual T QuerySing<T>(Expression<Func<T, bool>> expression)
        {
            return this._context.Query<T>().Where(expression).FirstOrDefault();
        }

        public virtual T Save<T>(T saveModel, string tit = "") where T : BaseEntity
        {
            T model;
            if (string.IsNullOrEmpty(saveModel.Sid))
            {
                saveModel.Sid = tit + Guid.NewGuid().ToString("N");
                saveModel.CreateDate = DateTime.Now;
                saveModel.IsDelete = false;
                model = this._context.Insert(saveModel);
            }
            else
            {
                this._context.Update(saveModel);
                model = saveModel;
            }
            return model;
        }

        public void Dispose()
        {
            this._context.Dispose();
        }

    }
}