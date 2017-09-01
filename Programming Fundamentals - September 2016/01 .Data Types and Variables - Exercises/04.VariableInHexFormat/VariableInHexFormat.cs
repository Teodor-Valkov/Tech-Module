namespace _04.VariableInHexFormat
{
    using System;

    class VariableInHexFormat
    {
        static void Main()
        {
            string input = Console.ReadLine();
            int number = Convert.ToInt32(input, 16);

            Console.WriteLine(number);
        }
    }
}
