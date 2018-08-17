using System.Web.Http;
using System.Web.Mvc;
namespace BossWellApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //HelpPage
            AreaRegistration.RegisterAllAreas();
            //api返回json
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
        }
    }
}
