using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Faker.Extensions;
using Faker.Resources.Identifications;

namespace Faker
{
    public static class Identification
    {
        /*
        Position 1 – numeric values 1 thru 9
        Position 2 – alphabetic values A thru Z (minus S, L, O, I, B, Z)
        Position 3 – alpha-numeric values 0 thru 9 and A thru Z (minus S, L, O, I, B, Z) Position 4 – numeric values 0 thru 9
        Position 4 – numeric values 0 thru 9
        Position 5 – alphabetic values A thru Z (minus S, L, O, I, B, Z)
        Position 6 – alpha-numeric values 0 thru 9 and A thru Z (minus S, L, O, I, B, Z) Position 7 – numeric values 0 thru 9
        Position 7 – numeric values 0 thru 9
        Position 8 – alphabetic values A thru Z (minus S, L, O, I, B, Z)
        Position 9 – alphabetic values A thru Z (minus S, L, O, I, B, Z)
        Position 10 – numeric values 0 thru 9
        Position 11 – numeric values 0 thru 9
        */
        // https://www.cms.gov/Medicare/New-Medicare-Card/Understanding-the-MBI-with-Format.pdf
        public static string MedicareBeneficiaryIdentifier()
        {
            return string.Join("", new[]
            {
                Identifications.MbiNumeric.Split(Config.Separator).Random(),
                Identifications.MbiAlphabet.Split(Config.Separator).Random(),
                Identifications.Mbi.Split(Config.Separator).Random(),
                Identifications.Numeric.Split(Config.Separator).Random(),
                Identifications.MbiAlphabet.Split(Config.Separator).Random(),
                Identifications.Mbi.Split(Config.Separator).Random(),
                Identifications.Numeric.Split(Config.Separator).Random(),
                Identifications.MbiAlphabet.Split(Config.Separator).Random(),
                Identifications.MbiAlphabet.Split(Config.Separator).Random(),
                Identifications.Numeric.Split(Config.Separator).Random(),
                Identifications.Numeric.Split(Config.Separator).Random(),
            });
        }

        /// <summary>
        /// Return a list of integers from min to max value inclusive that satisfy check condition
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max">Inclusive</param>
        /// <param name="conditionFn">All values are valid if not specified</param>
        /// <returns></returns>
        private static IEnumerable<int> Range(int min, int max, Func<int, bool> conditionFn = null)
        {
            var range = new List<int>();
            if (min > max)
            {
                return range;
            }
            var current = min;
            do
            {
                if (conditionFn(current))
                {
                    range.Add(current);
                }
                current++;
            } while (current <= max);
            return range;
        }

        private static readonly Func<int, bool> IsEvenFn = z => z % 2 == 0;

        public static string SocialSecurityNumber(bool dashFormat = true)
        {
            var area = RandomNumber.Next(1, 650);
            /*
            Odd numbers, 01 to 09
            Even numbers, 10 to 98
            Even numbers, 02 to 08
            Odd numbers, 11 to 99
            */
            var groups = Range(1, 9, z=> !IsEvenFn(z)).ToList();
            groups.AddRange(Range(10, 98, IsEvenFn));
            groups.AddRange(Range(2, 8, IsEvenFn));
            groups.AddRange(Range(11, 99,z=> !IsEvenFn(z)));

            var group = groups.ElementAt(RandomNumber.Next(0, groups.Count));
            var serial = RandomNumber.Next(1, 9999);
            var ssn = $"{area:000}-{group:00}-{serial:0000}";
            return !dashFormat ? ssn.Replace("-", "") : ssn;
        }

        // https://en.wikipedia.org/wiki/Jeanne_Calment
        public const int MaxAgeAllowed = 122;

        public static DateTime DateOfBirth()
        {
            var rnd = new Random((int)DateTime.UtcNow.Ticks);
            var first = rnd.NextDouble();
            var second = rnd.NextDouble();

            var randStdNormal = Math.Sqrt(-2.0 * Math.Log(first)) * Math.Sin(2.0 * Math.PI * second);
            const double average = MaxAgeAllowed * .5;
            var randNormal = average + 46 * randStdNormal;
            var yearsToSubtract =  (int) Math.Abs(randNormal);
            if (yearsToSubtract > MaxAgeAllowed)
            {
                yearsToSubtract = (int) average;
            }
            var now = DateTime.UtcNow;
            var randomDay = RandomNumber.Next(1, 365); // Skip leap years for simplicity
            if (yearsToSubtract < 1)
            {
                randomDay = RandomNumber.Next(1, now.DayOfYear);
            }
            var gaussianDate = now.AddYears(yearsToSubtract * -1).AddDays(randomDay * -1);
            return gaussianDate.Date;
        }

        public static string UkNationalInsuranceNumber()
        {
            var niNumber = new StringBuilder();
            niNumber.Append(Identifications.Alphabet.Split(Config.Separator).Random());
            niNumber.Append(Identifications.Alphabet.Split(Config.Separator).Random());

            for (var i = 0; i < 6; i++)
                niNumber.Append(RandomNumber.Next(0, 9));

            niNumber.Append(Identifications.Alphabet.Split(Config.Separator).Random());

            return niNumber.ToString();
        }

        public static string UkPassportNumber()
        {
            return NineDigitPassportNumber();
        }

        public static string UsPassportNumber()
        {
            return NineDigitPassportNumber();
        }

        private static string NineDigitPassportNumber()
        {
            var passportNumber = new StringBuilder();

            for (var i = 0; i < 9; i++)
                passportNumber.Append(Identifications.Numeric.Split(Config.Separator).Random());

            return passportNumber.ToString();
        }
    }
}
