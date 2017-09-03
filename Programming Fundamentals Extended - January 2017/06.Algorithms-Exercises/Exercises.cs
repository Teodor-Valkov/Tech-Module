namespace _06.Algorithms_Exercises
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Exercises
    {
        private static void Main()
        {
            // Task 1
            ShootListElements();

            // Task 2
            AverageCharacterDelimiter();

            // Task 3
            SortArrayOfStrings();

            // Task 4
            ArrayHistogram();

            // Task 4
            ArrayHistogramDictionary();

            // Task 5
            DecodeRadioFrequencies();

            // Task 6
            Batteries();
        }

        private static void ShootListElements()
        {
            List<int> numbers = new List<int>();
            int lastNumberRemoved = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == null || input.ToLower() == "stop")
                    break;

                if (input.All(char.IsDigit))
                {
                    int number = int.Parse(input);
                    numbers.Insert(0, number);
                }
                else
                {
                    if (numbers.Any())
                    {
                        double average = numbers.Average();
                        int indexToRemove = numbers.FindIndex(num => num <= average);

                        if (indexToRemove != -1)
                        {
                            lastNumberRemoved = numbers[indexToRemove];
                            numbers.RemoveAt(indexToRemove);
                        }

                        for (int i = 0; i < numbers.Count; i++)
                        {
                            numbers[i]--;
                        }

                        Console.WriteLine($"shot {lastNumberRemoved}");
                    }
                    else
                    {
                        Console.WriteLine($"nobody left to shoot! last one was {lastNumberRemoved}");
                        return;
                    }
                }
            }

            Console.WriteLine(numbers.Any()
                ? $"survivors: {string.Join(" ", numbers)}"
                : $"you shot them all. last one was {lastNumberRemoved}");
        }

        private static void AverageCharacterDelimiter()
        {
            string input = Console.ReadLine();
            if (input != null)
            {
                string[] inputArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                int sum = 0;

                foreach (string arg in inputArgs)
                {
                    sum += arg.Sum(symbol => symbol);
                }

                sum /= input.Count(symbol => !char.IsWhiteSpace(symbol));
                string delimiter = Convert.ToString((char)sum).ToUpper();

                Console.WriteLine(string.Join(delimiter, inputArgs));
            }
        }

        private static void SortArrayOfStrings()
        {
            string[] inputArgs = Console.ReadLine().Split(' ');
            string temp = string.Empty;

            for (int i = 0; i < inputArgs.Length - 1; i++)
            {
                for (int j = 0; j < inputArgs.Length - 1; j++)
                {
                    if (string.Compare(inputArgs[j], inputArgs[j + 1]) == 1)
                    {
                        temp = inputArgs[j + 1];
                        inputArgs[j + 1] = inputArgs[j];
                        inputArgs[j] = temp;
                    }
                }
            }

            Console.WriteLine(string.Join(" ", inputArgs));
        }

        private static void ArrayHistogram()
        {
            string[] inputArgs = Console.ReadLine().Split(' ');
            string tempWord = string.Empty;
            int tempOccurence = 0;

            List<string> words = new List<string>();
            List<int> occurrences = new List<int>();

            foreach (string arg in inputArgs)
            {
                if (words.Contains(arg))
                {
                    int indexOfWord = words.IndexOf(arg);
                    occurrences[indexOfWord]++;
                }
                else
                {
                    words.Add(arg);
                    occurrences.Add(1);
                }
            }

            for (int i = 0; i < occurrences.Count - 1; i++)
            {
                for (int j = 0; j < occurrences.Count - 1; j++)
                {
                    if (occurrences[j] < occurrences[j + 1])
                    {
                        tempOccurence = occurrences[j + 1];
                        occurrences[j + 1] = occurrences[j];
                        occurrences[j] = tempOccurence;

                        tempWord = words[j + 1];
                        words[j + 1] = words[j];
                        words[j] = tempWord;
                    }
                }
            }

            for (int i = 0; i < words.Count; i++)
            {
                int allCount = occurrences.Sum();
                int currentCount = occurrences[i];
                double percentage = 100 / (double)allCount * currentCount;

                Console.WriteLine($"{words[i]} -> {currentCount} times ({percentage:F2}%)");
            }
        }

        private static void ArrayHistogramDictionary()
        {
            string[] inputArgs = Console.ReadLine().Split(' ');
            Dictionary<string, int> wordsAndCount = new Dictionary<string, int>();

            foreach (string arg in inputArgs)
            {
                if (wordsAndCount.ContainsKey(arg))
                {
                    wordsAndCount[arg]++;
                }
                else
                {
                    wordsAndCount[arg] = 1;
                }
            }

            foreach (KeyValuePair<string, int> pair in wordsAndCount.OrderByDescending(pair => pair.Value))
            {
                int allCount = wordsAndCount.Sum(dict => dict.Value);
                int currentCount = pair.Value;
                double percentage = 100 / (double)allCount * currentCount;

                Console.WriteLine($"{pair.Key} -> {pair.Value} times ({percentage:F2}%)");
            }
        }

        private static void DecodeRadioFrequencies()
        {
            List<string> inputArgs = Console.ReadLine().Split(' ').ToList();
            List<char> result = new List<char>();

            for (int i = 0; i < inputArgs.Count; i++)
            {
                string[] argsElements = inputArgs[i].Split('.');

                char leftSideSymbol = (char)int.Parse(argsElements[0]);
                char rightSideSymbol = (char)int.Parse(argsElements[1]);

                if (leftSideSymbol != 0)
                {
                    result.Insert(i, leftSideSymbol);
                }

                if (rightSideSymbol != 0)
                {
                    result.Insert(result.Count - i, rightSideSymbol);
                }
            }

            Console.WriteLine(string.Join("", result));
        }

        private static void Batteries()
        {
            List<double> capacity = Console.ReadLine().Split(' ').Select(double.Parse).ToList();
            List<double> usage = Console.ReadLine().Split(' ').Select(double.Parse).ToList();
            int hours = int.Parse(Console.ReadLine());

            for (int i = 0; i < capacity.Count; i++)
            {
                double diffence = capacity[i] - usage[i] * hours;

                if (diffence > 0)
                {
                    double percentage = 100 / capacity[i] * diffence;
                    Console.WriteLine($"Battery {i + 1}: {diffence:F2} mAh ({percentage:F2})%");
                }
                else
                {
                    double lastedHours = Math.Ceiling(capacity[i] / usage[i]);
                    Console.WriteLine($"Battery {i + 1}: dead (lasted {lastedHours} hours)");
                }
            }
        }
    }
}