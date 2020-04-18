using Faker.Extensions;
using Faker.Resources.Phones;

namespace Faker
{
    public static class Phone
    {
        public static string Number()
        {
            return Phones.Formats.Split(Config.Separator).Random().Trim().Numerify();
        }
    }
}