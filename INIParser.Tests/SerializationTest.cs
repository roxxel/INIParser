using System.IO;
using Xunit;

namespace INIParser.Tests
{
    public class SerializationTest
    {
        [Fact]
        public void DoTest()
        {
            var serializer = new IniSerializer();
            var message = new Message()
            {
                MessageId = 123,
                SenderName = "Ben",
                SenderPhone = "+281726347181",
                Content = "Hello, how it's going?",
                RecepientName = "Roxxel",
                RecepientPhone = "+747381817234"
            };

            var serialized = serializer.Serialize(message, new IniConfiguration { IgnoreAttributes = true });
            File.WriteAllText("Assets/serialized.ini", serialized);
        }
        [Fact]
        public void DoTestWithConfig()
        {
            var serializer = new IniSerializer();
            var message = new Message()
            {
                MessageId = 123,
                SenderName = "Ben",
                SenderPhone = "+281726347181",
                Content = "Hello, how it's going?",
                RecepientName = "Roxxel",
                RecepientPhone = "+747381817234"
            };

            var serialized = serializer.Serialize(message, new IniConfiguration { AssignmentSymbol = "->", IgnoreAttributes = true });
            File.WriteAllText("Assets/serialized_with_config.ini", serialized);
        }

        [Fact]
        public void DoTestWithAttributes()
        {
            var serializer = new IniSerializer();
            var message = new Message()
            {
                MessageId = 123,
                SenderName = "Ben",
                SenderPhone = "+281726347181",
                Content = "Hello, how it's going?",
                RecepientName = "Roxxel",
                RecepientPhone = "+747381817234"
            };

            var serialized = serializer.Serialize(message, new IniConfiguration { AssignmentSymbol = "->" });
            File.WriteAllText("Assets/serialized_with_attributes.ini", serialized);
        }

    }
}
