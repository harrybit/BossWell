﻿using BossWellService;
using IBossWellService;
using BossWellORM;
namespace BossWellFactory
{
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