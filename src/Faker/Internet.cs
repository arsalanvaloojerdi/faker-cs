using Faker.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Faker
{
    public static class Internet
    {
        private static readonly IEnumerable<Func<string>> UserNameFormats = new List<Func<string>>
        {
            () => Name.First().AlphanumericOnly().ToLowerInvariant(),
            () => $"{Name.First().AlphanumericOnly()}{new[] {".", "_"}.Random()}{Name.Last().AlphanumericOnly()}"
                .ToLowerInvariant()
        };

        public static string Email()
        {
            return $"{UserName()}@{DomainName()}";
        }

        public static string Email(string name)
        {
            return $"{UserName(name)}@{DomainName()}";
        }

        public static string FreeEmail()
        {
            return $"{UserName()}@{Resources.Internets.Internet.FreeMail.Split(Config.Separator).Random()}";
        }

        public static string UserName()
        {
            return UserNameFormats.Random();
        }

        public static string UserName(string name)
        {
            return Regex.Replace(name, @"[^\w]+", x => new[] { ".", "_" }.Random(), RegexOptions.Compiled)
                .ToLowerInvariant();
        }

        public static string DomainName()
        {
            return $"{DomainWord()}.{DomainSuffix()}";
        }

        public static string Url()
        {
            var subDomain = Resources.Internets.Internet.SubDomain.Split(Config.Separator).Random();
            var page = Resources.Internets.Internet.Page.Split(Config.Separator).Random();
            var pageSuffix = Resources.Internets.Internet.PageSuffix.Split(Config.Separator).Random();
            return $"http://www.{DomainName()}/{subDomain}/{page}.{pageSuffix}";
        }

        public static string SecureUrl()
        {
            var subDomain = Resources.Internets.Internet.SubDomain.Split(Config.Separator).Random();
            var page = Resources.Internets.Internet.Page.Split(Config.Separator).Random();
            var pageSuffix = Resources.Internets.Internet.PageSuffix.Split(Config.Separator).Random();
            return $"https://www.{DomainName()}/{subDomain}/{page}.{pageSuffix}";
        }

        public static string DomainWord()
        {
            return Company.Name().Split(' ').First().AlphanumericOnly().ToLowerInvariant();
        }

        public static string DomainSuffix()
        {
            return Resources.Internets.Internet.DomainSuffix.Split(Config.Separator).Random();
        }
    }
}