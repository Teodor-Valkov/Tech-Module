namespace _14.SortNumbers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class SortNumbers
    {
        static void Main()
        {
            List<decimal> numbers = Console.ReadLine().Split(' ').Select(decimal.Parse).ToList();
            numbers.Sort();

            Console.WriteLine(string.Join(" <= ", numbers));
        }
    }
}
