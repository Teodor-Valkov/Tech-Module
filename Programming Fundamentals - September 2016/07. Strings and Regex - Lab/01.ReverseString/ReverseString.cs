namespace _01.ReverseString
{
    using System;

    class ReverseString
    {
        static void Main()
        {
            string input = Console.ReadLine();

            if (input != null)
            {
                char[] reversedInput = input.ToCharArray();
                Array.Reverse(reversedInput);

                Console.WriteLine(string.Join("", reversedInput));
            }
        }
    }
}
