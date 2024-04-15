using Interview.Core;
using Interview.DesignPatterns.Singleton;

namespace Interview.MiniApp
{
    public class SingletonMiniApp : IMiniApp
    {
        public string DisplayName()
        {
            return " - MiniApp (Singleton)";
        }

        public void Run()
        {
            var redisManager = RedisCacheManager.GetInstance();

            redisManager.AddToCache("token", "value_123", new TimeSpan(0, 0, 120));

            var cachedValue = redisManager.GetStringFromCache("token");

            Console.WriteLine("Cached value from redis:{0}", cachedValue);

            var memoryCacheManager = MemoryCacheManager.GetInstance();

            memoryCacheManager.AddToCache("token_memory", "value_456", new TimeSpan(0, 0, 120));

            var cachedValueMemory = memoryCacheManager.GetStringFromCache("token_memory");

            Console.WriteLine("Cached value from memory cache:{0}", cachedValueMemory);
        }
    }
}
