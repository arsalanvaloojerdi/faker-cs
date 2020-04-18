using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Faker.Extensions
{
    public static class AssemblyExtensions
    {
        public static IEnumerable<T> ThatImplements<T>(this Assembly assembly)
        {
            return assembly.GetTypes()
                .Where(type => !type.IsAbstract && type.GetInterfaces().Contains(typeof(T))).ToList()
                .Select(type => Activator.CreateInstance(type) is T ? (T)Activator.CreateInstance(type) : default(T));
        }
    }
}