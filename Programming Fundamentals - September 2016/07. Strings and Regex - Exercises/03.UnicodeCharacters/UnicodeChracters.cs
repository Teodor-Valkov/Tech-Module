namespace _03.UnicodeCharacters
{
    using System;
    using System.Text;

    internal class UnicodeChracters
    {
        private static void Main()
        {
            string input = Console.ReadLine();

            string convertedInput = ConvertToUnicode(input);

            Console.WriteLine(convertedInput);
        }

        private static string ConvertToUnicode(string str)
        {
            StringBuilder utf = new StringBuilder(str.Length * 6);

            foreach (char c in str)
            {
                utf.AppendFormat($@"\u{(int)c:X4}");
            }

            return utf.ToString().ToLower();
        }
    }
}