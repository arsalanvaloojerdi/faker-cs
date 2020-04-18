using Faker.Enums;
using Faker.Extensions;
using Faker.Resources.Names;
using static Faker.Config;

namespace Faker.DataProviders.NameProviders
{
    public class EnglishNameDataProvider : INameDataProvider
    {
        /// <inheritdoc />
        public Language Language => Language.English;

        /// <inheritdoc />
        public string GetRandomFirstName() => EnglishNames.FirstName.Split(Separator).Random().Trim();

        /// <inheritdoc />
        public string GetRandomMiddleName() => GetRandomFirstName();

        /// <inheritdoc />
        public string GetRandomLastName() => EnglishNames.LastName.Split(Separator).Random().Trim();

        /// <inheritdoc />
        public string GetRandomPrefix() => EnglishNames.Prefix.Split(Separator).Random();

        /// <inheritdoc />
        public string GetRandomSuffix() => EnglishNames.Suffix.Split(Separator).Random();
    }
}