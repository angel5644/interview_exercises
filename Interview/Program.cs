// See https://aka.ms/new-console-template for more information
using Interview.Core;
using Interview.MiniApp;

IMiniApp miniApp = MiniAppFactory.CreateMiniApp(nameof(ReflectionMiniApp));

Console.WriteLine("Welcome to: {0}", miniApp.DisplayName());

miniApp.Run();

Console.WriteLine("End! Press any key to exit!");
Console.ReadLine();

