using Interview.RabbitMQ;

namespace Interview.EventsAndHandlers.Events
{
    /// <summary>
    /// Triggered when a user is registered
    /// </summary>
    public class UserRegistered : IEvent
    {
        public int Id { get; set; }
        public int Name { get; set; }

        public DateTime Timestamp => DateTime.UtcNow;
    }


}
