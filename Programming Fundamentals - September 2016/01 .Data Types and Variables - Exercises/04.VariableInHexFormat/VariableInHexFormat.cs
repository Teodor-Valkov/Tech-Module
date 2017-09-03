namespace _04.VariableInHexFormat
{
    using System;

    internal class VariableInHexFormat
    {
        private static void Main()
        {
            string input = Console.ReadLine();
            int number = Convert.ToInt32(input, 16);

            Console.WriteLine(number);
        }
    }
}