namespace Interview.Events.CoinJumper
{
    // Step 1: Define a delegate, the actions the player can take
    public delegate void OnJumpCallback();
    public delegate void OnRunOutJumpsCallback();

    public class Player
    {
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
    }
}
