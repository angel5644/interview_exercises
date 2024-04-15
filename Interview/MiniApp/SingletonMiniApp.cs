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

            redisManager.AddToCache("token", "updated_value", new TimeSpan(0, 0, 50));

            var cachedValue = redisManager.GetStringFromCache("token");

            Console.WriteLine(cachedValue);
        }
    }
}
