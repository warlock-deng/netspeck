using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Threading.Tasks;
using Newtonsoft.Json;
using speck.Frameworks.Config;
using speck.Frameworks.CookieHelp;
using speck.Frameworks.Cryptography;
using speck.Frameworks.LogHelp;
using speck.WebAdmin.Common;

namespace speck.WebAdmin.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
            : base()
        {
            if (WebConfig == null) //获取配置文件
            {
                var strPath = ConfigurationManager.AppSettings["configpath"];
                if (!string.IsNullOrWhiteSpace(strPath) && System.IO.File.Exists(strPath))
                {
                    try
                    {
                        var configManage = new ConfigManage<WebConfigModel>();
                        WebConfig = configManage.ReadConfig(strPath);
                        if (WebConfig != null)
                        {
                            WebConfig.EncryptionKeyBytes = Encoding.UTF8.GetBytes(WebConfig.EncryptionKey);
                            WebConfig.EncryptionIvBytes = Encoding.UTF8.GetBytes(WebConfig.EncryptionIv);
                        }
                    }
                    catch (Exception ex)
                    {
                        LogManage.WriteLog(new LogEntity
                        {
                            LogType = LogType.Exception,
                            Title = "读取配置文件异常",
                            Content = string.Format("strPath={0};ex={1}", strPath, ex)
                        });
                    }
                }
            }
            if (UserCookie == null)//获取用户cookie
            {
                var cookie = CookieManage.GetCookie("webcookie");
                if (!string.IsNullOrWhiteSpace(cookie) && WebConfig != null)
                {
                    try
                    {
                        cookie = CryptionManage.Descryption(CryptionType.AES, cookie, WebConfig.EncryptionKeyBytes,
                            WebConfig.EncryptionIvBytes);
                        UserCookie = JsonConvert.DeserializeObject<AdminCookie>(cookie);
                    }
                    catch (Exception ex)
                    {
                        LogManage.WriteLog(new LogEntity
                        {
                            LogType = LogType.Exception,
                            Title = "解析用户cookie出错",
                            Content = string.Format("cookie:{0}；ex={1}", cookie, ex)
                        });
                    }
                }
                else
                {
                    
                }
            }
        }

        /// <summary>
        /// 用户cookie
        /// </summary>
        public AdminCookie UserCookie = null;

        /// <summary>
        /// 站点配置文件
        /// </summary>
        public static WebConfigModel WebConfig = null;

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //  filterContext.Controller
            base.OnActionExecuted(filterContext);

        }

        protected override void OnException(ExceptionContext filterContext)
        {
            //写日志
            LogManage.WriteLog(new LogEntity()
            {
                Title = "globle exception",
                Content = filterContext.Exception.ToString()
            });
        }

        /// <summary>
        /// 头部
        /// </summary>
        /// <returns></returns>
        public ActionResult _Head()
        {
            return View();
        }

        /// <summary>
        /// 底部
        /// </summary>
        /// <returns></returns>
        public ActionResult _Foot()
        {
            return View();
        }

    }
}
