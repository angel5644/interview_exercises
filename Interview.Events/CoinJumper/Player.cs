namespace Interview.Events.CoinJumper
{
    // Step 1: Define a delegate, the actions the player can take
    public delegate void OnJumpCallback();
    public delegate void OnRunOutJumpsCallback();

    public class Player : IDisposable
    {
        private bool disposedValue;

        public string PlayerName { get; set; } = string.Empty;
        public int CoinsCollected { get; set; } = 10;
        public int JumpsRemaining { get; set; } = 3; // initial jump count

        // Step 2: Declare events using the Delegate
        public event OnJumpCallback? OnJumpCallback;
        public event OnRunOutJumpsCallback? OnRunOutJumpsCallback;


        public void Jump()
        {
            if (JumpsRemaining <= 0)
            {
                Console.WriteLine("No more jumps!!");
                OnRunOutJumpsCallback?.Invoke();

                return;
            }

            JumpsRemaining--;

            // Step 3: Raise the Event
            OnJumpCallback?.Invoke();
        }

        private void UnSubscribeEvents() 
        {
            var subscribersOnJump = OnJumpCallback?.GetInvocationList() ?? new Delegate[] { };

            foreach (var subscriber in subscribersOnJump)
            {
                OnJumpCallback -= (subscriber as OnJumpCallback);
            }

            var subscribersOnRunOutJumps = OnRunOutJumpsCallback?.GetInvocationList() ?? new Delegate[] { };

            foreach (var subscriber in subscribersOnRunOutJumps)
            {
                OnRunOutJumpsCallback -= (subscriber as OnRunOutJumpsCallback);
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // disposing managed state (managed objects)
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
