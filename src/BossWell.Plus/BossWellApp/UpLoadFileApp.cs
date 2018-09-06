using ApiHelp;
using BossWellApp.QiNiu;
using BossWellModel;
using Cache.Base;
using Cache.Factory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using SystemConfig;

namespace BossWellApp
{
    public class UpLoadFileApp
    {
        private ICache cache = CacheFactory.CaChe();

        /// <summary>
        /// 上传文件许可证
        /// </summary>
        public void WriteLicenseKey(string GuId, string licenseKey)
        {
            //写入缓存
            cache.Write(ApiHelper.MD5Encrypt(PlatPublicConfig.PubSign + GuId, "MD5"),
                licenseKey, DateTime.Now.AddSeconds(15), CacheId.AFU_FileLicense);
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        public List<string> UpLoadFile(HttpFileCollection files, string AFU_GUID)
        {
            List<string> pathList = new List<string>();
            //批量上传七牛云
            for (int s = 0; s < files.Count; s++)
            {
                FileStorageEntity entity = new FileStorageEntity();
                //文件扩展名
                string fileName = Path.GetFileName(files[s].FileName);
                string fileEx = Path.GetExtension(fileName).Replace('.', ' ').ToLower().Trim();
                QiNiuMac.UpLoadBySteam(files[s].InputStream, files[s].ContentLength, fileEx, out entity);
                pathList.Add(entity.Path);
            }

            //移除缓存
            cache.Remove(AFU_GUID, CacheId.AFU_FileLicense);
            return pathList;
        }

        /// <summary>
        /// 效验License
        /// </summary>
        public bool CheckLicense(string AFU_GUID, string AFU_License)
        {
            string caCheLicense = cache.Read<string>(AFU_GUID, CacheId.AFU_FileLicense);

            if (string.IsNullOrEmpty(caCheLicense) || string.IsNullOrEmpty(AFU_GUID) || string.IsNullOrEmpty(AFU_License)
                || !AFU_License.Equals(caCheLicense))
            {
                return false;
            }
            return true;
        }
    }
}