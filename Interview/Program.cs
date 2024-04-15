// See https://aka.ms/new-console-template for more information
using Interview.Core;
using Interview.DesignPatterns.Singleton;
using Interview.MiniApp;
using Microsoft.Extensions.DependencyInjection;

//IServiceCollection services = new ServiceCollection();

//services.AddSingleton<CacheManager>();


IMiniApp miniApp = MiniAppFactory.CreateMiniApp(nameof(SingletonMiniApp));

Console.WriteLine("Welcome to: {0}", miniApp.DisplayName());

miniApp.Run();

Console.WriteLine("End! Press any key to exit!");
Console.ReadLine();

