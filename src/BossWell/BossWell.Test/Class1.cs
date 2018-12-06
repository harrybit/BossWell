using BossWell.ApiHelp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace BossWell.Test
{
    [TestClass]
    public class Class1
    {
        [TestMethod]
        public void Excule()
        {
            //AdminUserApplication application = new AdminUserApplication();
            //var a = application.GetList();
            string psd = ApiHelper.MD5Encrypt("123456", "MD5");

        }

    }
}
