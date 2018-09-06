using Hangfire.Dashboard;
using System.Collections.Generic;

namespace BossWellApi
{
    public class DontUseThisAuthorizationFilter : IAuthorizationFilter
    {
        public bool Authorize(IDictionary<string, object> owinEnvironment)
        {
            return true;
        }
    }
}