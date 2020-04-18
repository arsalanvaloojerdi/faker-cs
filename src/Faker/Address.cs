using Faker.Extensions;
using Faker.Resources.Addresses;
using System;
using System.Collections.Generic;

namespace Faker
{
    public static class Address
    {
        private static readonly IEnumerable<Func<string>> CityFormats = new List<Func<string>>
        {
            () => $"{CityPrefix()} {Name.First()}{CitySuffix()}",
            () => $"{CityPrefix()} {Name.First()}",
            () => $"{Name.First()}{CitySuffix()}",
            () => $"{Name.Last()}{CitySuffix()}"
        };

        private static readonly IEnumerable<Func<string[]>> StreetFormats = new List<Func<string[]>>
        {
            () => new[] {Name.Last(), StreetSuffix()},
            () => new[] {Name.First(), StreetSuffix()}
        };

        private static readonly IEnumerable<Func<string>> StreetAddressFormats = new List<Func<string>>
        {
            () => string.Format(UsAddresses.AddressFormat.Split(Config.Separator).Random().Trim(), StreetName())
        };

        public static string Country()
        {
            return UsAddresses.Country.Split(Config.Separator).Random().Trim();
        }

        public static string ZipCode()
        {
            return UsAddresses.ZipCode.Split(Config.Separator).Random().Trim().Numerify();
        }

        public static string UsMilitaryState()
        {
            return UsAddresses.UsMilitaryState.Split(Config.Separator).Random().Trim();
        }

        public static string UsMilitaryStateAbbr()
        {
            return UsAddresses.UsMilitaryStateAbbr.Split(Config.Separator).Random();
        }

        public static string UsTerritory()
        {
            return UsAddresses.UsTerritory.Split(Config.Separator).Random().Trim();
        }

        public static string UsTerritoryStateAbbr()
        {
            return UsAddresses.UsTerritoryAbbr.Split(Config.Separator).Random();
        }

        public static string UsState()
        {
            return UsAddresses.UsState.Split(Config.Separator).Random().Trim();
        }

        public static string UsStateAbbr()
        {
            return UsAddresses.UsStateAbbr.Split(Config.Separator).Random();
        }

        public static string CityPrefix()
        {
            return UsAddresses.CityPrefix.Split(Config.Separator).Random();
        }

        public static string CitySuffix()
        {
            return UsAddresses.CitySufix.Split(Config.Separator).Random();
        }

        public static string City()
        {
            return CityFormats.Random();
        }

        public static string StreetSuffix()
        {
            return UsAddresses.StreetSuffix.Split(Config.Separator).Random();
        }

        public static string StreetName()
        {
            var result = string.Join(UsAddresses.StreetNameSeparator, StreetFormats.Random());
            return result;
        }

        public static string StreetAddress(bool includeSecondary = false)
        {
            return StreetAddressFormats.Random().Numerify() + (includeSecondary ? " " + SecondaryAddress() : "");
        }

        public static string SecondaryAddress()
        {
            return UsAddresses.SecondaryAddress.Split(Config.Separator).Random().Trim().Numerify();
        }

        public static string UkCounty()
        {
            return UsAddresses.UkCounties.Split(Config.Separator).Random().Trim();
        }

        public static string UkCountry()
        {
            return UsAddresses.UkCountry.Split(Config.Separator).Random().Trim();
        }

        public static string UkPostCode()
        {
            return UsAddresses.UkPostCode.Split(Config.Separator).Random().Trim().Numerify().Letterify();
        }
    }
}