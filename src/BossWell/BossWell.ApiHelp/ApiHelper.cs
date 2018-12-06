using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;
using System.Xml.Serialization;

namespace BossWell.ApiHelp
{
    /// <summary>
    /// 一些帮助函数
    /// </summary>
    public class ApiHelper
    {
        #region Json序列化操作

        /// <summary>
        /// 序列化Json字符串
        /// </summary>
        /// <param name="o">json对象</param>
        /// <returns></returns>
        public static string JsonSerial(object obj)
        {
            StringBuilder strBuilder = new StringBuilder();
            JavaScriptSerializer jsonSerial = new JavaScriptSerializer();
            jsonSerial.Serialize(obj, strBuilder);
            return strBuilder.ToString();
        }

        /// <summary>
        /// 反序列化Json对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonString">json字符串</param>
        /// <returns></returns>
        public static T JsonDeserial<T>(string jsonString)
        {
            string p = @"\d{4}-\d{2}-\d{2}\s\d{2}:\d{2}:\d{2}";
            MatchEvaluator matchEvaluator = new MatchEvaluator(ConvertDateStringToJsonDate);
            Regex reg = new Regex(p);
            jsonString = reg.Replace(jsonString, matchEvaluator);
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString)))
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
                return (T)ser.ReadObject(ms);
            }
        }

        private static string ConvertDateStringToJsonDate(Match m)
        {
            string result = string.Empty;
            DateTime dt = DateTime.Parse(m.Groups[0].Value);
            dt = dt.ToUniversalTime();
            TimeSpan ts = dt - DateTime.Parse("1970-01-01");
            result = string.Format("\\/Date({0}+0800)\\/", ts.TotalMilliseconds);
            return result;
        }

        /// <summary>
        /// 解析JSON对象键值队
        /// </summary>
        /// <param name="obj">字典对象</param>
        /// <param name="key">key</param>
        /// <param name="defaultValue">value</param>
        /// <returns></returns>
        public static string GetProertyValue(JObject obj, string key, string defaultValue)
        {
            if (obj == null)
            {
                return defaultValue;
            }
            var property = obj[key];
            if (property != null && !string.IsNullOrEmpty(property.ToString()))
            {
                return property.ToString();
            }
            return defaultValue;
        }

        #endregion Json序列化操作

        #region XML序列化操作

        /// <summary>
        /// 序列化XML
        /// </summary>
        /// <param name="type">序列化对象类型</param>
        /// <param name="obj">序列化对象</param>
        /// <returns></returns>
        public static string XMLSerial(Type type, object obj)
        {
            MemoryStream Stream = new MemoryStream();
            XmlSerializer xmlSerial = new XmlSerializer(type);
            try
            {
                //序列化对象
                xmlSerial.Serialize(Stream, obj);
            }
            catch (InvalidOperationException)
            {
                throw;
            }

            Stream.Position = 0;
            StreamReader readerStream = new StreamReader(Stream);
            string result = readerStream.ReadToEnd();
            readerStream.Dispose();
            Stream.Dispose();

            return result;
        }

        /// <summary>
        /// 反序列XML根据文本
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="xmlContent">内容</param>
        /// <returns></returns>
        public static object XMLDeserialByStr(Type type, string xmlContent)
        {
            try
            {
                using (StringReader readStr = new StringReader(xmlContent))
                {
                    XmlSerializer xmlSerial = new XmlSerializer(type);
                    return xmlSerial.Deserialize(readStr);
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// 反序列XML根据文件流
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="xmlContent">内容</param>
        /// <returns></returns>
        public static object XMLDeserialByStream(Type type, Stream stream)
        {
            XmlSerializer xmlSerial = new XmlSerializer(type);
            return xmlSerial.Deserialize(stream);
        }

        #endregion XML序列化操作

        #region 加密算法

        #region 不可逆加密

        /// <summary>
        /// 加密字符串
        /// </summary>
        /// <param name="oldStr">原字符串</param>
        /// <param name="type">加密方式(SHA1-MD5)</param>
        /// <returns>加密后的字符串</returns>
        public static string MD5Encrypt(string oldStr, string type = "SHA1")
        {
            if (!type.Equals("SHA1") && !type.Equals("MD5"))
            {
                return string.Empty;
            }
            return FormsAuthentication.HashPasswordForStoringInConfigFile(oldStr, type); ;
        }

        /// <summary>
        /// HMAC-SHA1加密算法
        /// </summary>
        /// <param name="key">密钥</param>
        /// <param name="input">要加密的串</param>
        /// <returns></returns>
        public static string HmacSha1(string key, string input)
        {
            byte[] keyBytes = ASCIIEncoding.ASCII.GetBytes(key);
            byte[] inputBytes = ASCIIEncoding.ASCII.GetBytes(input);
            HMACSHA1 hmac = new HMACSHA1(keyBytes);
            byte[] hashBytes = hmac.ComputeHash(inputBytes);
            return Convert.ToBase64String(hashBytes);
        }

        /// <summary>
        /// SHA265加密
        /// </summary>
        /// <returns></returns>
        public static string SHA256(string text)
        {
            byte[] clearBytes = Encoding.UTF8.GetBytes(text);
            SHA256 sha256 = new SHA256Managed();
            sha256.ComputeHash(clearBytes);
            byte[] hashedBytes = sha256.Hash;
            sha256.Clear();
            string output = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            return output;
        }

        #endregion 不可逆加密

        #region 可逆加密

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="oldStr">原字符串</param>
        /// <returns></returns>
        public static string InverseEncode(string oldStr)
        {
            char[] charKey ={
                '+','-','*','/','4','5','6','7'
                };
            byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(charKey);
            byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes(charKey);
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            int i = cryptoProvider.KeySize;
            MemoryStream ms = new MemoryStream();
            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateEncryptor(byKey, byIV), CryptoStreamMode.Write);
            StreamWriter sw = new StreamWriter(cst);
            sw.Write(oldStr);
            sw.Flush();
            cst.FlushFinalBlock();
            sw.Flush();
            return Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="oldStr">源字符串</param>
        /// <returns></returns>
        public static string InverseDecode(string oldStr)
        {
            char[] charKey ={
                '+','-','*','/','4','5','6','7'
                };
            byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(charKey);
            byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes(charKey);
            byte[] byEnc;
            try
            {
                byEnc = Convert.FromBase64String(oldStr);
            }
            catch
            {
                return null;
            }
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream ms = new MemoryStream(byEnc);
            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateDecryptor(byKey, byIV), CryptoStreamMode.Read);
            StreamReader sr = new StreamReader(cst);
            return sr.ReadToEnd();
        }

        #endregion 可逆加密

        #endregion 加密算法

        #region 字符串操作

        /// <summary>
        /// 生成随机数
        /// </summary>
        /// <param name="Length">数字长度</param>
        /// <param name="charLength">获取生成字符所包含数组长度</param>
        /// <param name="firstStr">头部包含</param>
        /// <returns></returns>
        public static string CreateRandom(int Length, int charLength, string firstStr)
        {
            //生成字符串所包含
            char[] constant ={
                '0','1','2','3','4','5','6','7','8','9',
                'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',
                'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'
                };
            StringBuilder newRandom = new StringBuilder();
            newRandom.Append(firstStr);
            Random rd = new Random();
            for (int i = 0; i < Length; i++)
            {
                newRandom.Append(constant[rd.Next(charLength)]);
            }
            return newRandom.ToString();
        }

        /// <summary>
        /// 生成随机数(最大32位)
        /// </summary>
        public static string CreateRandomString(int count, string firstStr = "")
        {
            StringBuilder textBuilder = new StringBuilder();
            string guidStr = Guid.NewGuid().ToString("N");

            if (count < 32)
            {
                guidStr = guidStr.Substring(0, count);
            }

            if (!string.IsNullOrEmpty(firstStr))
            {
                textBuilder.Append(firstStr);
            }
            textBuilder.Append(guidStr);
            return textBuilder.ToString();
        }

        /// <summary>
        /// 获取某段字符串值
        /// </summary>
        /// <param name="textContent">文本内容</param>
        /// <param name="startSign">开始标记</param>
        /// <param name="endSign">结束标记</param>
        /// <returns></returns>
        public static string GetContentByMark(string textContent, string startSign, string endSign)
        {
            var reg = new Regex("(?<=(" + startSign + "))[.\\s\\S]*?(?=(" + endSign + "))",
                RegexOptions.Multiline | RegexOptions.Singleline);
            return reg.Match(textContent).Value;
        }

        /// <summary>
        /// 过滤特殊字符
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string FilterChar(string content)
        {
            //过滤特殊字符数组
            string[] regArray ={
                        @"<script[^>]*?>.*?</script>",
                        @"<(///s*)?!?((/w+:)?/w+)(/w+(/s*=?/s*(([""'])(//[""'tbnr]|[^/7])*?/7|/w+)|.{0})|/s)*?(///s*)?>",
                        @"([/r/n])[/s]+",
                        @"&(quot|#34);",
                        @"&(amp|#38);",
                        @"&(lt|#60);",
                        @"&(gt|#62);",
                        @"&(nbsp|#160);",
                        @"&(iexcl|#161);",
                        @"&(cent|#162);",
                        @"&(pound|#163);",
                        @"&(copy|#169);",
                        @"&#(/d+);",
                        @"-->",
                        @"<!--.*/n"
                        };

            string strOutput = content;
            for (int i = 0; i < regArray.Length; i++)
            {
                Regex regex = new Regex(regArray[i], RegexOptions.IgnoreCase);
                strOutput = regex.Replace(strOutput, string.Empty);
            }
            strOutput.Replace("<", "");
            strOutput.Replace(">", "");
            strOutput.Replace("/r/n", "");

            return strOutput;
        }

        #endregion 字符串操作

        #region 经纬度计算

        /// <summary>
        /// 计算2个点(经纬度)之间的直线距离
        /// </summary>
        /// <param name="lat1">纬度1</param>
        /// <param name="lng1">经度1</param>
        /// <param name="lat2">纬度2</param>
        /// <param name="lng2">经度2</param>
        /// <param name="way">计算距离方式</param>
        /// <returns></returns>
        public static double CalcDistanceByLatAndLng(double lat1, double lng1, double lat2, double lng2, bool way = true)
        {
            double EARTH_RADIUS = 6378.137;//地球半径
            double radLat1 = Rad(lat1);
            double radLat2 = Rad(lat2);
            double radLon1 = Rad(lng1);
            double radLon2 = Rad(lng2);

            if (way)
            {
                if (radLat1 < 0) radLat1 = Math.PI / 2 + Math.Abs(radLat1);// south
                if (radLat1 > 0) radLat1 = Math.PI / 2 - Math.Abs(radLat1);// north
                if (radLon1 < 0) radLon1 = Math.PI * 2 - Math.Abs(radLon1);// west
                if (radLat2 < 0) radLat2 = Math.PI / 2 + Math.Abs(radLat2);// south
                if (radLat2 > 0) radLat2 = Math.PI / 2 - Math.Abs(radLat2);// north
                if (radLon2 < 0) radLon2 = Math.PI * 2 - Math.Abs(radLon2);// west
                double x1 = EARTH_RADIUS * Math.Cos(radLon1) * Math.Sin(radLat1);
                double y1 = EARTH_RADIUS * Math.Sin(radLon1) * Math.Sin(radLat1);
                double z1 = EARTH_RADIUS * Math.Cos(radLat1);
                double x2 = EARTH_RADIUS * Math.Cos(radLon2) * Math.Sin(radLat2);
                double y2 = EARTH_RADIUS * Math.Sin(radLon2) * Math.Sin(radLat2);
                double z2 = EARTH_RADIUS * Math.Cos(radLat2);
                double d = Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2) + (z1 - z2) * (z1 - z2));
                //余弦定理求夹角
                double theta = Math.Acos((EARTH_RADIUS * EARTH_RADIUS + EARTH_RADIUS * EARTH_RADIUS - d * d) / (2 * EARTH_RADIUS * EARTH_RADIUS));
                double dist = theta * EARTH_RADIUS;
                return dist;
            }
            else
            {
                double a = radLat1 - radLat2;
                double b = Rad(lng1) - Rad(lng2);
                double s = 2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(a / 2), 2) +
                 Math.Cos(radLat1) * Math.Cos(radLat2) * Math.Pow(Math.Sin(b / 2), 2)));
                s = s * EARTH_RADIUS;
                s = Math.Round(s * 10000) / 10000;
                return s;
            }
        }

        /// <summary>
        /// 计算坐标
        /// </summary>
        /// <param name="d">地图坐标</param>
        /// <returns></returns>
        public static double Rad(double d) { return d * Math.PI / 180.0; }

        #endregion 经纬度计算

        #region 邮件发送代理

        /// <summary>
        /// 邮件发送代理
        /// </summary>
        /// <param name="MTo">发送人邮箱(可以多个)</param>
        /// <param name="Subject">邮件标题</param>
        /// <param name="Body">邮件内容(可为html)</param>
        /// <param name="file">发送附件地址(文件绝对路径)</param>
        /// <returns></returns>
        public static bool SendMail(string[] MTo, string Subject, string Body, string[] file = null)
        {
            try
            {
                SmtpClient sc = new SmtpClient();
                sc.Host = "smtp.qq.com";//smtp服务器地址
                sc.Port = 25;//默认端口为25
                sc.UseDefaultCredentials = true;
                sc.EnableSsl = true;
                //发送人账号、授权密码
                sc.Credentials = new System.Net.NetworkCredential("1608995730@qq.com", "psnztvmrvzeibaei");
                MailAddress mf = new MailAddress("1608995730@qq.com", "hl", Encoding.GetEncoding("utf-8"));
                MailMessage message = new MailMessage();
                message.From = mf;
                message.Subject = Subject;//标题
                message.Body = Body;//内容
                message.IsBodyHtml = true;           //是否为html格式
                message.Priority = MailPriority.High;  //发送邮件的优先等级
                //多个发送人
                for (int i = 0; i < MTo.Length; i++)
                {
                    message.To.Add(MTo[i]);
                }

                //发送附件
                if (file != null)
                {
                    for (int i = 0; i < file.Length; i++)
                    {
                        message.Attachments.Add(new Attachment(file[i]));
                    }
                }

                sc.Send(message);
            }//抛出异常
            catch
            {
                return false;
            }
            return true;
        }

        #endregion 邮件发送代理

        #region 时间操作

        /// <summary>
        /// 获取当前时间戳
        /// </summary>
        /// <returns></returns>
        public static string GetTimgLongUnix(DateTime timeEnd, int type = 0)
        {
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)); // 当地时区
            long timeStamp = (long)(timeEnd - startTime).TotalSeconds; // 相差秒数
            if (type != 0) { timeStamp = (long)((timeEnd - startTime).TotalSeconds * 1000); }
            return timeStamp.ToString();
        }

        #endregion 时间操作

        #region 基础功能

        /// <summary>
        /// 获取客户端IP
        /// </summary>
        /// <returns></returns>
        public static string GetClientIP()
        {
            string result = string.Empty;
            if (HttpContext.Current == null || HttpContext.Current.Request == null)
            {
                return string.Empty;
            }
            result = HttpContext.Current.Request.ServerVariables.Get("Remote_Host").ToString();
            return result;
        }

        /// <summary>
        /// 返回描述本地计算机上的网络接口的对象(网络接口也称为网络适配器)。
        /// </summary>
        /// <returns></returns>
        public static NetworkInterface[] NetCardInfo()
        {
            return NetworkInterface.GetAllNetworkInterfaces();
        }

        ///<summary>
        /// 通过NetworkInterface读取网卡Mac
        ///</summary>
        ///<returns></returns>
        public static List<string> GetMacByNetworkInterface()
        {
            List<string> macs = new List<string>();
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface ni in interfaces)
            {
                macs.Add(ni.GetPhysicalAddress().ToString());
            }
            return macs;
        }

        /// <summary>
        /// String To Base64
        /// </summary>
        /// <returns></returns>
        public static string GetBase64ByStr(string text)
        {
            byte[] bytedata = File.ReadAllBytes(text);
            return Convert.ToBase64String(bytedata, 0, bytedata.Length);
        }

        /// <summary>
        /// File To Md5
        /// </summary>
        /// <returns></returns>
        public static string GetMD5HashFromFile(string fileName)
        {
            try
            {
                FileStream file = new FileStream(fileName, FileMode.Open);
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] retVal = md5.ComputeHash(file);
                file.Close();

                StringBuilder md5Builder = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    md5Builder.Append(retVal[i].ToString("x2"));
                }
                return md5Builder.ToString();
            }
            catch
            {
                return string.Empty;
            }
        }

        #endregion 基础功能

        #region Cookie操作

        /// <summary>
        /// 写cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <param name="strValue">值</param>
        public static void WriteCookie(string strName, string strValue)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie.Value = strValue;
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// 写cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <param name="strValue">值</param>
        /// <param name="strValue">过期时间(分钟)</param>
        public static void WriteCookie(string strName, string strValue, int expires)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie.Value = strValue;
            cookie.Expires = DateTime.Now.AddMinutes(expires);
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// 读cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <returns>cookie值</returns>
        public static string GetCookie(string strName)
        {
            try
            {
                if (HttpContext.Current.Request.Cookies != null && HttpContext.Current.Request.Cookies[strName] != null)
                {
                    return HttpContext.Current.Request.Cookies[strName].Value.ToString();
                }
            }
            catch (Exception ex) { }

            return "";
        }

        /// <summary>
        /// 删除Cookie对象
        /// </summary>
        /// <param name="CookiesName">Cookie对象名称</param>
        public static void RemoveCookie(string CookiesName)
        {
            HttpCookie objCookie = new HttpCookie(CookiesName.Trim());
            objCookie.Expires = DateTime.Now.AddYears(-5);
            HttpContext.Current.Response.Cookies.Add(objCookie);
        }

        #endregion Cookie操作

        #region Session操作

        /// <summary>
        /// 写Session
        /// </summary>
        /// <typeparam name="T">Session键值的类型</typeparam>
        /// <param name="key">Session的键名</param>
        /// <param name="value">Session的键值</param>
        public static void WriteSession<T>(string key, T value)
        {
            if (string.IsNullOrEmpty(key))
                return;
            HttpContext.Current.Session[key] = value;
        }

        /// <summary>
        /// 写Session
        /// </summary>
        /// <param name="key">Session的键名</param>
        /// <param name="value">Session的键值</param>
        public static void WriteSession(string key, string value)
        {
            WriteSession<string>(key, value);
        }

        /// <summary>
        /// 读取Session的值
        /// </summary>
        /// <param name="key">Session的键名</param>
        public static string GetSession(string key)
        {
            if (string.IsNullOrEmpty(key))
                return string.Empty;
            return HttpContext.Current.Session[key] as string;
        }

        /// <summary>
        /// 删除指定Session
        /// </summary>
        /// <param name="key">Session的键名</param>
        public static void RemoveSession(string key)
        {
            if (string.IsNullOrEmpty(key))
                return;
            HttpContext.Current.Session.Contents.Remove(key);
        }

        #endregion Session操作
    }
}