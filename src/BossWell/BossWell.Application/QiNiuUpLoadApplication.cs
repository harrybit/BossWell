using BossWell.ApiHelp;
using BossWell.Configuration;
using BossWell.Model.Other;
using Qiniu.Common;
using Qiniu.Http;
using Qiniu.IO;
using Qiniu.IO.Model;
using Qiniu.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BossWell.Application
{
    /// <summary>
    /// 上传文件(七牛云)
    /// </summary>
    public class QiNiuUpLoadApplication
    {
        /// <summary>
        /// 七牛云上传文件(文件流)
        /// </summary>
        /// <param name="fileStream">文件流</param>
        /// <param name="fileSize">文件大小Byte</param>
        /// <param name="fileFix">文件后缀名</param>
        public static QiNiuResultModel UpLoadBySteam(Stream fileStream, int fileSize, string fileFix)
        {
            UploadManager uManager = new UploadManager();
            Mac mac = new Mac(QiNiuConfiger.AccessKey, QiNiuConfiger.SecretKey);

            HttpResult result = uManager.UploadStream(fileStream, GetFileName(fileFix), GetToken(mac));

            //上传失败
            if (result.Code != 200) return new QiNiuResultModel() { resultCode = 500, resultMsg = result.Text };

            QiNiuResult resultPicture = ApiHelper.JsonDeserial<QiNiuResult>(result.Text);

            //解析失败
            if (resultPicture == null) return new QiNiuResultModel() { resultCode = 501, resultMsg = "解析失败" };

            return new QiNiuResultModel()
            {
                resultCode =200,
                resultMsg ="Success",
                fileFix =fileFix,
                byteSize =fileSize,
                path =GetResultPath(resultPicture, mac)
            };
        }

        /// <summary>
        /// 七牛云上传文件(字节)
        /// </summary>
        /// <param name="fileByte">字节</param>
        /// <param name="fileSize">文件大小</param>
        /// <param name="fileFix">后缀名</param>
        /// <returns></returns>
        public static QiNiuResultModel UpLoadByByte(byte[] fileByte, int fileSize, string fileFix)
        {
            UploadManager uManager = new UploadManager();
            Mac mac = new Mac(QiNiuConfiger.AccessKey, QiNiuConfiger.SecretKey);

            HttpResult result = uManager.UploadData(fileByte, GetFileName(fileFix), GetToken(mac));
            //上传失败
            if (result.Code != 200) return new QiNiuResultModel() { resultCode = 500, resultMsg = result.Text };

            QiNiuResult resultPicture = ApiHelper.JsonDeserial<QiNiuResult>(result.Text);
            //解析失败
            if (resultPicture == null) return new QiNiuResultModel() { resultCode = 501, resultMsg = "解析失败" };

            return new QiNiuResultModel()
            {
                resultCode = 200,
                resultMsg = "Success",
                fileFix = fileFix,
                byteSize = fileSize,
                path = GetResultPath(resultPicture, mac)
            };
        }

        /// <summary>
        /// 解析返回上传文件地址
        /// </summary>
        /// <returns></returns>
        private static string GetResultPath(QiNiuResult resultPicture, Mac mac)
        {
            string longUnix = ApiHelper.GetTimgLongUnix(DateTime.Now.AddYears(5));
            string extPath = QiNiuConfiger.Domain + resultPicture.key
                + "?e=" + longUnix;

            string sToken = Auth.CreateDownloadToken(mac, extPath);
            extPath = extPath + "&token=" + sToken.Replace("QBox ", "");
            return extPath;
        }

        /// <summary>
        /// 生成token
        /// </summary>
        /// <returns></returns>
        private static string GetToken(Mac mac)
        {
            //机房所在华北
            Config.SetZone(ZoneID.CN_North, false);
            //上传策略
            PutPolicy putPolicy = new PutPolicy();
            //文件重命名
            putPolicy.Scope = QiNiuConfiger.Bucket;
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
        public static int CheckUpFileFixByImg(string fileName, int fileSize)
        {
            fileName = Path.GetFileName(fileName);
            string fileEx = Path.GetExtension(fileName).Replace('.', ' ').ToLower().Trim();//获取上传文件的扩展名
            int Maxsize = QiNiuConfiger.MaxImageSize * 1024 * 1000;//定义上传文件的最大空间大小为4M
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
