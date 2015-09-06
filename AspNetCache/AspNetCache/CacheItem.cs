using System;

namespace AspNetCache
{
    public class CacheItem
    {
        public string Key { get; set; }
        public object Value { get; set; }
        public DateTime? AddedToCacheOn { get; internal set; }
        public TimeSpan CacheDuration { get; set; }
    }
}
