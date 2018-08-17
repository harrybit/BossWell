using BossWellModel;
using Cache.Factory;
using BossWellApp.QiNiu;
using System.IO;
using ApiHelp;
using Cache.Base;
using System.Web;
namespace BossWellApp
{
    public class UpLoadFileApp
    {
        ICache cache = CacheFactory.CaChe();

        /// <summary>
        /// 上传文件许可证
        /// </summary>
        public string GetLicenseID(string accountNo)
        {
            //上传许可证
            string createLicense = ApiHelper.CreateRandom(64, 62, "AFU_");

            //Write Cache
            cache.Write<string>("AFU_File_License" + accountNo, createLicense, CacheId.AFU_FileLicense);

            return createLicense;
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        public string UpLoadFile(HttpFileCollection files, string accountNo)
        {
            HttpPostedFile postFiles = files[0];
            Stream fileStream = postFiles.InputStream;

            int fixIndex = postFiles.FileName.LastIndexOf(".");
            string fix = postFiles.FileName.Substring(fixIndex, postFiles.FileName.Length - fixIndex - 1);

            FileStorageEntity storageEntity = new FileStorageEntity();
            int code = QiNiuMac.UpLoadBySteam(fileStream, postFiles.ContentLength, fix, out storageEntity);
            if (code != 200)
            {
                return string.Empty;
            }

            cache.Remove("AFU_File_License" + accountNo, CacheId.AFU_FileLicense);

            return storageEntity.Path;
        }

        /// <summary>
        /// 效验License
        /// </summary>
        public bool CheckLicense(string accountNo, string licenseNo)
        {
            string license = cache.Read<string>("AFU_File_License" + accountNo, CacheId.AFU_FileLicense);
            if (string.IsNullOrEmpty(license) || !license.Equals(licenseNo))
            {
                return false;
            }
            return true;
        }

    }
}
