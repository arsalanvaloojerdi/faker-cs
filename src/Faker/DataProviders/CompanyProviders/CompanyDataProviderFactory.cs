using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Faker.DataProviders.CompanyProviders
{
    public static class CompanyDataProviderFactory
    {
        private static readonly IEnumerable<ICompanyDataProvider> Providers = Assembly.GetExecutingAssembly().GetTypes()
            .Where(type => !type.IsAbstract && type.GetInterfaces().Contains(typeof(ICompanyDataProvider))).ToList()
            .Select(type => Activator.CreateInstance(type) as ICompanyDataProvider);

        public static ICompanyDataProvider GetProvider(Enums.Country country)
        {
            return Providers.FirstOrDefault(provider => provider?.Country == country);
        }
    }
}