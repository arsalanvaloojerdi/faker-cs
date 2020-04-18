using Faker.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Faker.DataProviders.NameProviders
{
    public static class NameDataProviderFactory
    {
        private static readonly IEnumerable<INameDataProvider> Providers = Assembly.GetExecutingAssembly().GetTypes()
            .Where(type => !type.IsAbstract && type.GetInterfaces().Contains(typeof(INameDataProvider))).ToList()
            .Select(type => Activator.CreateInstance(type) as INameDataProvider);

        public static INameDataProvider GetProvider(Language language)
        {
            return Providers.FirstOrDefault(provider => provider?.Language == language);
        }
    }
}