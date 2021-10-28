using System;

namespace INIParser.Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class IniPropertyName : Attribute
    {
        public string Name { get; }

        public IniPropertyName(string name)
        {
            Name = name;
        }
    }
}
