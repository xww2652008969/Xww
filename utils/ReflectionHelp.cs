using System.Reflection;

namespace Xww;

public class ReflectionHelp
{
    public static bool IsValueInClass<T>(Type type, T value)
    {
        {
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);
            return fields.Any(field => EqualityComparer<T>.Default.Equals((T)field.GetValue(null), value));
        }
    }
}