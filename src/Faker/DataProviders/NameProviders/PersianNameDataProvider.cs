using Faker.Enums;
using Faker.Extensions;
using Faker.Resources.Names;
using static Faker.Config;

namespace Faker.DataProviders.NameProviders
{
    public class PersianNameDataProvider : INameDataProvider
    {
        /// <inheritdoc />
        public Language Language => Language.Persian;

        /// <inheritdoc />
        public string GetRandomFirstName() => PersianNames.FirstName.Split(Separator).Random();

        /// <inheritdoc />
        public string GetRandomMiddleName() => GetRandomFirstName();

        /// <inheritdoc />
        public string GetRandomLastName() => PersianNames.LastName.Split(Separator).Random();

        /// <inheritdoc />
        public string GetRandomPrefix() => PersianNames.Prefix.Split(Separator).Random();

        /// <inheritdoc />
        public string GetRandomSuffix() => PersianNames.LastName.Split(Separator).Random();
    }
}