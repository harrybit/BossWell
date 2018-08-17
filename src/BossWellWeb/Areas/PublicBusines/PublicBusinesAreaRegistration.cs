using System.Web.Mvc;

namespace BossWellWeb.Areas.SystemManage
{
    public class PublicBusinesAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "PublicBusines";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
              this.AreaName + "_Default",
              this.AreaName + "/{controller}/{action}/{id}",
              new { area = this.AreaName, controller = "Home", action = "Index", id = UrlParameter.Optional },
              new string[] { "BossWellWeb.Areas." + this.AreaName + ".Controllers" }
            );
        }
    }
}
