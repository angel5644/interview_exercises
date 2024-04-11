using Interview.Core;
using Interview.Events.CoinJumper;
using System.Numerics;

namespace Interview.MiniApp
{
    public class EventPlayerMiniApp : IMiniApp
    {
        public string DisplayName()
        {
            return "Coin Jumper - MiniApp (Events and event handler)";
        }

        public void Run()
        {
            var game = new Game();

            Console.WriteLine("Starting Coin Jumper Game");
            Console.WriteLine("Instructions:");
            Console.WriteLine("- Press spacebar to jump");

            game.Start();

            while (!game.IsGameOver) 
            {
                game.ListenForUserToJump();
            }
        }
    }
}
