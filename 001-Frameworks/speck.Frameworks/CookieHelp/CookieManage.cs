using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using speck.Frameworks.Cryptography;

namespace speck.Frameworks.CookieHelp
{
    /// <summary>
    /// 用户状态处理
    /// </summary>
    public static class CookieManage
    {
        /// <summary>
        /// 设置cookie
        /// </summary>
        /// <param name="cookie">cookie名称</param>
        public static void SetCookie(HttpCookie cookie)
        {
            if (HttpContext.Current != null && cookie != null)
            {
                HttpContext.Current.Request.Cookies.Add(cookie);
            }
        }

        /// <summary>
        /// 设置cookie
        /// </summary>
        /// <param name="cookieName">cookie名称</param>
        /// <param name="cookieValue">cookie值</param>
        /// <param name="ts">存放时长</param>
        public static void SetCookie(string cookieName, string cookieValue, TimeSpan ts)
        {
            if (HttpContext.Current != null)
            {
                if (!string.IsNullOrWhiteSpace(cookieName) && !string.IsNullOrWhiteSpace(cookieValue))
                {
                    var hcCookie = new HttpCookie(cookieName) { Expires = DateTime.Now.Add(ts), Value = cookieValue };
                    SetCookie(hcCookie);
                }
            }
        }

        /// <summary>
        /// 获取cookie名称
        /// </summary>
        /// <param name="cookieName">cookie名称</param>
        /// <returns></returns>
        public static string GetCookie(string cookieName)
        {
            string strRes = null;
            if (HttpContext.Current != null)
            {
                var cookie = HttpContext.Current.Request.Cookies[cookieName];
                if (cookie != null)
                {
                    strRes = cookie.Value;
                }
            }
            return strRes;
        }

    }
}
