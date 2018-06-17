using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Commons
{
    public static class AssemblyUtils
    {
        public static IEnumerable<Type> GetTypesSubclassOf<T>()
        {
            return GetTypes<T>((t1, t2) => t1.IsSubclassOf(t2));
        }

        public static IEnumerable<Type> GetTypesImplements<T>()
        {
            return GetTypes<T>((t1, t2) => t1.GetInterfaces().Contains(t2));
        }

        private static IEnumerable<Type> GetTypes<T>(Func<Type, Type, bool> predicate)
        {
            var type = typeof(T);
            var assembly = Assembly.GetEntryAssembly();
            return assembly.GetTypes().
                Where(t => predicate(t, type));
        }
    }
}
