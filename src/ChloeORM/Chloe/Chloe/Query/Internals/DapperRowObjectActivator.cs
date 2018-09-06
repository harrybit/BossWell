﻿using Chloe.Mapper;
using System;
using System.Data;

namespace Chloe.Query.Internals
{
    internal class DapperRowObjectActivator : IObjectActivator
    {
        private DapperTable _table = null;

        public DapperRowObjectActivator()
        {
        }

        public object CreateInstance(IDataReader reader)
        {
            int effectiveFieldCount = reader.FieldCount;
            if (this._table == null)
            {
                string[] names = new string[effectiveFieldCount];
                for (int i = 0; i < effectiveFieldCount; i++)
                {
                    names[i] = reader.GetName(i);
                }
                this._table = new DapperTable(names);
            }

            var values = new object[effectiveFieldCount];

            reader.GetValues(values);
            for (int i = 0; i < values.Length; i++)
                if (values[i] is DBNull) values[i] = null;

            var row = new DapperRow(this._table, values);
            return row;
        }
    }
}