using INIParser.Exceptions;
using System;
using System.IO;
using System.Linq;
using Xunit;

namespace INIParser.Tests
{
    public class ParseFromFileTest
    {
        [Fact]
        public void ShouldParseFromFile()
        {
            var parser = new IniDataParser();

            var iniFile = parser.ParseFromFile("Files/serialized.ini");
            var messageSection = iniFile["Message"];
 
            var senderPhone = messageSection["SenderPhone"];
            var senderName = messageSection["SenderName"];
            var recepientName = messageSection["RecepientName"];
            var recepientPhone = messageSection["RecepientPhone"];
            var content = messageSection["Content"];


            Assert.Equal("+281726347181", senderPhone);
            Assert.Equal("Ben", senderName);
            Assert.Equal("Roxxel", recepientName);
            Assert.Equal("+747381817234", recepientPhone);
            Assert.Equal("Hello, how it's going?", content);

            Assert.Throws(new FileNotFoundException().GetType(), () =>
            {
                parser.ParseFromFile("Files/nothing.ini");
            });
        }
        [Fact]
        public void ShouldParseFromFileWithConfig()
        {
            var parser = new IniDataParser(new IniConfiguration { AssignmentSymbol = "->", CommentSymbol = "//" });

            var iniFile = parser.ParseFromFile("Files/serialized_with_config.ini");
            var messageSection = iniFile["Message"];

            var senderPhone = messageSection["SenderPhone"];
            var senderName = messageSection["SenderName"];
            var recepientName = messageSection["RecepientName"];
            var recepientPhone = messageSection["RecepientPhone"];
            var content = messageSection["Content"];


            Assert.Equal("+281726347181", senderPhone);
            Assert.Equal("Ben", senderName);
            Assert.Equal("Roxxel", recepientName);
            Assert.Equal("+747381817234", recepientPhone);
            Assert.Equal("Hello, how it's going?", content);

            Assert.Throws(new FileNotFoundException().GetType(), () =>
            {
                parser.ParseFromFile("Files/nothing.ini");
            });


        }
    }
}
