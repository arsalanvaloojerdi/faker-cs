using Faker.Extensions;
using Faker.Resources.Companies;
using static Faker.Config;

namespace Faker.DataProviders.CompanyProviders
{
    public class UsCompanyDataProvider : ICompanyDataProvider
    {
        /// <inheritdoc />
        public Enums.Country Country => Enums.Country.Us;

        /// <inheritdoc />
        public string GetRandomCompany()
        {
            return UsCompanies.Name.Split(Separator).Random();
        }
    }
}