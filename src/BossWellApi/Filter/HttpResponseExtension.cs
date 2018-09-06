using System.Net.Http;
using System.Text;

namespace BossWellApi
{
    public class HttpResponseExtension
    {
        //注入效验token，返回错误信息
        public static HttpResponseMessage ReturnError(JObjectResult content)
        {
            HttpResponseMessage result = new HttpResponseMessage
            {
                Content = new StringContent(ApiHelp.ApiHelper.JsonSerial(content),
                Encoding.GetEncoding("UTF-8"), "application/json")
            };
            return result;
        }
    }
}