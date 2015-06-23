using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Caching;

namespace speck.Frameworks.WebCache
{
    /// <summary>
    /// 缓存处理
    /// </summary>
    public class CacheManage
    {
        /// <summary>
        /// 实体化对象
        /// </summary>
        private static readonly CacheManage _getcacheManage = new CacheManage();

        /// <summary>
        /// 防止外部实体化该类
        /// </summary>
        private CacheManage() { }

        /// <summary>
        /// 获取对象
        /// </summary>
        /// <returns></returns>
        public static CacheManage GetCacheManage()
        {
            return _getcacheManage;
        }

        /// <summary>
        /// 将数据存入缓存
        /// </summary>
        /// <param name="key">缓存key</param>
        /// <param name="obj">缓存内容</param>
        public void SetCache<T>(string key, T obj)
        {
            if (!string.IsNullOrWhiteSpace(key) && obj != null)
            {
                var cache = new Cache();
                cache.Insert(key, obj);
            }
        }

        /// <summary>
        /// 删除缓存
        /// </summary>
        /// <param name="key">key</param>
        public void DeleteCache(string key)
        {
            if (!string.IsNullOrWhiteSpace(key))
            {
                var cache = new Cache();
                cache.Remove(key);
            }
        }

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="key">缓存key</param>
        public T GetCache<T>(string key)
        {
            T t = default(T);
            if (!string.IsNullOrWhiteSpace(key))
            {
                var cache = new Cache();
                t = (T)cache.Get(key);
            }
            return t;
        }

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object GetCache(string key)
        {
            object obj = null;
            if (!string.IsNullOrWhiteSpace(key))
            {
                var cache = new Cache();
                obj = cache.Get(key);
            }
            return obj;
        }
    }
}
