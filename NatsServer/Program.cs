using System;
using NATS.Client;

namespace NatsTest
{
    class Program
    {
        private static string MQ_URL = "nats://localhost:4222";
        private const string QUEUE_GROUP = "save-handler";

        static void Main(string[] args)
        {
            Console.WriteLine($"Connecting to message queue url: {MQ_URL}");
            using (var connection = MessageQueue.CreateConnection())
            {
                var subscription = connection.SubscribeAsync(TestMessage.MessageSubject, QUEUE_GROUP);
                subscription.MessageHandler += ProcessMessage;
                subscription.Start();
                Console.WriteLine($"Listening on subject: {TestMessage.MessageSubject}, queue: {QUEUE_GROUP}");

                Console.ReadLine();
                connection.Close();
            }
        }

        private static void ProcessMessage(object sender, MsgHandlerEventArgs e)
        {
            Console.WriteLine($"Received message, subject: {e.Message.Subject}");
            var msg = MessageHelper.FromData<TestMessage>(e.Message.Data);
            Console.WriteLine($"New message - Content: {msg.Content}; Timestamp: {msg.Timestamp}, CorrelationId:  {msg.CorrelationId}");
        }
    }
}
