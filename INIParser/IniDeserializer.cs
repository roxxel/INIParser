using INIParser.Attributes;
using INIParser.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INIParser
{
    public class IniDeserializer
    {
        public T Deserialize<T>(IniFile ini, string section)
        {
            if (!ini.Sections.Select(x => x.Name).Contains(section))
                throw new ArgumentException($"Ini doesn't contain {section} section");

            var type = typeof(T);
            var obj = (T)Activator.CreateInstance(type);

            var objProps = obj.GetType().GetProperties()
                .Where(x => x.CanWrite &&
                !x.PropertyType.IsGenericType &&
                (x.PropertyType.IsPrimitive || x.PropertyType == typeof(string))).ToArray();

            foreach (var prop in objProps)
            {
                var iniName = (IniPropertyName)prop.GetCustomAttributes(false).Where(x => x is IniPropertyName).FirstOrDefault();
                string propName = null;
                if (iniName != null)
                    propName = iniName.Name;
                else
                    propName = prop.Name;
                var value = ini[section][propName];
                if (value == null)
                    continue;
                    
                prop.SetValue(obj, value);
            }
            return obj;

        }

    }
}
