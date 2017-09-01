namespace _06.ReverseArrayOfStrings
{
    using System;
    using System.Linq;

    class ReverseArrayOfStrings
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(' ');

            // First Solution
            for (int i = 0; i < input.Length / 2; i++)
            {
                string a = input[i];
                string b = input[input.Length - i - 1];
                string c = a;

                input[i] = b;
                input[input.Length - i - 1] = c;
            }

            Console.WriteLine(string.Join(" ", input));

            // Second Solution
            //Console.WriteLine(string.Join(" ", input.Reverse()));
        }
    }
}
