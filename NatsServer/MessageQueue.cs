using NATS.Client;

namespace NatsTest
{
    public static class MessageQueue
    {
        private static string MQ_URL = "nats://localhost:4222";
        
        public static void Publish<TMessage>(TMessage message)
            where TMessage : Message
        {
            using (var connection = CreateConnection())
            {
                var data = MessageHelper.ToData(message);
                connection.Publish(message.Subject, data);
            }
        }

        public static IConnection CreateConnection()
        {
            return new ConnectionFactory().CreateConnection(MQ_URL);
        }
    }
}
