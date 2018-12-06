using System.Collections.Generic;
using Hangfire.Dashboard;

namespace BossWell.API.App_Start
{
    public class DontUseThisAuthorizationFilter:IAuthorizationFilter
    {
        public bool Authorize(IDictionary<string, object> owinEnvironment)
        {
            return true;
        }
    }
}