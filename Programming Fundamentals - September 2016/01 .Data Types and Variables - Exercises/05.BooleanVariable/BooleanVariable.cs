namespace _05.BooleanVariable
{
    using System;

    class BooleanVariable
    {
        static void Main()
        {
            string input = Console.ReadLine();
            bool flag = Convert.ToBoolean(input);

            Console.WriteLine(flag ? "Yes" : "No");
        }
    }
}
