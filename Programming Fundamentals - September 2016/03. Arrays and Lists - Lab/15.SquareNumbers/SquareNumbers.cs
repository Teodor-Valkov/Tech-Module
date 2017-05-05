namespace _15.SquareNumbers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class SquareNumbers
    {
        static void Main()
        {
            List<double> numbers = Console.ReadLine().Split(' ').Select(double.Parse).ToList();
            List<double> result = new List<double>();

            foreach (double number in numbers)
            {
                if (number % Math.Sqrt(number) == 0)
                    //or (Math.Sqrt(numbers[i] == (int)Math.Sqrt(numbers[i])) 
                {
                    result.Add(number);
                }
            }

            result.Sort((a, b) => b.CompareTo(a));
            //or .Sort() and .Reverse();

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
