using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Interview.RabbitMQ
{
    public interface IEvent 
    {
        DateTime Timestamp { get; }
    }

    public interface IEventHandler<in TEvent>
        where TEvent : IEvent
    {
        Task Handle(TEvent @event);
    }

    public interface IEventBus
    {
        void Publish<TEvent>(TEvent @event) where TEvent : IEvent;
        void Subscribe<TEvent, THandler>()
            where TEvent : IEvent
            where THandler : IEventHandler<TEvent>;
    }

    public class EventBusRabbitMQ : IEventBus, IDisposable
    {
        private readonly string connectionString = "";
        private readonly IModel channel;

        public EventBusRabbitMQ(string connectionString)
        {
            this.connectionString = connectionString;
            var factory = new ConnectionFactory() { HostName = connectionString };

            var connection = factory.CreateConnection();
            channel = connection.CreateModel();
        }

        public void Publish<TEvent>(TEvent @event) where TEvent : IEvent
        {
            var eventName = @event.GetType().Name;

            // Declare a queue for the event
            channel.QueueDeclare(eventName, false, false, false, arguments: null);

            // Serialize the event and publish it
            var body = Encoding.UTF8.GetBytes(System.Text.Json.JsonSerializer.Serialize(@event));

            channel.BasicPublish("", eventName, basicProperties: null, body: body);
        }

        public void Subscribe<TEvent, THandler>()
            where TEvent : IEvent
            where THandler : IEventHandler<TEvent>
        {
            var eventName = typeof(TEvent).Name;

            channel.QueueDeclare(eventName, false, false, false, arguments: null);

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();

                var message = Encoding.UTF8.GetString(body);

                var eventHandled = System.Text.Json.JsonSerializer.Deserialize<TEvent>(message);

                var handler = Activator.CreateInstance<THandler>();

                if (eventHandled is null) 
                {
                    throw new ArgumentNullException("Test");
                }

                handler.Handle(eventHandled);

                channel.BasicAck(ea.DeliveryTag, false);
            };

            channel.BasicConsume(eventName, false, consumer);
        }

        public void Dispose()
        {
            this.Dispose();
        }
    }
}
