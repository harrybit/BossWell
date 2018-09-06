using ApiHelp;
using BossWellModel;
using BossWellModel.Plus;
using Qiniu.Common;
using Qiniu.Http;
using Qiniu.IO;
using Qiniu.IO.Model;
using Qiniu.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SystemConfig;

namespace BossWellApp.QiNiu
{
    public class QiNiuMac
    {
        /// <summary>
        /// 上传文件流到七牛云服务器
        /// </summary>
        /// <param name="fileStream">文件流</param>
        /// <param name="fileSize">文件大小Byte</param>
        /// <param name="fileFix">文件后缀名</param>
        public static int UpLoadBySteam(Stream fileStream, int fileSize, string fileFix, out FileStorageEntity entity)
        {
            UploadManager uManager = new UploadManager();
            Mac mac = new Mac(QiNiuConfig.AccessKey, QiNiuConfig.SecretKey);

            HttpResult result = uManager.UploadStream(fileStream, GetFileName(fileFix), GetToken(mac));
            //上传失败
            if (result.Code != 200) { entity = null; return 503; }

            ResultQiNiu resultPicture = ApiHelper.JsonDeserial<ResultQiNiu>(result.Text);
            //解析失败
            if (resultPicture == null) { entity = null; return 504; }

            //返回上传文件详细信息
            entity = new FileStorageEntity()
            {
                Sid = ApiHelper.CreateRandomString(32, "filestorage_"),
                CreateDate = DateTime.Now,
                CreateUser = "APP",
                FileSize = fileSize,
                FileType = fileFix,
                Path = GetResultPath(resultPicture, mac),
                Remark = "七牛云上传_文件流"
            };
            return 200;
        }

        /// <summary>
        /// 上传字节到七牛云服务器
        /// </summary>
        public static int UpLoadByByte(byte[] fileByte, int fileSize, string fileFix, out FileStorageEntity entity)
        {
            UploadManager uManager = new UploadManager();
            Mac mac = new Mac(QiNiuConfig.AccessKey, QiNiuConfig.SecretKey);

            HttpResult result = uManager.UploadData(fileByte, GetFileName(fileFix), GetToken(mac));
            //上传失败
            if (result.Code != 200) { entity = null; return 503; }

            ResultQiNiu resultPicture = ApiHelper.JsonDeserial<ResultQiNiu>(result.Text);
            //解析失败
            if (resultPicture == null) { entity = null; return 504; }

            //返回上传文件详细信息
            entity = new FileStorageEntity()
            {
                Sid = ApiHelper.CreateRandomString(32, "filestorage_"),
                CreateDate = DateTime.Now,
                CreateUser = "APP",
                FileSize = fileSize,
                FileType = fileFix,
                Path = GetResultPath(resultPicture, mac),
                Remark = "七牛云上传_字节"
            };
            return 200;
        }

        /// <summary>
        /// 解析返回上传文件地址
        /// </summary>
        /// <returns></returns>
        private static string GetResultPath(ResultQiNiu resultPicture, Mac mac)
        {
            string longUnix = ApiHelper.GetTimgLongUnix(DateTime.Now.AddYears(5));
            string extPath = QiNiuConfig.Domain + resultPicture.key
                + "?e=" + longUnix;

            string sToken = Auth.CreateDownloadToken(mac, extPath);
            extPath = extPath + "&token=" + sToken.Replace("QBox ", "");
            return extPath;
        }

        /// <summary>
        /// 创建token
        /// </summary>
        /// <returns></returns>
        private static string GetToken(Mac mac)
        {
            //机房所在华北
            Config.SetZone(ZoneID.CN_North, false);
            //上传策略
            PutPolicy putPolicy = new PutPolicy();
            //文件重命名
            putPolicy.Scope = QiNiuConfig.Bucket;
            //策略有效期
            putPolicy.SetExpires(3600);
            //云端存储时间,单位：天
            //putPolicy.DeleteAfterDays = 1;
            string Json = ApiHelper.JsonSerial(putPolicy);
            string token = Auth.CreateUploadToken(mac, Json);
            return token;
        }

        /// <summary>
        /// 拼接上传文件名
        /// </summary>
        /// <returns></returns>
        private static string GetFileName(string fileFix)
        {
            StringBuilder textBuilder = new StringBuilder();
            textBuilder.Append(ApiHelper.CreateRandomString(32, string.Empty));
            textBuilder.Append("." + fileFix.ToLower());
            return textBuilder.ToString();
        }

        /// <summary>
        /// 效验图片文件格式
        /// </summary>
        /// <param name="postFiles">上传文件对象</param>
        /// <returns></returns>
        public static int CheckFileFormatByImage(string fileName, int fileSize)
        {
            fileName = Path.GetFileName(fileName);
            string fileEx = Path.GetExtension(fileName).Replace('.', ' ').ToLower().Trim();//获取上传文件的扩展名
            int Maxsize = QiNiuConfig.MaxImageSize * 1024 * 1000;//定义上传文件的最大空间大小为4M
            List<string> fileTypeList = new List<string>() { "bmp", "gif", "jpg", "jpeg", "png", "swf" };

            //效验图片格式
            if (!fileTypeList.Contains(fileEx))
            {
                return 501;
            }
            //效验文件大小
            if (fileSize >= Maxsize)
            {
                return 502;
            }
            return 200;
        }
    }
}