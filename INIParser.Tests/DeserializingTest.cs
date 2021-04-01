using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace INIParser.Tests
{
    public class DeserializingTest
    {

        [Fact]
        public void DoTest()
        {

            var ini = new IniDataParser().ParseFromFile("Assets/deserialize.ini");
            var deserializer = new IniDeserializer();
            Message message = deserializer.Deserialize<Message>(ini, "Message");
            Assert.Equal(123, message.MessageId);
            Assert.Equal("+281726347181", message.SenderPhone);
            Assert.Equal("Ben", message.SenderName);
            Assert.Equal("Roxxel", message.RecepientName);
            Assert.Equal("+747381817234", message.RecepientPhone);
            Assert.Equal("Hello, how's it going?", message.Content);

        }
    }


}
