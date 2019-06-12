using System;

namespace NatsTest
{
    class Program
    {
        static void Main(string[] args)
        {
            TestMessage msg = new TestMessage()
            {
                Content = "My test message",
                Timestamp = DateTime.Now
            };

            MessageQueue.Publish(msg);

            Console.WriteLine("Message published!");
        }
    }
}
