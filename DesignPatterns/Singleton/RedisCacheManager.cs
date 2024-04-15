using Microsoft.Extensions.Caching.Memory;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.DesignPatterns.Singleton
{
    public class RedisCacheManager : IDisposable
    {
        // 1. Add a private static field to the class for storing the singleton instance.
        private static Lazy<RedisCacheManager>? cacheManager;
        private static ConnectionMultiplexer? redisConnection;
        private readonly IDatabase redisDatabase;

        private RedisCacheManager()
        {
            // It initializes an instance of MemoryCache during construction
            var options = new ConfigurationOptions()
            {
                DefaultDatabase = 0,
                User = "default",
                Password = "redis123",
                EndPoints =
                {
                    { "localhost", 6379 }
                }
            };
            redisConnection = ConnectionMultiplexer.Connect(options);
            redisDatabase = redisConnection.GetDatabase();
        }

        // 2. Declare a public static creation method for getting the singleton instance.
        public static RedisCacheManager GetInstance()
        {
            if (cacheManager is null)
            {
                cacheManager = new Lazy<RedisCacheManager>(() => new RedisCacheManager());
            }

            return cacheManager.Value;
        }

        public void AddToCache(string key, string value, TimeSpan expirationTime)
        {
            var redisKey = new RedisKey(key);
            var redisValue = new RedisValue(value);

            redisDatabase.StringSet(redisKey, redisValue, expirationTime);
        }

        public string GetStringFromCache(string key) 
        {
            var cachedValue = redisDatabase.StringGet(key);
            if (cachedValue.HasValue)
            {
                return cachedValue.ToString();
            }

            return (string)null;
        }

        public void Dispose()
        {
            redisConnection?.Close();
            redisConnection?.Dispose();
        }
    }
}
