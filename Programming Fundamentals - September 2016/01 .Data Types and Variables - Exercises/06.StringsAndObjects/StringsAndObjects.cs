namespace _06.StringsAndObjects
{
    using System;

    internal class StringsAndObjects
    {
        private static void Main()
        {
            string firstWord = Console.ReadLine();
            string secondWord = Console.ReadLine();

            object thirdWord = firstWord + " " + secondWord;
            string result = (string)thirdWord;

            Console.WriteLine(result);
        }
    }
}