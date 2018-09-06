using BossWellModel;
using System.Collections.Generic;

namespace IBossWellService
{
    public interface IAreaService
    {
        List<AreaEntity> GetList(string keyWord = "");

        AreaEntity FindEntity(string keyValue);

        List<string> GetChildNode(string parentId);

        int Delete(List<string> sidLst);

        AreaEntity SaveModel(AreaEntity saveModel);
    }
}