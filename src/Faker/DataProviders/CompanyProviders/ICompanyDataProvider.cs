namespace Faker.DataProviders.CompanyProviders
{
    public interface ICompanyDataProvider
    {
        Enums.Country Country { get; }

        string GetRandomCompany();
    }
}