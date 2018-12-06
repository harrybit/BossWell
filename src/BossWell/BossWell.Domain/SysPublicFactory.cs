using BossWell.Interface;
using BossWell.Service;
namespace BossWell.Domain
{
    /// <summary>
    /// 公共模块
    /// </summary>
    public class SysPublicFactory
    {
        /// <summary>
        /// 综合分类
        /// </summary>
        /// <returns></returns>
        public static IComClassService GetComClassService()
        {
            return new ComClassService();
        }

        /// <summary>
        /// 参数配置
        /// </summary>
        /// <returns></returns>
        public static ISysConfigService GetSysConfigService()
        {
            return new SysConfigService();
        }

        /// <summary>
        /// 行政地区
        /// </summary>
        /// <returns></returns>
        public static IAreaService GetAreaService()
        {
            return new AreaService();
        }

        /// <summary>
        /// 轮播图
        /// </summary>
        /// <returns></returns>
        public static IBannerService GetBannerService()
        {
            return new BannerService();
        }

        /// <summary>
        /// 客户会员
        /// </summary>
        /// <returns></returns>
        public static IClientService GetCltService()
        {
            return new ClientService();
        }


    }
}
