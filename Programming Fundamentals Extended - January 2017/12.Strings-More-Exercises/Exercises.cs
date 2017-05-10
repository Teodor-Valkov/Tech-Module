namespace _12.Strings_More_Exercises
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class Exercises
    {
        static void Main()
        {
            // Task 1
            SerializeString();

            // Task 2
            Stateless();

            // Task 3
            Pyramidic();

            // Task 4
            Nilapdromes();
        }

        private static void SerializeString()
        {
            Dictionary<char, List<int>> letterAndIndexes = new Dictionary<char, List<int>>();

            string input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                char letter = input[i];

                if (!letterAndIndexes.ContainsKey(letter))
                {
                    letterAndIndexes[letter] = new List<int>();
                }

                letterAndIndexes[letter].Add(i);
            }

            foreach (KeyValuePair<char, List<int>> pair in letterAndIndexes)
            {
                Console.WriteLine($"{pair.Key}:{string.Join("/", pair.Value)}");
            }

            //letterAndIndexes
            //    .ToList()
            //    .ForEach(pair => Console.WriteLine($"{pair.Key}:{string.Join("/", pair.Value)}"));
        }

        private static void Stateless()
        {
            List<string> result = new List<string>();

            while (true)
            {
                string sentence = Console.ReadLine();

                if (sentence == "collapse")
                    break;

                string specialWord = Console.ReadLine();

                while (specialWord.Length > 0)
                {
                    sentence = sentence.Replace(specialWord, string.Empty);

                    if (specialWord.Length == 1)
                    {
                        sentence = sentence.Replace(specialWord, string.Empty);
                        break;
                    }

                    specialWord = specialWord.Substring(1, specialWord.Length - 2);
                }

                result.Add(sentence.Length == 0
                    ? "(void)"
                    : sentence.Trim());
            }

            result.ForEach(Console.WriteLine);
        }

        private static void Pyramidic()
        {
            int number = int.Parse(Console.ReadLine());
            List<string> words = new List<string>();

            for (int i = 0; i < number; i++)
            {
                words.Add(Console.ReadLine());
            }

            int currentBest = 1;
            int best = 1;
            string bestSymbol = string.Empty;

            for (int i = 0; i < words.Count; i++)
            {
                string currentWord = words[i];

                foreach (char currentSymbol in currentWord)
                {
                    for (int j = i + 1; j < words.Count; j++)
                    {
                        string nextWord = words[j];
                        int nextWordSymbolsCount = nextWord.Count(symbol => symbol == currentSymbol);

                        if (nextWordSymbolsCount >= currentBest + 2)
                        {
                            currentBest += 2;
                            continue;
                        }

                        break;
                    }

                    if (currentBest > best)
                    {
                        best = currentBest;
                        bestSymbol = Convert.ToString(currentSymbol);
                    }

                    currentBest = 1;
                }
            }

            if (!string.IsNullOrEmpty(bestSymbol))
            {
                for (int i = 1; i <= best; i += 2)
                {
                    Console.WriteLine(new string(Convert.ToChar(bestSymbol), i));
                }
            }
        }

        private static void Nilapdromes()
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input.ToLower() == "end")
                    break;

                string firstPart = input.Substring(0, input.Length / 2);
                string secondPart = input.Substring(input.Length / 2);

                string border = string.Empty;
                string core = string.Empty;

                if (input.Length % 2 == 1)
                {
                    secondPart = input.Substring(input.Length / 2 + 1);
                }

                while (true)
                {
                    if (firstPart == secondPart)
                    {
                        border = firstPart;
                        break;
                    }

                    if (firstPart != secondPart)
                    {
                        firstPart = firstPart.Substring(0, firstPart.Length - 1);
                        secondPart = secondPart.Substring(1, secondPart.Length - 1);
                    }
                }

                if (!string.IsNullOrEmpty(border))
                {
                    core = input.Remove(0, border.Length);
                    core = core.Remove(core.Length - border.Length, border.Length);

                    if (!string.IsNullOrEmpty(core))
                    {
                        Console.WriteLine(core + border + core);                     
                    }
                }
            }
        }
    }
}

