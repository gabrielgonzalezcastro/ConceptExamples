using System;
using System.Collections.Generic;
using System.Runtime.Caching;

namespace Cache_UsingMemoryCache
{
    /// <summary>
    /// this library can be used in all ASP.NET web, WinForms and WPF applications.
    /// </summary>
    public class MyCache
    {
        // Get a reference to the default MemoryCache instance. 
        private static ObjectCache _cache = MemoryCache.Default;
        private CacheItemPolicy _cacheItemPolicy = null;
        private CacheEntryRemovedCallback _callback = null;

        /// <summary>
        /// Method use to add a item to the cache Object
        /// </summary>
        public void AddItemToMyCache(string cacheKeyName, Object cacheItem,
            MyCachePriorityEnum myCachePriority, List<string> filePath)
        {
            
            
            //set the cache policy (priority in case that the item needs to be removed to free resources)
            _cacheItemPolicy = new CacheItemPolicy();
            if (myCachePriority == MyCachePriorityEnum.Default)
                _cacheItemPolicy.Priority = CacheItemPriority.Default;
            else
                _cacheItemPolicy.Priority = CacheItemPriority.NotRemovable;

            //set the duration of the item in the cache
            _cacheItemPolicy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(10);

            //set the method that is called when a item is removed from the cache
            _callback = new CacheEntryRemovedCallback(this.MyCachedItemRemovedCallback);
            _cacheItemPolicy.RemovedCallback = _callback;

            //Add a changemonitor to monitor files and directories
            _cacheItemPolicy.ChangeMonitors.Add(new HostFileChangeMonitor(filePath));

            //Add the item to the cache
            _cache.Add(cacheKeyName, cacheItem, _cacheItemPolicy);

        }

        /// <summary>
        /// Method to get a element to the cache object
        /// </summary>
        public T GetMyCachedItem<T>(string cacheKeyName) where T:class 
        {
            return _cache[cacheKeyName] as T;
        }

        /// <summary>
        /// Method that removes a item from the cache object
        /// </summary>
        public void RemoveMyCachedItem(string cacheKeyName)
        {
            if (_cache.Contains(cacheKeyName))
            {
                _cache.Remove(cacheKeyName);
            }
        }

        #region Private Methods
        
        /// <summary>
        /// This method is called when a item is remove from the cache
        /// </summary>
        private void MyCachedItemRemovedCallback(CacheEntryRemovedArguments arguments)
        {
            //Log these values from argument list
            var strLog = string.Concat("Reason: ", arguments.RemovedReason.ToString(),
                "| Key-Name: ", arguments.CacheItem.Key, " | Value-Object: ", arguments.CacheItem.Value.ToString());

        }

        #endregion
    }
}
