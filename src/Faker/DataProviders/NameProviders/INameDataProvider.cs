using Faker.Enums;

namespace Faker.DataProviders.NameProviders
{
    public interface INameDataProvider
    {
        Language Language { get; }
        string GetRandomFirstName();
        string GetRandomMiddleName();
        string GetRandomLastName();
        string GetRandomPrefix();
        string GetRandomSuffix();
    }
}