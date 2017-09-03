namespace _14.IntegerToHexAndBinary
{
    using System;

    internal class IntegerToHexAndBinary
    {
        private static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            string hexadecimal = Convert.ToString(number, 16);
            string binary = Convert.ToString(number, 2);

            Console.WriteLine(hexadecimal.ToUpper());
            Console.WriteLine(binary);
        }
    }
}