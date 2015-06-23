using System;
using System.Collections.Generic;
using System.Linq;

namespace speck.Frameworks
{
    /// <summary>
    /// 扩展类
    /// </summary>
    public static class ObjectExtension
    {
        /// <summary>
        /// 将数据转换为整形数据
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>整形数值</returns>
        public static int ToInt(this object data, int defaultValue = 0)
        {
            var value = defaultValue;
            if (data != null && !Convert.IsDBNull(data))
            {
                int.TryParse(data.ToString(), out value);
            }

            return value;
        }

        /// <summary>
        /// 获取字符串型数据
        /// </summary>
        /// <param name="data">原数据</param>
        /// <returns>字符串</returns>
        public static string ToString(this object data)
        {
            var value = string.Empty;
            if (data != null && !Convert.IsDBNull(data))
            {
                value = Convert.ToString(data);
            }

            return value;
        }

        /// <summary>
        /// 转换为double类型
        /// </summary>
        /// <param name="data">原数据</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static double ToDouble(this object data, double defaultValue = 0)
        {
            if (data != null && !Convert.IsDBNull(data))
            {
                double.TryParse(data.ToString(), out defaultValue);
            }
            return defaultValue;
        }

        /// <summary>
        /// 将数据转换为整形数据
        /// </summary>
        /// <param name="data">原数据</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static long ToLong(this object data, long defaultValue = 0)
        {
            long value = defaultValue;
            if (data != null && !Convert.IsDBNull(data))
            {
                long.TryParse(data.ToString(), out value);
            }

            return value;
        }

        /// <summary>
        /// 将数据转换为布尔值数据
        /// </summary>
        /// <param name="data">原数据</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>整形数值</returns>
        public static bool ToBoolean(this object data, bool defaultValue = false)
        {
            bool value = defaultValue;
            if (data != null && !Convert.IsDBNull(data))
            {
                bool.TryParse(data.ToString(), out value);
            }

            return value;
        }

        /// <summary>
        /// 将数据转换为整形数据
        /// </summary>
        /// <param name="data">原数据</param>
        /// <returns>null或时间</returns>
        public static DateTime? ToDateTime(this object data)
        {
            DateTime? value = null;
            if (data != null && !Convert.IsDBNull(data))
            {
                value = Convert.ToDateTime(data);
            }

            return value;
        }

        /// <summary>
        /// 将数据转换为时间，失败则返回设置的默认值
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static DateTime ToDateTime(this object data, DateTime defaultValue)
        {
            DateTime value = defaultValue;
            if (data != null && !Convert.IsDBNull(data))
            {
                try
                {
                    value = Convert.ToDateTime(data);//强制转换为时间
                }
                catch
                {
                    value = defaultValue;
                }
            }
            return value;
        }

        /// <summary>
        /// 将字符串数组转换为字典，key为数组值,value为空
        /// </summary>
        /// <param name="dataArr">原数组</param>
        /// <returns></returns>
        public static Dictionary<string, string> ToDictionary(this string[] dataArr)
        {
            Dictionary<string, string> dic = null;
            if (dataArr != null && dataArr.Length > 0)
            {
                dic = new Dictionary<string, string>();
                foreach (string str in dataArr)
                {
                    if (!string.IsNullOrWhiteSpace(str) && !dic.ContainsKey(str.Trim()))//值为有效字符串且不存在时才设置
                    {
                        dic.Add(str.Trim(), "");
                    }
                }
            }
            return dic;
        }

        /// <summary>
        /// 将数据转换为整形数据
        /// </summary>
        /// <param name="data">数据行</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>整形数值</returns>
        public static short ToShort(this object data, short defaultValue = 0)
        {
            short value = defaultValue;
            if (data != null && !Convert.IsDBNull(data))
            {
                short.TryParse(data.ToString(), out value);
            }

            return value;
        }

        /// <summary>
        /// 将字典类型转换为字符串
        /// </summary>
        /// <param name="dic">原字典</param>
        /// <param name="keyValueSplit">key与value之间的分隔符</param>
        /// <param name="keySplit">key与key之间的分隔符</param>
        /// <returns></returns>
        public static string DicToString<T1, T2>(this Dictionary<T1, T2> dic, string keyValueSplit = ":", string keySplit = ",")
        {
            var strRes = "";
            if (dic != null && dic.Count > 0)
            {
                strRes = dic.Aggregate(strRes,
                    (curr, kp) => curr + (kp.Key.ToString() + keyValueSplit + kp.Value.ToString() + keySplit));
                strRes = strRes.Trim(keySplit.ToCharArray());//移除前后key之间的分隔符
            }
            return strRes;
        }

        /// <summary>
        /// 将字典类型转换为字符串
        /// </summary>
        /// <param name="dic">原字典</param>
        /// <param name="keySplit">key与key之间的分隔符</param>
        /// <returns></returns>
        public static string DicKeyToString<T1, T2>(this Dictionary<T1, T2> dic, string keySplit = ",")
        {
            string strRes = "";
            if (dic != null && dic.Count > 0)
            {
                strRes = dic.Aggregate(strRes, (current, kp) => current + (kp.Key + keySplit));
                if (!string.IsNullOrWhiteSpace(strRes))
                {
                    strRes = strRes.Trim(keySplit.ToCharArray());//移除前后key之间的分隔符
                }
            }
            return strRes;
        }

        /// <summary>
        /// 将object类型转换为string类型
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static string ObjToString(this object obj, string defaultValue = null)
        {
            var strRes = defaultValue;
            if (obj != null && !Convert.IsDBNull(obj))
            {
                strRes = obj.ToString();
            }
            return strRes;
        }

        /// <summary>
        /// 将object类型转换为string类型
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static byte ToByte(this object obj)
        {
            var res = new byte();
            if (obj != null && !Convert.IsDBNull(obj))
            {
                res = Convert.ToByte(obj);
            }
            return res;
        }
    }
}