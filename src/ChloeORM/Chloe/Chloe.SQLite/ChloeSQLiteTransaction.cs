using System;
using System.Data;

namespace Chloe.SQLite
{
    internal class ChloeSQLiteTransaction : IDbTransaction
    {
        private IDbTransaction _transaction;
        private ChloeSQLiteConcurrentConnection _conn;
        private bool _hasFinished = false;

        public ChloeSQLiteTransaction(IDbTransaction transaction, ChloeSQLiteConcurrentConnection conn)
        {
            this._transaction = transaction;
            this._conn = conn;

            this._conn.RWLock.BeginTransaction();
        }

        ~ChloeSQLiteTransaction()
        {
            this.Dispose();
        }

        public IDbTransaction InnerTransaction { get { return this._transaction; } }

        private void EndTransaction()
        {
            if (this._hasFinished == false)
            {
                this._conn.RWLock.EndTransaction();
                this._hasFinished = true;
            }
        }

        public IDbConnection Connection { get { return this._transaction.Connection; } }
        public IsolationLevel IsolationLevel { get { return this._transaction.IsolationLevel; } }

        public void Commit()
        {
            try
            {
                this._transaction.Commit();
            }
            finally
            {
                this.EndTransaction();
            }
        }

        public void Rollback()
        {
            try
            {
                this._transaction.Rollback();
            }
            finally
            {
                this.EndTransaction();
            }
        }

        public void Dispose()
        {
            this._transaction.Dispose();
            this.EndTransaction();
            GC.SuppressFinalize(this);
        }
    }
}