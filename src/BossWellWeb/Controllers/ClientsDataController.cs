using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using ApiHelp;
using BossWellApp;
using BossWellModel;
using BossWellApp.Basic;
namespace BossWellWeb.Controllers
{
    [HandlerLogin]
    public class ClientsDataController : Controller
    {
        ModuleApp moduleAPP = new ModuleApp();
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetClientsDataJson()
        {
            var data = new
            {
                dataItems = this.GetDataItemList(),
                organize = this.GetOrganizeList(),
                role = this.GetRoleList(),
                duty = this.GetDutyList(),
                user = "",
                authorizeMenu = this.GetMenuList(),
                authorizeButton = this.GetMenuButtonList(),
            };
            return Content(ApiHelper.JsonSerial(data));
        }
        private object GetDataItemList()
        {
            return null;
        }
        private object GetOrganizeList()
        {
            return null;
        }
        private object GetRoleList()
        {
            return null;
        }
        private object GetDutyList()
        {
            return null;
        }
        private object GetMenuList()
        {

            string roleId = OperatorProvider.Provider.GetCurrent().RoleId;
            return ToMenuJson(moduleAPP.GetModuleMenuByRole(roleId), "0");
        }
        private string ToMenuJson(List<ModuleEntity> data, string parentId)
        {
            StringBuilder sbJson = new StringBuilder();
            sbJson.Append("[");
            List<ModuleEntity> entitys = data.FindAll(t => t.ParentId == parentId);
            if (entitys.Count > 0)
            {
                foreach (var item in entitys)
                {
                    string strJson = ApiHelper.JsonSerial(item);
                    strJson = strJson.Insert(strJson.Length - 1, ",\"ChildNodes\":" + ToMenuJson(data, item.Sid) + "");
                    sbJson.Append(strJson + ",");
                }
                sbJson = sbJson.Remove(sbJson.Length - 1, 1);
            }
            sbJson.Append("]");
            return sbJson.ToString();
        }
        private object GetMenuButtonList()
        {
            var roleId = OperatorProvider.Provider.GetCurrent().RoleId;
            Dictionary<string, object> dicItem = new Dictionary<string, object>();

            var moduleList = moduleAPP.GetModuleButtonByRole(roleId);
            var moduleIDList = moduleList.Distinct(new ExtList<ModuleButtonEntity>("ModuleSid"));
            
            foreach (ModuleButtonEntity item in moduleIDList)
            {
                var buttonList = moduleList.Where(t => t.ModuleSid.Equals(item.ModuleSid));
                dicItem.Add(item.ModuleSid, buttonList);
            }

            return dicItem;
        }
    }
}
