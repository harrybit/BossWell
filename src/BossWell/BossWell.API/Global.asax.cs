using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using BossWell.API.App_Start;

namespace BossWell.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            
            //WebApi注册
            GlobalConfiguration.Configure(WebApiConfig.Register);

            //MVC路由
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //api返回json
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
        }
    }
}
