namespace MyApp.CrossCutting;

/// <summary>
/// Interface for Cache data.
/// </summary>
public interface ICacheManager
{
    /// <summary>
    /// Add an object in cache.
    /// </summary>
    /// <param name="key">The object cache key.</param>
    /// <param name="value">The object to put in cache</param>
    void Add(string key, object value);

    /// <summary>
    /// Get object value in cache.
    /// </summary>
    /// <param name="key">The object cache key.</param>
    object Get(string key);

    /// <summary>
    /// Get all object in cache.
    /// </summary>
    /// <returns></returns>
    List<KeyValuePair<string, object>> GetAll();

    /// <summary>
    /// Remove an object from cache.
    /// </summary>
    /// <param name="key">The object cache key.</param>
    void Clear(string key);
}