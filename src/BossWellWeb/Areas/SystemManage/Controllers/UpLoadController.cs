using ApiHelp;
using BossWellApp.QiNiu;
using BossWellModel;
using BossWellModel.BossWellModel;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
namespace BossWellWeb.Areas.SystemManage.Controllers
{
    /// <summary>
    /// 上传文件控制
    /// </summary>
    public class UpLoadController : ControllerBase
    {
        /// <summary>
        /// 上传图片
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpLoadImage()
        {
            HttpFileCollectionBase files = HttpContext.Request.Files;
            if (files == null || files[0] == null) { return Success("请选择上传文件"); }
            HttpPostedFileBase file = files[0];
            //效验图片格式
            int code = QiNiuMac.CheckFileFormatByImage(file.FileName, file.ContentLength);
            if (code == 501)
            {
                return Success("Picture Format Error");
            }
            else if (code == 502)
            {
                return Success("Size Beyond The Limit");
            }

            FileStorageEntity entity = new FileStorageEntity();
            code = QiNiuMac.UpLoadBySteam(file.InputStream, file.ContentLength, "PNG", out entity);
            if (code == 504) { return Success("Analysis Error"); }
            else if (code == 503) { return Success("UpLoad Fail"); }

            return Content(ApiHelper.JsonSerial(new WangEditorUpLoadModel() { errno = 0, data = new List<string>() { entity.Path } }));
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpLoadFile()
        {
            HttpFileCollectionBase files = HttpContext.Request.Files;
            if (files == null || files[0] == null) { return Success("请选择上传文件"); }
            HttpPostedFileBase file = files[0];

            int fixIndex = file.FileName.LastIndexOf(".");
            string fix = file.FileName.Substring(fixIndex, file.FileName.Length - fixIndex - 1);

            FileStorageEntity entity = new FileStorageEntity();
            int code = QiNiuMac.UpLoadBySteam(file.InputStream, file.ContentLength, fix, out entity);
            if (code == 504) { return Success("Analysis Error"); }
            else if (code == 503) { return Success("UpLoad Fail"); }

            return Content(ApiHelper.JsonSerial(new WangEditorUpLoadModel() { errno = 0, data = new List<string>() { entity.Path } }));
        }
    }
}