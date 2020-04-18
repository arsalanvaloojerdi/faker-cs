using Faker.Enums;
using System;
using System.Linq;
using System.Reflection;

namespace Faker.DataProviders.NameProviders
{
    public static class NameProviderFactory
    {
        public static INameProvider GetProvider(Language language)
        {
            var providers = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type =>
                    !type.IsAbstract && type.GetInterfaces().Contains(typeof(INameProvider)))
                .ToList().Select(type => Activator.CreateInstance(type) as INameProvider);

            return providers.FirstOrDefault(provider => provider?.Language == language);
        }
    }
}