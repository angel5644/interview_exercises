using Microsoft.Extensions.Caching.Memory;

namespace Interview.DesignPatterns.Singleton
{
    /// <summary>
    /// The singleton design pattern falls under the category of creational design patterns. 
    /// Its primary purpose is to ensure that a class has only one instance throughout the lifetime of an application. 
    /// By doing so, it provides a global point of access to that instance. This approach is particularly useful when 
    /// you want to avoid unexpected results due to multiple instances of a class.
    /// </summary>
    public class MemoryCacheManager 
    {
        // 1. Add a private static field to the class for storing the singleton instance.
        private static Lazy<MemoryCacheManager>? cacheManager;

        private readonly IMemoryCache memoryCache;

        private MemoryCacheManager()
        {
            // It initializes an instance of MemoryCache during construction
            var cacheOptions = new MemoryCacheOptions();
            memoryCache = new MemoryCache(cacheOptions);
        }

        // 2. Declare a public static creation method for getting the singleton instance.
        public static MemoryCacheManager GetInstance()
        {
            if (cacheManager is null)
            {
                cacheManager = new Lazy<MemoryCacheManager>(() => new MemoryCacheManager());
            }

            return cacheManager.Value;
        }

        public void AddToCache(string key, object value, TimeSpan expirationTime) 
        {
            memoryCache.Set(key, value, expirationTime);
        }

        public TCacheElement GetFromCache<TCacheElement>(string key) where TCacheElement : class
        {
            if (memoryCache.TryGetValue(key, out TCacheElement? cachedValue)) 
            {
                return cachedValue;
            }

            return default;
        }
    }
}
