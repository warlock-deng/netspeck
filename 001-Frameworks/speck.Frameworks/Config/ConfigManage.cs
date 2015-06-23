using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Web.Caching;
using Newtonsoft.Json;

//配置文件处理
using speck.Frameworks.WebCache;

namespace speck.Frameworks.Config
{
    /// <summary>
    /// 配置文件管理
    /// </summary>
    public class ConfigManage<T>
    {
        /// <summary>
        /// 配置类型
        /// </summary>
        private static ConfigType _configType = ConfigType.XML;

        /// <summary>
        /// 配置文件地址
        /// </summary>
        private static string _configPath = ConfigurationManager.AppSettings["configPath"];

        /// <summary>
        /// 设置配置文件类型
        /// </summary>
        static ConfigManage()
        {
            _configType = (ConfigType)ConfigurationManager.AppSettings["configType"].ToInt();
        }

        /// <summary>
        /// 读取配置文件
        /// <param name="setCache">是否写入缓存；true表示写入缓存</param>
        /// </summary>
        public T ReadConfig(bool setCache)
        {
            var t = default(T);
            if (!string.IsNullOrWhiteSpace(_configPath) && File.Exists(_configPath))
            {
                object obj = null;
                CacheManage cacheManage = null;
                const string strKey = "webconfig";
                if (setCache)
                {
                    cacheManage = CacheManage.GetCacheManage();
                    obj = cacheManage.GetCache(strKey);
                    t = (T)obj;
                }
                if (obj == null)
                {
                    var str = FileHelp.FileManage.Read(_configPath);
                    if (!string.IsNullOrWhiteSpace(str))
                    {
                        t = JsonConvert.DeserializeObject<T>(str);
                        if (setCache)
                        {
                            cacheManage.SetCache(strKey, t);
                        }
                    }
                }
            }
            return t;
        }

        /// <summary>
        /// 读取配置文件                                        
        /// <param name="strPath">路径</param>
        /// <param name="setCache">是否写入缓存；true表示写入缓存</param>
        /// </summary>
        public T ReadConfig(string strPath, bool setCache = true)
        {
            var t = default(T);
            _configPath = strPath;
            return ReadConfig(setCache); ;
        }

        /// <summary>
        /// 设置配置
        /// </summary>
        /// <param name="t">配置文件对象</param>
        public void SetConfig(T t) 
        {
            if (t != null)
            {
                var str = JsonConvert.SerializeObject(t);
                if (!string.IsNullOrWhiteSpace(str) && File.Exists(_configPath))
                {
                    FileHelp.FileManage.Write(_configPath, str);
                }
            }
        }

        /// <summary>
        /// 设置或获取配置文件类型
        /// </summary>
        public ConfigType ConfigType { get; set; }
    }
}
