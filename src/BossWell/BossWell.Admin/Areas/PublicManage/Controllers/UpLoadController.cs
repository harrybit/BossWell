using BossWell.ApiHelp;
using BossWell.Application;
using BossWell.Model.Other;
using System.Web;
using System.Web.Mvc;
namespace BossWell.Admin.Areas.PublicManage.Controllers
{
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
            int code = QiNiuUpLoadApplication.CheckUpFileFixByImg(file.FileName, file.ContentLength);

            if (code == 501)
            {
                return Success("Picture Format Error");
            }
            else if (code == 502)
            {
                return Success("Size Beyond The Limit");
            }

            QiNiuResultModel resultModel = QiNiuUpLoadApplication.UpLoadBySteam(file.InputStream, file.ContentLength, "PNG");

            return Content(ApiHelper.JsonSerial(resultModel));
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
            
            QiNiuResultModel resultModel = QiNiuUpLoadApplication.UpLoadBySteam(file.InputStream, file.ContentLength, fix);

            return Content(ApiHelper.JsonSerial(resultModel));
        }
    }
}