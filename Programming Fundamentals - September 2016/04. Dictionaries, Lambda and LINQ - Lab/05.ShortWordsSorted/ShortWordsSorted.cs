namespace _05.ShortWordsSorted
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class ShortWordsSorted
    {
        static void Main()
        {
            // In SoftUni you can study Java C# PHP and JavaScript. Java and c# developers graduate in 2-3 years. Go in! 

            string separators = ".,:;()[]\"'\\/!? ";

            List<string> input = Console.ReadLine().ToLower().Split(separators.ToCharArray()).ToList();

            input = input.Where(x => x.Length > 0 && x.Length < 5)
                     .Distinct()
                     .OrderBy(x => x)
                     .ToList();

            Console.WriteLine(string.Join(", ", input));
        }
    }
}
