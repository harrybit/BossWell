﻿using System;
using System.Data;

namespace Chloe.Mapper
{
    public class ComplexMemberBinder : IValueSetter
    {
        private Action<object, object> _setter;
        private IObjectActivator _activtor;

        public ComplexMemberBinder(Action<object, object> setter, IObjectActivator activtor)
        {
            this._setter = setter;
            this._activtor = activtor;
        }

        public void SetValue(object obj, IDataReader reader)
        {
            object val = this._activtor.CreateInstance(reader);
            this._setter(obj, val);
        }
    }
}