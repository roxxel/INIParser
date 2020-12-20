using System;
using System.Linq;
using Xunit;

namespace INIParser.Tests
{
    public class ParseLineTest
    {
        [Fact]
        public void ShouldParseLine()
        {
            string ini = @"
                #External config (api tokens, links, etc)
                [External]    
                ApiToken = null

                # General config
                [General]
                GenerateConfig = true
            ";

            var parser = new IniDataParser();

            var iniFile = parser.Parse(ini);

            Assert.Equal(2, iniFile.Sections.Count);
            var property1 = iniFile["External"]["ApiToken"];

            var property2 = iniFile["General"]["GenerateConfig"];

            var property3 = iniFile["NotInIniFile"]?["DoSomeStuff"];

            Assert.Equal("null", property1);
            Assert.Equal("true", property2);
            Assert.Null(property3);

        }
    }
}
