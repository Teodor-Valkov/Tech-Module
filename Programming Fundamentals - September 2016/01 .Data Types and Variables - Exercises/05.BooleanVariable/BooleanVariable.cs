namespace _05.BooleanVariable
{
    using System;

    internal class BooleanVariable
    {
        private static void Main()
        {
            string input = Console.ReadLine();
            bool flag = Convert.ToBoolean(input);

            Console.WriteLine(flag ? "Yes" : "No");
        }
    }
}