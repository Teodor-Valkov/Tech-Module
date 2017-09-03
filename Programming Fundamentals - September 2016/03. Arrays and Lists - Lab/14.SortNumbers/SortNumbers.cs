namespace _14.SortNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class SortNumbers
    {
        private static void Main()
        {
            List<decimal> numbers = Console.ReadLine().Split(' ').Select(decimal.Parse).ToList();
            numbers.Sort();

            Console.WriteLine(string.Join(" <= ", numbers));
        }
    }
}