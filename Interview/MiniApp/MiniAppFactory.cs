using Interview.Core;
using Interview.DesignPatterns.Singleton;

namespace Interview.MiniApp
{
    /// <summary>
    /// The Factory Design Pattern is a creational pattern that provides an interface for creating objects in 
    /// a super-flexible way. It encapsulates the object creation process, allowing you to create objects without 
    /// specifying the exact class of the object that will be created.
    /// </summary>
    public static class MiniAppFactory 
    {
        public static IMiniApp CreateMiniApp(string appName)
        {
            return appName switch
            {
                nameof(DelegatesMiniApp) => new DelegatesMiniApp(),
                nameof(ProblemSandwichMiniApp) => new ProblemSandwichMiniApp(),
                nameof(FacadeMiniapp) => new FacadeMiniapp(),
                nameof(EventPlayerMiniApp) => new EventPlayerMiniApp(),
                nameof(ReflectionMiniApp) => new ReflectionMiniApp(),
                nameof(SingletonMiniApp) => new SingletonMiniApp(),
                _ => throw new ArgumentException("Invalid mini app name"),
            };
        }
    }
}
