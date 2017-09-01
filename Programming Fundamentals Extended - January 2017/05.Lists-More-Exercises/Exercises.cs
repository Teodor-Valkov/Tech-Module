namespace _05.Lists_More_Exercises
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class Exercises
    {
        static void Main()
        {
            // Task 1
            DistinctList();

            // Task 2
            IntegerInsertion();

            // Task 3
            CamelBack();

            // Task 4
            UnunionLists();

            // Task 5
            NoteStatistics();

            // Task 6
            Winecraft();
        }

        private static void DistinctList()
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            numbers = numbers.Distinct().ToList();

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void IntegerInsertion()
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == null || input == "end")
                    break;

                int firstDigit = int.Parse(input.First().ToString());
                int number = int.Parse(input);

                numbers.Insert(firstDigit, number);
            }

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void CamelBack()
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int limitNumber = int.Parse(Console.ReadLine());
            int counter = 0;

            while (numbers.Count > limitNumber)
            {
                numbers.RemoveAt(0);
                numbers.RemoveAt(numbers.Count - 1);
                counter++;
            }

            if (counter == 0)
            {
                Console.WriteLine($"already stable: {string.Join(" ", numbers)}");
            }
            else
            {
                Console.WriteLine($"{counter} rounds");
                Console.WriteLine($"remaining: {string.Join(" ", numbers)}");
            }
        }

        private static void UnunionLists()
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                List<int> currentNumbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

                foreach (int currentNumber in currentNumbers)
                {
                    if (!numbers.Contains(currentNumber))
                    {
                        numbers.Add(currentNumber);
                    }
                    else
                    {
                        numbers.RemoveAll(num => num == currentNumber);
                    }
                }
            }

            numbers.Sort();
            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void NoteStatistics()
        {
            string[] frequencies = Console.ReadLine().Split();

            List<string> notes = new List<string>();
            List<string> naturals = new List<string>();
            List<string> sharps = new List<string>();

            double naturalsSum = 0;
            double sharpsSum = 0;

            foreach (string frequency in frequencies)
            {
                switch (frequency.PadRight(6, '0'))
                {
                    case "261.63":
                        notes.Add("C");
                        naturals.Add("C");
                        naturalsSum += double.Parse(frequency);
                        break;
                    case "277.18":
                        notes.Add("C#");
                        sharps.Add("C#");
                        sharpsSum += double.Parse(frequency);
                        break;
                    case "293.66":
                        notes.Add("D");
                        naturals.Add("D");
                        naturalsSum += double.Parse(frequency);
                        break;
                    case "311.13":
                        notes.Add("D#");
                        sharps.Add("D#");
                        sharpsSum += double.Parse(frequency);
                        break;
                    case "329.63":
                        notes.Add("E");
                        naturals.Add("E");
                        naturalsSum += double.Parse(frequency);
                        break;
                    case "349.23":
                        notes.Add("F");
                        naturals.Add("F");
                        naturalsSum += double.Parse(frequency);
                        break;
                    case "369.99":
                        notes.Add("F#");
                        sharps.Add("F#");
                        sharpsSum += double.Parse(frequency);
                        break;
                    case "392.00":
                        notes.Add("G");
                        naturals.Add("G");
                        naturalsSum += double.Parse(frequency);
                        break;
                    case "415.30":
                        notes.Add("G#");
                        sharps.Add("G#");
                        sharpsSum += double.Parse(frequency);
                        break;
                    case "440.00":
                        notes.Add("A");
                        naturals.Add("A");
                        naturalsSum += double.Parse(frequency);
                        break;
                    case "466.16":
                        notes.Add("A#");
                        sharps.Add("A#");
                        sharpsSum += double.Parse(frequency);
                        break;
                    case "493.88":
                        notes.Add("B");
                        naturals.Add("B");
                        naturalsSum += double.Parse(frequency);
                        break;

                }
            }

            Console.WriteLine($"Notes: {string.Join(" ", notes)}");
            Console.WriteLine($"Naturals: {string.Join(", ", naturals)}");
            Console.WriteLine($"Sharps: {string.Join(", ", sharps)}");
            Console.WriteLine($"Naturals sum: {naturalsSum}");
            Console.WriteLine($"Sharps sum: {sharpsSum}");
        }

        private static void Winecraft()
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int number = int.Parse(Console.ReadLine());
            int counter = 0;

            while (numbers.Count > number)
            {
                for (int j = 0; j < numbers.Count; j++)
                {
                    numbers[j]++;
                }

                for (int i = 0; i < numbers.Count; i++)
                {
                    if (i > 0 && i < numbers.Count - 1)
                    {
                        if (numbers[i] > numbers[i - 1] && numbers[i] > numbers[i + 1])
                        {
                            numbers[i]--;

                            if (numbers[i - 1] > 0)
                            {
                                numbers[i]++;
                                numbers[i - 1] = Math.Max(numbers[i - 1] - 2, 0);
                            }

                            if (numbers[i + 1] > 0)
                            {
                                numbers[i]++;
                                numbers[i + 1] = Math.Max(numbers[i + 1] - 2, 0);
                            }
                        }
                    }
                }
            
                counter++;

                if (counter == number)
                {
                    counter = 0;
                    numbers.RemoveAll(num => num <= number);
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
