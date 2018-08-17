using BossWellORM;
using IBossWellService;
using BossWellModel;
using BossWellModel.Base;
using System.Collections.Generic;
using System.Threading;

namespace BossWellService
{
    public class ModuleButtonService : ChloeClient, IModuleButtonService
    {
        public QueryResponse<ModuleButtonEntity> GetList(QueryRequest<ModuleButtonEntity> request)
        {
            return Query(request);
        }
        public ModuleButtonEntity GetFormData(string sid)
        {
            return context.Query<ModuleButtonEntity>().Where(t => t.Sid.Equals(sid)).FirstOrDefault();
        }
        public ModuleButtonEntity SubmitForm(ModuleButtonEntity saveEntity)
        {
            return Save<ModuleButtonEntity>(saveEntity, "modulebutton_");
        }
        public int SubmitBatchForm(List<ModuleButtonEntity> saveList)
        {
            context.Session.BeginTransaction();
            for (int i = 0; i < saveList.Count; i++)
            {
                Thread.Sleep(100);
                Save(saveList[i], "modulebutton_");
            }
            context.Session.CommitTransaction();
            return saveList.Count;
        }
        public int DeleteForm(string sid)
        {
            return context.Delete<ModuleButtonEntity>(t => t.Sid.Equals(sid));
        }
    }
}
