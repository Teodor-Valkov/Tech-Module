namespace _01.Numbers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class Numbers
    {
        static void Main()
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> biggerThanAverageNumber = new List<int>();
            List<int> answers = new List<int>();

            double averageNumber = numbers.Average();

            foreach (int number in numbers)
            {
                if (number > averageNumber)
                {
                    biggerThanAverageNumber.Add(number);
                }
            }
        
            biggerThanAverageNumber.Sort();
            biggerThanAverageNumber.Reverse();
            //or biggerThanAverageNumber.Sort((a,b) => b.CompareTo(a));
            //or biggerThanAverageNumber = biggerThanAverageNumber.OrderBy(x => -x).ToList();

            answers.AddRange(biggerThanAverageNumber.Count > 5
                ? biggerThanAverageNumber.Take(5)
                : biggerThanAverageNumber);

            Console.WriteLine(answers.Count > 0 ? string.Join(" ", answers) : "No");
        }
    }
}
