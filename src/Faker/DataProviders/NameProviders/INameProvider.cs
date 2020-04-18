using Faker.Enums;

namespace Faker.DataProviders.NameProviders
{
    public interface INameProvider
    {
        Language Language { get; }
        string GetRandomFirstName();
        string GetRandomMiddleName();
        string GetRandomLastName();
        string GetRandomPrefix();
        string GetRandomSuffix();
    }
}