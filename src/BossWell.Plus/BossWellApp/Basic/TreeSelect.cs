using ApiHelp;
using BossWellModel.BossWellModel;
using System.Collections.Generic;
using System.Text;

namespace BossWellApp.Basic
{
    public static class TreeSelect
    {
        public static string TreeSelectJson(this List<TreeSelectModel> data)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            sb.Append(TreeSelectJson(data, "0", ""));
            sb.Append("]");
            return sb.ToString();
        }

        private static string TreeSelectJson(List<TreeSelectModel> data, string parentId, string blank)
        {
            StringBuilder textBuilder = new StringBuilder();

            IList<TreeSelectModel> ChildNodeList = data.FindAll(t => t.parentId == parentId);

            string tabline = "";
            if (parentId != "0") { tabline = "　　"; }
            if (ChildNodeList.Count > 0) { tabline = tabline + blank; }

            foreach (TreeSelectModel entity in ChildNodeList)
            {
                entity.text = tabline + entity.text;
                string strJson = ApiHelper.JsonSerial(entity);
                textBuilder.Append(strJson);
                textBuilder.Append(TreeSelectJson(data, entity.id, tabline));
            }
            return textBuilder.ToString().Replace("}{", "},{");
        }
    }
}