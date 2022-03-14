using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Qitar.Utils.Reflection
{
    public static class TypeExtensions
    {
        public static bool HasAttribute<T>(this MemberInfo memberInfo, bool inherit = true) where T : Attribute
        {
            return memberInfo.IsDefined(typeof(T), inherit);
        }

        public static Type[] GetAllInheritedTypes(this Type type)
        {
            if (type.IsInterface)
            {
                return Assembly.GetAssembly(type).GetTypes()
                    .Where(_ => _.IsClass && !_.IsAbstract && type.IsAssignableFrom(_)).ToArray();
            }

            if (type.IsAbstract)
            {
                return Assembly.GetAssembly(type).GetTypes()
                    .Where(_ => _.IsClass && !_.IsAbstract && _.IsSubclassOf(type)).ToArray();
            }

            return new Type[] { };
        }
    }
}