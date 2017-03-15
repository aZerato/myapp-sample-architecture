namespace MyApp.CrossCutting
{
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
        /// Remove an object from cache.
        /// </summary>
        /// <param name="key">The object cache key.</param>
        void Clear(string key);
    }
}
