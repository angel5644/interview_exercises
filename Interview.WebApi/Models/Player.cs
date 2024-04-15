namespace Interview.WebApi.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string PlayerName { get; set; } = string.Empty;
        public int CoinsCollected { get; set; }
        public int JumpsRemaining { get; set; }
    }
}
