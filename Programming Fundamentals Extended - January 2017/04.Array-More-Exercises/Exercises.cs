namespace _04.Array_More_Exercises
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Exercises
    {
        private static void Main()
        {
            // Task 1
            LastThreeConsecutiveEqualStrings();

            // Task 2
            ArrayElementsEqualToTheirIndex();

            // Task 3
            Phonebook();

            // Task 4
            Phone();

            // Task 5
            CharRotation();

            // Task 6
            PowerPlants();

            // Task 7
            ResizableArray();
        }

        private static void LastThreeConsecutiveEqualStrings()
        {
            string[] inputArgs = Console.ReadLine().Split(' ').ToArray();
            inputArgs.Reverse();

            string[] result = new string[3];

            for (int i = 2; i < inputArgs.Length; i++)
            {
                if (inputArgs[i] == inputArgs[i - 1] && inputArgs[i - 1] == inputArgs[i - 2])
                {
                    result[0] = inputArgs[i];
                    result[1] = inputArgs[i - 1];
                    result[2] = inputArgs[i - 2];
                    break;
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }

        private static void ArrayElementsEqualToTheirIndex()
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            List<int> result = new List<int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (i == numbers[i])
                {
                    result.Add(numbers[i]);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }

        private static void Phonebook()
        {
            string[] telephoneNumbers = Console.ReadLine().Split(' ');
            List<string> names = Console.ReadLine().Split(' ').ToList();

            while (true)
            {
                string name = Console.ReadLine();

                if (name == "done")
                    break;

                int index = names.IndexOf(name);

                Console.WriteLine($"{name} -> {telephoneNumbers[index]}");
            }
        }

        private static void Phone()
        {
            List<string> telephoneNumbers = Console.ReadLine().Split(' ').ToList();
            List<string> names = Console.ReadLine().Split(' ').ToList();

            while (true)
            {
                string[] inputArgs = Console.ReadLine().Split();

                if (inputArgs[0] == "done")
                    break;

                string action = inputArgs[0];
                string nameOrNumber = inputArgs[1];

                string number = string.Empty;
                string answer = string.Empty;

                if (nameOrNumber.All(char.IsLetter))
                {
                    string name = nameOrNumber;
                    int index = names.IndexOf(name);

                    number = telephoneNumbers[index];

                    Console.WriteLine(action == "call"
                        ? $"calling {telephoneNumbers[index]}..."
                        : $"sending sms to {telephoneNumbers[index]}...");
                }
                else
                {
                    number = nameOrNumber;
                    int index = telephoneNumbers.IndexOf(number);

                    Console.WriteLine(action == "call"
                        ? $"calling {names[index]}..."
                        : $"sending sms to {names[index]}...");
                }

                int numberSum = number.Where(char.IsDigit).Sum(num => int.Parse(num.ToString()));

                if (numberSum % 2 == 1)
                {
                    answer = action == "call"
                        ? "no answer"
                        : "busy";
                }
                else
                {
                    int minutes = numberSum / 60;
                    int seconds = numberSum % 60;

                    answer = action == "call"
                        ? $"call ended. duration: {minutes:00}:{seconds:00}"
                        : "meet me there";
                }

                Console.WriteLine($"{answer}");
            }
        }

        private static void CharRotation()
        {
            char[] inputArgs = Console.ReadLine().ToCharArray();
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            for (int i = 0; i < inputArgs.Length; i++)
            {
                if (numbers[i] % 2 == 1)
                {
                    inputArgs[i] += (char)numbers[i];
                }
                else
                {
                    inputArgs[i] -= (char)numbers[i];
                }
            }

            Console.WriteLine(string.Join("", inputArgs));
        }

        private static void PowerPlants()
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int counter = 0;
            int seasons = 0;
            int days = 0;

            while (true)
            {
                if (numbers.All(num => num <= 0))
                    break;

                if (counter == numbers.Length)
                {
                    seasons++;
                    counter = 0;

                    for (int i = 0; i < numbers.Length; i++)
                    {
                        if (numbers[i] > 0)
                        {
                            numbers[i]++;
                        }
                    }
                }

                for (int i = 0; i < numbers.Length; i++)
                {
                    if (i != counter)
                    {
                        numbers[i]--;
                    }
                }

                counter++;
                days++;
            }

            Console.WriteLine($"survived {days} days ({seasons} seasons)");
        }

        private static void ResizableArray()
        {
            string result = string.Empty;

            while (true)
            {
                string input = Console.ReadLine();

                if (input != null)
                {
                    if (input == "end")
                    {
                        Console.WriteLine(string.IsNullOrEmpty(result)
                            ? "empty array"
                            : result);

                        break;
                    }

                    string[] commands = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                    string action = commands[0];
                    int number = 0;

                    if (commands.Length > 1)
                    {
                        number = int.Parse(commands[1]);
                    }

                    switch (action)
                    {
                        case "push":
                            result = result + " " + number;
                            break;

                        case "pop":
                            result = Pop(result);
                            break;

                        case "removeAt":
                            result = RemoveAt(result, number);
                            break;

                        case "clear":
                            result = string.Empty;
                            break;
                    }
                }
            }
        }

        private static string Pop(string input)
        {
            string result = string.Empty;
            string[] inputCharArray = input.TrimStart().Split();

            for (int i = 0; i < inputCharArray.Length - 1; i++)
            {
                result += inputCharArray[i] + " ";
            }

            return result.TrimEnd();
        }

        private static string RemoveAt(string input, int number)
        {
            string result = string.Empty;
            string[] inputCharArray = input.TrimStart().Split();

            for (int i = 0; i < inputCharArray.Length; i++)
            {
                if (i != number)
                {
                    result += inputCharArray[i] + " ";
                }
            }

            return result.TrimEnd();
        }
    }
}