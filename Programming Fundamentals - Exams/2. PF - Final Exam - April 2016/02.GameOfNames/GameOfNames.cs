namespace _02.GameOfNames
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class GameOfNames
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<string> names = new List<string>(n);
            List<decimal> scores = new List<decimal>(n);

            for (int j = 0; j < n; j++)
            {
                string name = Console.ReadLine();
                decimal score = int.Parse(Console.ReadLine());

                if (name != null)
                {
                    foreach (char letter in name)
                    {
                        if (letter % 2 == 0)
                        {
                            score += letter;
                        }
                        else
                        {
                            score -= letter;
                        }
                    }

                    scores.Add(score);
                    names.Add(name);
                }
            }

            Console.WriteLine($"The winner is {names[scores.IndexOf(scores.Max())]} - {scores.Max()} points");
        }
    }
}
