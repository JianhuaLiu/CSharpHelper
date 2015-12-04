using System;
using System.Runtime.Caching;

namespace CSharpHelper
{
    /// <summary>
    /// 缓存帮助类
    /// </summary>
    public static class MemoryCacheHelper
    {
        //单利模式
        private static readonly object _locker = new object();

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <typeparam name="T">缓存实体</typeparam>
        /// <param name="key">缓存名称</param>
        /// <param name="cachePopulate">委托执行方法</param>
        /// <param name="slidingExpiration">缓存项在给定时段内未被访问，是否应被逐出</param>
        /// <param name="absoluteExpiration">持续时间过后逐出某个缓存项</param>
        /// <returns>缓存实体</returns>
        /// //使用MemoryCache缓存类
        /// //string access_token = MemoryCacheHelper.GetCacheItem<string>("access_token", delegate ()
        /// //{
        /// //    var url = ConfigMethod.GetAccessToKen();
        /// //    AccessToKen info = HttpClientHelper.GetResponse<AccessToKen>(url);
        /// //    string result = info.access_token;
        /// //    return result;
        /// //}, new TimeSpan(0, 0, 7000)
        /// //);
        public static T GetCache<T>(string key, Func<T> cachePopulate, TimeSpan? slidingExpiration = null, DateTime? absoluteExpiration = null) where T : class
        {
            //单利双重加锁模式
            if (MemoryCache.Default[key] == null)
            {
                lock (_locker)
                {
                    if (MemoryCache.Default[key] == null)
                    {
                        //设置单个缓存
                        CacheItem item = new CacheItem(key, cachePopulate());
                        //设置过期时间
                        CacheItemPolicy policy = CreatePolicy(slidingExpiration, absoluteExpiration);
                        MemoryCache.Default.Add(item, policy);
                    }
                }
            }
            return MemoryCache.Default[key] as T;
        }

        /// <summary>
        /// 设置缓存类过期时间
        /// </summary>
        private static CacheItemPolicy CreatePolicy(TimeSpan? slidingExpiration, DateTime? absoluteExpiration)
        {
            CacheItemPolicy policy = new CacheItemPolicy();
            //判断是否有值
            if (slidingExpiration.HasValue)
            {
                policy.SlidingExpiration = slidingExpiration.Value;
            }
            if (absoluteExpiration.HasValue)
            {
                policy.AbsoluteExpiration = absoluteExpiration.Value;
            }
            //设置过期优先级
            policy.Priority = CacheItemPriority.Default;
            return policy;
        }
    }
}