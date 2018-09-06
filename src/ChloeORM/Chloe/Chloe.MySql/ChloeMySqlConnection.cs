﻿using System;
using System.Data;

namespace Chloe.MySql
{
    public class ChloeMySqlConnection : IDbConnection, IDisposable
    {
        private IDbConnection _dbConnection;

        public ChloeMySqlConnection(IDbConnection dbConnection)
        {
            Utils.CheckNull(dbConnection);
            this._dbConnection = dbConnection;
        }

        public IDbConnection InnerDbConnection { get { return this._dbConnection; } }

        public string ConnectionString
        {
            get { return this._dbConnection.ConnectionString; }
            set { this._dbConnection.ConnectionString = value; }
        }

        public int ConnectionTimeout
        {
            get { return this._dbConnection.ConnectionTimeout; }
        }

        public string Database
        {
            get { return this._dbConnection.Database; }
        }

        public ConnectionState State
        {
            get { return this._dbConnection.State; }
        }

        public IDbTransaction BeginTransaction()
        {
            return this._dbConnection.BeginTransaction();
        }

        public IDbTransaction BeginTransaction(IsolationLevel il)
        {
            return this._dbConnection.BeginTransaction(il);
        }

        public void ChangeDatabase(string databaseName)
        {
            this._dbConnection.ChangeDatabase(databaseName);
        }

        public void Close()
        {
            this._dbConnection.Close();
        }

        public IDbCommand CreateCommand()
        {
            return new ChloeMySqlCommand(this._dbConnection.CreateCommand());
        }

        public void Open()
        {
            this._dbConnection.Open();
        }

        public void Dispose()
        {
            this._dbConnection.Dispose();
        }
    }
}