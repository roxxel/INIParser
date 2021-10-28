using INIParser.Attributes;
using System.Linq;
using System.Reflection;

namespace INIParser
{
    public class IniSerializer
    {
        public string Serialize(object obj, IniConfiguration config)
        {
            var objProps = obj.GetType().GetProperties()
                .Where(x => x.CanRead &&
                !x.PropertyType.IsGenericType &&
                (x.PropertyType.IsPrimitive || x.PropertyType == typeof(string)));

            var serialized = string.Empty;
            serialized += $"[{obj.GetType().Name}]\n";
            foreach (var item in objProps)
            {
                string name = item.Name;
                if (!config.IgnoreAttributes)
                {
                    var iniName = item.GetCustomAttributes(false)
                        .Where(x => x is IniPropertyName)
                        .FirstOrDefault() as IniPropertyName;
                    if (iniName != null)
                        name = iniName.Name;
                }
                serialized += $"{name} {config.AssignmentSymbol} {item.GetValue(obj)}\n";
            }
            return serialized;
        }

        public string Serialize(object obj) => Serialize(obj, new IniConfiguration());
    }
}
