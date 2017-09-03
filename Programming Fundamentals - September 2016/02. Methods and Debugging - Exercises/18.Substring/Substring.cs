namespace _18.Substring
{
    using System;

    internal class Substring
    {
        private static void Main()
        {
            string text = Console.ReadLine();
            int jump = int.Parse(Console.ReadLine());

            bool hasMatch = false;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == 'p')
                {
                    hasMatch = true;
                    string matchedString = string.Empty;

                    if (i + jump <= text.Length - 1)
                    {
                        matchedString = text.Substring(i, jump + 1);
                        i += jump;

                        Console.WriteLine(matchedString);
                    }
                    else
                    {
                        matchedString = text.Substring(i);

                        Console.WriteLine(matchedString);
                        return;
                    }
                }
            }

            if (!hasMatch)
            {
                Console.WriteLine("no");
            }
        }
    }
}