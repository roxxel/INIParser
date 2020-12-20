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
            var message = new Message
            {
                SenderName = "Ben",
                SenderPhone = "+281726347181",
                Content = "Hello, how it's going?",
                RecepientName = "Roxxel",
                RecepientPhone = "+747381817234"
            };

            var serialized = serializer.Serialize(message);
            File.WriteAllText("Files/serialized.ini", serialized);
        }
        [Fact]
        public void DoTestWithConfig()
        {
            var serializer = new IniSerializer();
            var message = new Message
            {
                SenderName = "Ben",
                SenderPhone = "+281726347181",
                Content = "Hello, how it's going?",
                RecepientName = "Roxxel",
                RecepientPhone = "+747381817234"
            };

            var serialized = serializer.Serialize(message, new IniConfiguration { AssignmentSymbol = "->" });
            File.WriteAllText("Files/serialized_with_config.ini", serialized);
        }

    }


    public class Message
    {
        public string SenderPhone { get; set; }
        public string SenderName { get; set; }
        public string RecepientName { get; set; }
        public string RecepientPhone { get; set; }
        public string Content { get; set; }
    }
}
