using System;

namespace NatsTest
{
    public class TestMessage : Message
    {
        public override string Subject { get { return MessageSubject; } }

        public DateTime Timestamp { get; set; }

        public string Content { get; set; }

        public static string MessageSubject = "natstest.testqueue";
    }
}
