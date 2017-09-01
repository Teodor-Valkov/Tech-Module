namespace _06.StringsAndObjects
{
    using System;

    class StringsAndObjects
    {
        static void Main()
        {
            string firstWord = Console.ReadLine();
            string secondWord = Console.ReadLine();

            object thirdWord = firstWord + " " + secondWord;
            string result = (string)thirdWord;

            Console.WriteLine(result);
        }
    }
}
