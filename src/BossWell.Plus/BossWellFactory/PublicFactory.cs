using BossWellService;
using IBossWellService;

namespace BossWellFactory
{
    /// <summary>
    /// 常用功能接口工厂
    /// </summary>
    public class PublicFactory
    {
        public static IClientService GetClientService()
        {
            return new ClientService();
        }

        public static IDeviceVersionService GetDeviceVersion()
        {
            return new DeviceVersionService();
        }

        public static IBannerService GetBannerService()
        {
            return new BannerService();
        }

        public static INewsService GetNewsService()
        {
            return new NewsService();
        }
    }
}