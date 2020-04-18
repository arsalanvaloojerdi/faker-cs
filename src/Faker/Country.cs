using Faker.Extensions;
using Faker.Resources.Countries;

namespace Faker
{
    public static class Country
    {
        public static string TwoLetterCode()
        {
            return Countries.Iso2LetterCodes.Split(Config.Separator).Random();
        }

        public static string Name()
        {
            return Countries.Names.Split(Config.Separator).Random();
        }
    }
}