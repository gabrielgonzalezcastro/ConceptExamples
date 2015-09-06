using System;
using System.Web;
using System.Web.Caching;

namespace AspNetCache
{
    public class AspNetCacheManager : ICacheManager
    {
        private Cache _cache;

        public AspNetCacheManager()
        {
            this._cache = HttpRuntime.Cache;
        }

        public void Clear()
        {
            foreach (object obj in this._cache)
            {
                this._cache.Remove(obj.ToString());
            }
        }

        public void AddOrReplace(CacheItem cacheItem)
        {
            if (cacheItem.Key == null || cacheItem.Value == null)
                return;

            cacheItem.AddedToCacheOn = new DateTime?(DateTime.Now);
            this._cache.Insert(cacheItem.Key, cacheItem.Value, (CacheDependency)null,
                DateTime.UtcNow.AddMinutes(cacheItem.CacheDuration.TotalMinutes), Cache.NoSlidingExpiration);
        }

        public void Remove(CacheItem cacheItem)
        {
            this.Remove(cacheItem.Key);
        }

        public void Remove(string key)
        {
            this._cache.Remove(key);
        }

        public T Get<T>(string key) where T : class
        {
            return this._cache.Get(key) as T;
        }

        /// <summary>
        /// With this method we can specify a method to execute in the case that the object is not in the cache
        /// </summary>
        public T GetWithFallBack<T>(string key, int cacheDurationMinutes, Func<T> fallbackQueryFunc) where T : class
        {
            //If the object is in the cache already
            T obj1 = this.Get<T>(key);
            if ((object) obj1 != null)
                return obj1;

            //execute the function, add the result into the cache and return the result
            T obj2 = fallbackQueryFunc();
            this.AddOrReplace(new CacheItem
            {
                CacheDuration = new TimeSpan(0,cacheDurationMinutes,0),
                Key = key,
                Value = (object)obj2
            });
            return obj2;
        }
    }
}
