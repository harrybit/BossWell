using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

namespace ApiHelp
{
    /// <summary>
    /// Http网络请求
    /// </summary>
    public class HttpHelper
    {
        /// <summary>
        /// Http Post Json
        /// </summary>
        public static string HttpRequestPost(string host, string data, IDictionary<object, string> dicHead = null)
        {
            //构造http请求的对象
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(host);
            //转换字节
            byte[] byteData = Encoding.GetEncoding("UTF-8").GetBytes(data);
            //设置
            myRequest.Method = "POST";
            myRequest.ContentLength = byteData.Length;
            myRequest.ContentType = "application/json";
            myRequest.MaximumAutomaticRedirections = 1;
            myRequest.AllowAutoRedirect = true;

            //Head
            if (dicHead != null)
            {
                foreach (var v in dicHead)
                {
                    if (v.Key is HttpRequestHeader) { myRequest.Headers[(HttpRequestHeader)v.Key] = v.Value; }
                    else { myRequest.Headers[v.Key.ToString()] = v.Value; }
                }
            }

            // 发送请求
            Stream newStream = myRequest.GetRequestStream();
            newStream.Write(byteData, 0, byteData.Length);

            // 获得接口返回值
            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
            string result = reader.ReadToEnd();
            newStream.Close();
            myResponse.Close();
            return result;
        }

        /// <summary>
        /// Http Post Form
        /// </summary>
        public static string HttpRequestForm(string host, IDictionary<string, object> dicItem,
            IDictionary<object, string> dicHead = null)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(host);
            request.Method = "POST";
            request.KeepAlive = false;
            request.ProtocolVersion = HttpVersion.Version10;
            request.Timeout = 5000;
            request.ContentType = "application/x-www-form-urlencoded;charset=utf-8";

            //Head
            if (dicHead != null)
            {
                foreach (var v in dicHead)
                {
                    if (v.Key is HttpRequestHeader) { request.Headers[(HttpRequestHeader)v.Key] = v.Value; }
                    else { request.Headers[v.Key.ToString()] = v.Value; }
                }
            }

            byte[] postData = Encoding.UTF8.GetBytes(DicSplitUrl(dicItem, "utf8"));
            Stream reqStream = request.GetRequestStream();
            reqStream.Write(postData, 0, postData.Length);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string result = reader.ReadToEnd();

            reqStream.Close();
            response.Close();
            return result;
        }

        /// <summary>
        /// Http Get
        /// </summary>
        public static string HttpRequestGet(string host)
        {
            //构造一个Web请求的对象
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(host);

            //获取web请求的响应的内容
            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();

            //通过响应流构造一个StreamReader
            StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);

            string result = reader.ReadToEnd();
            reader.Close();
            myResponse.Close();
            return result;
        }

        public static string DicSplitUrl(IDictionary<string, object> dicItem, string enCodeType)
        {
            StringBuilder textBuilder = new StringBuilder();
            int applocation = 0;
            IEnumerator<KeyValuePair<string, object>> pairEnumer = dicItem.GetEnumerator();
            while (pairEnumer.MoveNext())
            {
                string key = pairEnumer.Current.Key;
                string value = pairEnumer.Current.Value.ToString();

                if (string.IsNullOrEmpty(key)) { continue; }

                if (applocation > 0) { textBuilder.Append("&"); }
                textBuilder.Append(key + "=");

                if (enCodeType.Equals("gb2312")) { textBuilder.Append(HttpUtility.UrlEncode(value, Encoding.GetEncoding(enCodeType))); }
                else if (enCodeType.Equals("utf8")) { textBuilder.Append(HttpUtility.UrlEncode(value, Encoding.UTF8)); }
                else { textBuilder.Append(value); }

                applocation++;
            }
            return textBuilder.ToString();
        }
    }
}