using Faker.DataProviders.CompanyProviders;

namespace Faker
{
    public static class Company
    {
        public static string Name()
        {
            return Name(Enums.Country.Us);
        }

        public static string Name(Enums.Country country)
        {
            return GetProvider(country).GetRandomCompany();
        }

        #region PrivateMethods

        private static ICompanyDataProvider GetProvider(Enums.Country country)
        {
            return CompanyDataProviderFactory.GetProvider(country);
        }

        #endregion
    }
}