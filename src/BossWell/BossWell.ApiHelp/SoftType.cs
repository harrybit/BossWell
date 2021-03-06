﻿using System.Text;

namespace System
{
    /// <summary>
    /// TryParse软类型转换
    /// 2018-10-22 12:04
    /// Harry
    /// </summary>
    public static class SoftType
    {
        #region 值类型软转换

        /// <summary>
        /// 转为int类型
        /// </summary>
        /// <param name="obj">要转化的obj</param>
        /// <param name="defval">默认值</param>
        /// <returns></returns>
        public static int _Int(this object obj, int defval = 0)
        {
            int a = 0;
            decimal b = decimal.Zero;
            decimal.TryParse(obj.ToString(), out b);
            if (b == 0) { a = defval; }
            else { a = Convert.ToInt32(b); }
            return a;
        }

        /// <summary>
        /// 转为string类型
        /// </summary>
        /// <param name="obj">要转化的obj</param>
        /// <param name="defval">默认值</param>
        /// <returns></returns>
        public static string _String(this object obj, string defval = "")
        {
            string a = defval;
            if (obj == null) { return a; }
            a = obj.ToString();
            return a;
        }

        /// <summary>
        /// 转为Bool类型
        /// </summary>
        /// <param name="obj">要转化的obj</param>
        /// <param name="defval">默认值</param>
        /// <returns></returns>
        public static bool _Bool(this object obj, bool defval = false)
        {
            bool a = false;
            if (!bool.TryParse(obj.ToString(), out a)) { a = defval; };
            return a;
        }

        /// <summary>
        /// 转为Bool类型
        /// </summary>
        /// <param name="obj">要转化的obj</param>
        /// <param name="defval">默认值</param>
        /// <returns></returns>
        public static bool? _BoolIsNull(this object obj, bool defval = false)
        {
            bool a = false;
            if (!bool.TryParse(obj.ToString(), out a)) { a = defval; };
            return a;
        }

        /// <summary>
        /// 转为DateTime类型
        /// </summary>
        /// <param name="obj">要转化的obj</param>
        /// <returns></returns>
        public static DateTime _DateTime(this object obj)
        {
            DateTime a = DateTime.Parse("1900-01-01");
            DateTime.TryParse(obj.ToString(), out a);
            return a;
        }

        /// <summary>
        /// 转为DateTime类型2
        /// </summary>
        /// <param name="obj">要转化的obj</param>
        /// <returns></returns>
        public static DateTime? _DateTimeToNull(this object obj)
        {
            DateTime a = DateTime.Parse("1900-01-01");
            if (string.IsNullOrEmpty(obj.ToString()))
            {
                return null;
            }
            DateTime.TryParse(obj.ToString(), out a);
            return a;
        }

        /// <summary>
        /// 转为decimal类型
        /// </summary>
        /// <param name="obj">要转化的obj</param>
        /// <param name="number">保留小数的位数</param>
        /// <param name="defval">默认值</param>
        /// <returns></returns>
        public static decimal _Decimal(this object obj, int number = 2, decimal defval = decimal.Zero)
        {
            decimal a = decimal.Zero;
            if (obj == null)
            {
                obj = "0";
            }
            if (!decimal.TryParse(obj.ToString(), out a)) { a = defval; };
            a = Math.Round(a, number);//四舍五入保留两位小数
            return a;
        }

        /// <summary>
        /// 转为double类型
        /// </summary>
        /// <param name="obj">要转化的obj</param>
        /// <param name="defval">默认值</param>
        /// <returns></returns>
        public static double _Double(this object obj, double defval = 0)
        {
            double a = 0;
            if (!double.TryParse(obj.ToString(), out a)) { a = defval; };
            return a;
        }

        /// <summary>
        /// 转为float类型
        /// </summary>
        /// <param name="obj">要转化的obj</param>
        /// <param name="defval">默认值</param>
        /// <returns></returns>
        public static double _Float(this object obj, float defval = 0)
        {
            float a = 0;
            if (!float.TryParse(obj.ToString(), out a)) { a = defval; };
            return a;
        }

        #endregion 值类型软转换

        #region 字符串操作

        /// <summary>
        /// 获取字符串长度
        /// </summary>
        /// <param name="textContent">字符串</param>
        /// <returns></returns>
        public static int _StringLng(this string textContent)
        {
            var codingType = Encoding.GetEncoding("GB2312");
            return codingType.GetByteCount(textContent);
        }

        #endregion 字符串操作
    }
}