using BossWellModel.BossWellModel;
using System.Collections.Generic;
using System.Text;

namespace BossWellApp.Basic
{
    public static class TreeGrid
    {
        public static string TreeGridJson(this List<TreeGridModel> data)
        {
            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append("{ \"rows\": [");
            jsonBuilder.Append(TreeGridJson(data, -1, "0"));
            jsonBuilder.Append("]}");
            return jsonBuilder.ToString();
        }
        private static string TreeGridJson(List<TreeGridModel> data, int index, string parentId)
        {
            StringBuilder textBuilder = new StringBuilder();

            var ChildNodeList = data.FindAll(t => t.parentId == parentId);
            if (ChildNodeList.Count > 0) { index++; }

            foreach (TreeGridModel entity in ChildNodeList)
            {
                string strJson = entity.entityJson;
                strJson = strJson.Insert(1, "\"loaded\":" + (entity.loaded == true ? false : true).ToString().ToLower() + ",");
                strJson = strJson.Insert(1, "\"expanded\":" + (entity.expanded).ToString().ToLower() + ",");
                strJson = strJson.Insert(1, "\"isLeaf\":" + (entity.isLeaf == true ? false : true).ToString().ToLower() + ",");
                strJson = strJson.Insert(1, "\"parent\":\"" + parentId + "\",");
                strJson = strJson.Insert(1, "\"level\":" + index + ",");
                textBuilder.Append(strJson);
                textBuilder.Append(TreeGridJson(data, index, entity.id));
            }
            return textBuilder.ToString().Replace("}{", "},{");
        }
    }
}
