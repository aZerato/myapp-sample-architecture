
using System.Runtime.Caching;

namespace MyApp.CrossCutting;

/// <inheritdoc cref="ICacheManager"/>
public class CacheManager : ICacheManager
{
    /// <inheritdoc cref="ICacheManager.Add(string, object)"/>
    void ICacheManager.Add(string key, object value)
    {
        ObjectCache cacheInstance = MemoryCache.Default;

        if (cacheInstance.Contains(key))
        {
            cacheInstance.Remove(key);
        }

        cacheInstance.Add(key, value, ObjectCache.InfiniteAbsoluteExpiration);
    }

    /// <inheritdoc cref="ICacheManager.Get(string)"/>
    object ICacheManager.Get(string key)
    {
        ObjectCache cacheInstance = MemoryCache.Default;

        if (cacheInstance.Contains(key))
        {
            return cacheInstance[key];
        }

        return null!;
    }

    /// <inheritdoc cref="ICacheManager.GetAll()"/>
    List<KeyValuePair<string, object>> ICacheManager.GetAll()
    {
        ObjectCache cacheInstance = MemoryCache.Default;

        return cacheInstance.ToList();
    }

    /// <inheritdoc cref="ICacheManager.Clear(string)"/>
    void ICacheManager.Clear(string key)
    {
        ObjectCache cacheInstance = MemoryCache.Default;

        if (cacheInstance.Contains(key))
        {
            cacheInstance.Remove(key);
        }
    }
}