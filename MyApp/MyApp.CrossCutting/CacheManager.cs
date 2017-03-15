namespace MyApp.CrossCutting
{
    using System.Runtime.Caching;

    /// <summary>
    /// Cache Manager.
    /// </summary>
    public class CacheManager : ICacheManager
    {
        /// <summary>
        /// <see cref="ICacheManager.Add(string, object)"/> 
        /// </summary>
        /// <param name="key"><see cref="ICacheManager.Add(string, object)"/></param>
        /// <param name="value"><see cref="ICacheManager.Add(string, object)"/></param>
        public void Add(string key, object value)
        {
            ObjectCache cacheInstance = MemoryCache.Default;

            Clear(key);

            cacheInstance.Add(key, value, ObjectCache.InfiniteAbsoluteExpiration);
        }

        /// <summary>
        /// <see cref="ICacheManager.Clear(string)"/> 
        /// </summary>
        /// <param name="key"><see cref="ICacheManager.Clear(string)"/></param>
        public void Clear(string key)
        {
            ObjectCache cacheInstance = MemoryCache.Default;

            if (cacheInstance.Contains(key))
            {
                cacheInstance.Remove(key);
            }
        }
    }
}
