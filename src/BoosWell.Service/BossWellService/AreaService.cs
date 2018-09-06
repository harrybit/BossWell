using BossWellModel;
using BossWellORM;
using IBossWellService;
using System.Collections.Generic;

namespace BossWellService
{
    public class AreaService : ChloeClient, IAreaService
    {
        public List<AreaEntity> GetList(string keyWord = "")
        {
            keyWord = string.IsNullOrEmpty(keyWord) ? string.Empty : keyWord;
            return context.Query<AreaEntity>().Where(t => t.FullName.Contains(keyWord)).ToList();
        }

        public AreaEntity FindEntity(string sid)
        {
            return context.Query<AreaEntity>().Where(t => t.Sid.Equals(sid)).FirstOrDefault();
        }

        public List<string> GetChildNode(string parentId)
        {
            return context.Query<AreaEntity>().Where(t => t.ParentId.Equals(parentId)).Select(t => t.Sid).ToList();
        }

        public AreaEntity SaveModel(AreaEntity saveModel)
        {
            return Save(saveModel, "area_");
        }

        public int Delete(List<string> sidLst)
        {
            return context.Delete<AreaEntity>(t => sidLst.Contains(t.Sid));
        }
    }
}