using System;

namespace AspNetCache
{
    public interface ICacheManager
    {
        void Clear();
        void AddOrReplace(CacheItem cacheItem);
        void Remove(CacheItem cacheItem);
        void Remove(string key);
        T Get<T>(string key) where T : class;
        T GetWithFallBack<T>(string key, int cacheDurationMinutes, Func<T> fallbackQueryFunc) where T : class;
    }
}
