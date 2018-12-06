using System.Web.Mvc;

namespace BossWell.Admin.Areas.SystemManage
{
    public class PubAppManageAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "PubAppManage";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
              this.AreaName + "_Default",
              this.AreaName + "/{controller}/{action}/{id}",
              new { area = this.AreaName, controller = "Home", action = "Index", id = UrlParameter.Optional },
              new string[] { "BossWell.Admin.Areas." + this.AreaName + ".Controllers" }
            );
        }
    }
}