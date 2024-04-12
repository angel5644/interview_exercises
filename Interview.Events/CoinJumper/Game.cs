namespace Interview.Events.CoinJumper
{
    public delegate void OnSpacebarPressedCallback();

    public class Game : IDisposable
    {
        public event OnSpacebarPressedCallback? OnSpaceBarPressedCallback;

        private Player? player;
        private readonly int coinsPerJump = 10;
        public bool IsGameOver = false;
        private bool disposedValue;

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

                ShowPlayerStats();
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

        private void ShowPlayerStats()
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

        private void UnSubscribeEvents() 
        {
            var subscribers = OnSpaceBarPressedCallback?.GetInvocationList() ?? new Delegate[] { };

            foreach (var subscriber in subscribers)
            {
                OnSpaceBarPressedCallback -= (subscriber as OnSpacebarPressedCallback);
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // Dispose managed state (managed objects)
                    UnSubscribeEvents();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
