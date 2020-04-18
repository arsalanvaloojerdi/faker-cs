using System;
using System.Collections.Generic;
using System.Linq;
using Faker.Extensions;

namespace Faker
{
    public static class Lorem
    {
        public static IEnumerable<string> Words(int count)
        {
            if (count <= 0) throw new ArgumentException(@"Count must be greater than zero", nameof(count));

            return count.Times(x => Resources.Lorems.Lorem.Words.Split(Config.Separator).Random());
        }

        public static string GetFirstWord()
        {
            return Resources.Lorems.Lorem.Words.Split(Config.Separator).First();
        }

        public static string Sentence(int minWordCount)
        {
            if (minWordCount <= 0)
                throw new ArgumentException(@"Count must be greater than zero", nameof(minWordCount));

            return string.Join(" ", Words(minWordCount + RandomNumber.Next(6)).ToArray()).Capitalise() + ".";
        }

        public static string Sentence()
        {
            return Sentence(4);
        }

        public static IEnumerable<string> Sentences(int sentenceCount)
        {
            if (sentenceCount <= 0)
                throw new ArgumentException(@"Count must be greater than zero", nameof(sentenceCount));

            return sentenceCount.Times(x => Sentence());
        }

        public static string Paragraph(int minSentenceCount)
        {
            if (minSentenceCount <= 0)
                throw new ArgumentException(@"Count must be greater than zero", nameof(minSentenceCount));

            return string.Join(" ", Sentences(minSentenceCount + RandomNumber.Next(3)).ToArray());
        }

        public static string Paragraph()
        {
            return Paragraph(3);
        }

        public static IEnumerable<string> Paragraphs(int paragraphCount)
        {
            if (paragraphCount <= 0)
                throw new ArgumentException(@"Count must be greater than zero", nameof(paragraphCount));

            return paragraphCount.Times(x => Paragraph());
        }
    }
}