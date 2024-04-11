namespace Interview.Events.CoinJumper
{
    public delegate void OnSpacebarPressedCallback();

    public class Game
    {
        public event OnSpacebarPressedCallback? OnSpaceBarPressedCallback;

        private Player? player;
        private readonly int coinsPerJump = 10;
        public bool IsGameOver = false;

        public void Start()
        {
            IsGameOver = false;
            player = new Player()
            {
                JumpsRemaining = 3,
                CoinsCollected = 0
            };

            // Step 4: Subscribe Methods to Events
            player.OnJumpCallback += () =>
            {
                CollectCoins(player);
            };

            player.OnRunOutJumpsCallback += () =>
            {
                EndGame();
            };

            OnSpaceBarPressedCallback += () =>
            {
                Console.WriteLine("Spacebar pressed!");

                // Player actions trigger the subscribed methods
                player?.Jump();

                ShowPlayeStats();
            };
        }

        public void ListenForUserToJump()
        {
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.Spacebar)
                {
                    OnSpaceBarPressedCallback?.Invoke();

                    break;
                }
            }
        }

        private void ShowPlayeStats()
        {
            var stats = System.Text.Json.JsonSerializer.Serialize(player);

            Console.WriteLine("Current stats: {0}", stats);
        }

        private void CollectCoins(Player player)
        {
            player.CoinsCollected += coinsPerJump;
        }

        private void EndGame()
        {
            IsGameOver = true;
            Console.WriteLine("Game over!");
        }
    }
}
