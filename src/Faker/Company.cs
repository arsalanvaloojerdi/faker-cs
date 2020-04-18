using Faker.Extensions;
using Faker.Resources.Companies;
using System;
using System.Collections.Generic;

namespace Faker
{
    public static class Company
    {
        private static readonly IEnumerable<Func<string>> NameFormats = new List<Func<string>>
        {
            () => $"{Faker.Name.Last()} {Suffix()}",
            () => $"{Faker.Name.Last()}-{Faker.Name.Last()}",
            () => $"{Faker.Name.Last()}, {Faker.Name.Last()} {UsCompanies.And} {Faker.Name.Last()}"
        };

        public static string Name()
        {
            return NameFormats.Random();
        }

        public static string Suffix()
        {
            return UsCompanies.Suffix.Split(Config.Separator).Random();
        }

        /// <summary>
        ///     Generate a buzzword-laden catch phrase.
        ///     Wordlist from http://www.1728.com/buzzword.htm
        /// </summary>
        public static string CatchPhrase()
        {
            return String.Empty;
        }

        /// <summary>
        ///     When a straight answer won't do, BS to the rescue!
        ///     Wordlist from http://dack.com/web/bullshit.html
        /// </summary>
        public static string BS()
        {
            return string.Empty;
        }
    }
}