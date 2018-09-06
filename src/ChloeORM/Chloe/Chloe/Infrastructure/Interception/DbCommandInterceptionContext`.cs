﻿using System;
using System.Collections.Generic;

namespace Chloe.Infrastructure.Interception
{
    public class DbCommandInterceptionContext<TResult>
    {
        private Dictionary<string, object> _dataBag = new Dictionary<string, object>();
        public TResult Result { get; set; }
        public Exception Exception { get; set; }
        public Dictionary<string, object> DataBag { get { return this._dataBag; } }
    }
}