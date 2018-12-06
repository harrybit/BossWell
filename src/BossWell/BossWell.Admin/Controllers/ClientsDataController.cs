using BossWell.ApiHelp;
using BossWell.Application;
using BossWell.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace BossWell.Admin.Controllers
{
    [HandlerLogin]
    public class ClientsDataController : Controller
    {
        private RoleAuthorizeApplication authorAPP = new RoleAuthorizeApplication();

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetClientsDataJson()
        {
            var adminUserModel = OperatorProvider.Provider.GetCurrent();
            if (!adminUserModel.IsSystem && string.IsNullOrEmpty(adminUserModel.RoleId))
            {
                return Content(string.Empty);
            }

            //角色菜单权限
            List<ModuleEntity> moduleList = authorAPP.GetMenuListByRoleId(adminUserModel.RoleId, Model.Enum.ModuleEnum.未知,adminUserModel.IsSystem);

            var data = new
            {
                authorizeMenu = ToMenuJson(moduleList.Where(t => t.Type == Model.Enum.ModuleEnum.模块).ToList(), "0"),
                authorizeButton = this.GetMenuButtonList(moduleList.Where(t=>t.Type == Model.Enum.ModuleEnum.按钮).ToList()),
            };

            return Content(ApiHelper.JsonSerial(data));
        }

        private string ToMenuJson(List<ModuleEntity> data, string parentId)
        {
            StringBuilder sbJson = new StringBuilder();
            sbJson.Append("[");
            List<ModuleEntity> childModuleList = data.Where(t => t.ParentId.Equals(parentId)).ToList();
            if (childModuleList.Count > 0)
            {
                foreach (ModuleEntity item in childModuleList)
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

        private object GetMenuButtonList(List<ModuleEntity> moduleBtnList)
        {
            var dataModuleId = moduleBtnList.Distinct(new ExtList<ModuleEntity>("ParentId"));
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (ModuleEntity item in dataModuleId)
            {
                var btnList = moduleBtnList.Where(t => t.ParentId.Equals(item.ParentId)).ToList();
                dictionary.Add(item.ParentId, btnList);
            }
            return dictionary;
        }
    }
}