using Faker.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Faker.DataProviders.CompanyProviders
{
    public static class CompanyDataProviderFactory
    {
        private static readonly IEnumerable<ICompanyDataProvider> Providers =
            Assembly.GetExecutingAssembly().ThatImplements<ICompanyDataProvider>();

        public static ICompanyDataProvider GetProvider(Enums.Country country)
        {
            return Providers.FirstOrDefault(provider => provider?.Country == country);
        }
    }
}