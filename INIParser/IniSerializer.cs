using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INIParser
{
    public class IniSerializer
    {
        public string Serialize(object obj, IniConfiguration config)
        {
            var objProps = obj.GetType().GetProperties()
                .Where(x => x.CanRead && 
                !x.PropertyType.IsGenericType &&
                (x.PropertyType.IsPrimitive || x.PropertyType == typeof(string)))
                .Select(x => (x.Name, x.GetValue(obj)));

            var serialized = string.Empty;
            serialized += $"[{obj.GetType().Name}]\n";
            foreach (var item in objProps)
            {
                serialized += $"{item.Name} {config.AssignmentSymbol} {item.Item2}\n";
            }
            return serialized;

        }
        public string Serialize(object obj)
        {
            return Serialize(obj, new IniConfiguration());
        }
    }
}
