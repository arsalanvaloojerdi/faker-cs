using Faker.Extensions;
using Faker.Resources.Companies;
using static Faker.Config;

namespace Faker.DataProviders.CompanyProviders
{
    public class IranCompanyDataProvider : ICompanyDataProvider
    {
        /// <inheritdoc />
        public Enums.Country Country => Enums.Country.Iran;

        /// <inheritdoc />
        public string GetRandomCompany()
        {
            return IranCompanies.Name.Split(Separator).Random();
        }
    }
}