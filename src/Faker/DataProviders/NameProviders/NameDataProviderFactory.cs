using Faker.Enums;
using Faker.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Faker.DataProviders.NameProviders
{
    public static class NameDataProviderFactory
    {
        private static readonly IEnumerable<INameDataProvider> Providers =
            Assembly.GetExecutingAssembly().ThatImplements<INameDataProvider>();

        public static INameDataProvider GetProvider(Language language)
        {
            return Providers.FirstOrDefault(provider => provider?.Language == language);
        }
    }
}