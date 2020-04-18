using Faker.DataProviders.NameProviders;
using Faker.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Faker
{
    public enum NameFormats
    {
        Standard,
        StandardWithMiddle,
        WithPrefix,
        WithSuffix
    }

    public static class Name
    {
        private static readonly IEnumerable<NameFormats> Formats = new List<NameFormats>
        {
            NameFormats.WithPrefix, NameFormats.WithSuffix, NameFormats.Standard, NameFormats.Standard,
            NameFormats.Standard, NameFormats.Standard, NameFormats.Standard, NameFormats.Standard, NameFormats.Standard
        };

        private static readonly IDictionary<NameFormats, Func<string[]>> FormatMap =
            new Dictionary<NameFormats, Func<string[]>>
            {
                {NameFormats.Standard, () => new[] {First(), Last()}},
                {NameFormats.StandardWithMiddle, () => new[] {First(), Middle(), Last()}},
                {NameFormats.WithPrefix, () => new[] {Prefix(), First(), Last()}},
                {NameFormats.WithSuffix, () => new[] {First(), Last(), Suffix()}}
            };

        /// <summary>
        ///     Create a name using a random format.
        /// </summary>
        public static string FullName()
        {
            return FullName(Formats.ElementAt(RandomNumber.Next(Formats.Count() - 1)));
        }

        /// <summary>
        ///     Create a name using a specified format.
        /// </summary>
        public static string FullName(NameFormats format)
        {
            return string.Join(" ", FormatMap[format].Invoke());
        }

        public static string First()
        {
            return First(Language.English);
        }

        public static string First(Language language)
        {
            return GetProvider(language).GetRandomFirstName();
        }

        public static string Middle()
        {
            return GetProvider(Language.English).GetRandomMiddleName();
        }

        public static string Middle(Language language)
        {
            return GetProvider(language).GetRandomMiddleName();
        }

        public static string Last()
        {
            return GetProvider(Language.English).GetRandomLastName();
        }

        public static string Last(Language language)
        {
            return GetProvider(language).GetRandomLastName();
        }

        public static string Prefix()
        {
            return GetProvider(Language.English).GetRandomPrefix();
        }

        public static string Prefix(Language language)
        {
            return GetProvider(language).GetRandomPrefix();
        }

        public static string Suffix()
        {
            return Suffix(Language.English);
        }

        public static string Suffix(Language language)
        {
            return GetProvider(Language.English).GetRandomSuffix();
        }

        #region PrivateMethods

        private static INameProvider GetProvider(Language language)
        {
            return NameProviderFactory.GetProvider(language);
        }

        #endregion
    }
}