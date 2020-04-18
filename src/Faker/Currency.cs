using Faker.Extensions;
using Faker.Resources.Currencies;

namespace Faker
{
    public static class Currency
    {
        public static string ThreeLetterCode()
        {
            return Currencies.Iso3LetterCodes.Split(Config.Separator).Random();
        }

        public static string Name()
        {
            return Currencies.Names.Split(Config.Separator).Random();
        }
    }
}