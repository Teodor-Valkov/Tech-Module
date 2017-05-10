namespace _07.Dictionaries_Exercises
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class Exercises
    {
        static void Main()
        {
            // Task 1
            LetterRepetition();

            // Task 2
            ReferencedDictionary();

            // Task 3
            MixedPhones();

            // Task 4
            ExamShopping();

            // Task 5
            UserLogins();

            // Task 6
            FilterBase();
        }

        private static void LetterRepetition()
        {
            string input = Console.ReadLine();
            Dictionary<char, int> counts = new Dictionary<char, int>();

            if (input != null)
            {
                foreach (char symbol in input)
                {
                    if (counts.ContainsKey(symbol))
                    {
                        counts[symbol]++;
                    }
                    else
                    {
                        counts[symbol] = 1;
                    }
                }
            }

            foreach (KeyValuePair<char, int> pair in counts)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value}");
            }
        }

        private static void ReferencedDictionary()
        {
            Dictionary<string, int> nameAndValue = new Dictionary<string, int>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == null || input.ToLower() == "end")
                    break;

                string[] inputArgs = input.Split(new[] { " = " }, StringSplitOptions.RemoveEmptyEntries);
                string name = inputArgs[0];
                string valueOrName = inputArgs[1];

                if (valueOrName.All(char.IsDigit))
                {
                    nameAndValue[name] = int.Parse(valueOrName);
                }
                else
                {
                    if (nameAndValue.ContainsKey(valueOrName))
                    {
                        nameAndValue[name] = nameAndValue[valueOrName];
                    }
                }
            }

            foreach (KeyValuePair<string, int> pair in nameAndValue)
            {
                Console.WriteLine($"{pair.Key} === {pair.Value}");
            }
        }

        private static void MixedPhones()
        {
            Dictionary<string, long> nameAndPhone = new Dictionary<string, long>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == null || input.ToLower() == "over")
                    break;

                string[] inputArgs = input.Split(new[] { " : " }, StringSplitOptions.RemoveEmptyEntries);
                string name = inputArgs[0];
                string phone = inputArgs[1];

                if (name.All(char.IsDigit))
                {
                    string temp = name;
                    name = phone;
                    phone = temp;
                }

                nameAndPhone[name] = long.Parse(phone);
            }

            foreach (KeyValuePair<string, long> pair in nameAndPhone.OrderBy(pair => pair.Key))
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value}");
            }
        }

        private static void ExamShopping()
        {
            Dictionary<string, int> productAndQuantity = new Dictionary<string, int>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == null || input.ToLower() == "exam time")
                    break;

                if (input.ToLower() == "shopping time")
                    continue;

                string[] inputArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string action = inputArgs[0];
                string product = inputArgs[1];
                int quantity = int.Parse(inputArgs[2]);

                if (action == "stock")
                {
                    if (productAndQuantity.ContainsKey(product))
                    {
                        productAndQuantity[product] += quantity;
                    }
                    else
                    {
                        productAndQuantity[product] = quantity;
                    }
                }

                if (action == "buy")
                {
                    if (productAndQuantity.ContainsKey(product))
                    {
                        if (productAndQuantity[product] > 0)
                        {
                            productAndQuantity[product] -= quantity;
                        }
                        else
                        {
                            Console.WriteLine($"{product} out of stock");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{product} doesn't exist");
                    }
                }
            }

            foreach (KeyValuePair<string, int> pair in productAndQuantity.Where(pair => pair.Value > 0))
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value}");
            }
        }

        private static void UserLogins()
        {
            Dictionary<string, string> usernameAndPassword = new Dictionary<string, string>();
            int counter = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == null || input.ToLower() == "login")
                    break;

                string[] inputArgs = input.Split(new[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
                string username = inputArgs[0];
                string password = inputArgs[1];

                usernameAndPassword[username] = password;
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == null || input.ToLower() == "end")
                    break;

                string[] inputArgs = input.Split(new[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
                string username = inputArgs[0];
                string password = inputArgs[1];

                if (usernameAndPassword.ContainsKey(username) && usernameAndPassword.ContainsValue(password))
                {
                    Console.WriteLine($"{username}: logged in successfully");
                }
                else
                {
                    counter++;
                    Console.WriteLine($"{username}: login failed");
                }
            }

            Console.WriteLine($"unsuccessful login attempts: {counter}");
        }

        private static void FilterBase()
        {
            Dictionary<string, int> nameAndAge = new Dictionary<string, int>();
            Dictionary<string, double> nameAndSalary = new Dictionary<string, double>();
            Dictionary<string, string> nameAndPosition = new Dictionary<string, string>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == null || input.ToLower() == "filter base")
                    break;

                string[] inputArgs = input.Split(new[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
                string name = inputArgs[0];
                string ageSalaryOrPosition = inputArgs[1];

                if (ageSalaryOrPosition.All(char.IsDigit))
                {
                    nameAndAge[name] = int.Parse(ageSalaryOrPosition);
                }
                
                if (ageSalaryOrPosition.Contains('.'))
                {
                    nameAndSalary[name] = double.Parse(ageSalaryOrPosition);
                }

                if (ageSalaryOrPosition.All(char.IsLetter))
                {
                    nameAndPosition[name] = ageSalaryOrPosition;
                }
            }

            string filter = Console.ReadLine();

            switch (filter)
            {
                case "Age":
                    foreach (KeyValuePair<string, int> pair in nameAndAge)
                    {
                        Console.WriteLine($"Name: {pair.Key}");
                        Console.WriteLine($"Age: {pair.Value}");
                        Console.WriteLine(new string('=', 20));
                    }
                    break;

                case "Salary":
                    foreach (KeyValuePair<string, double> pair in nameAndSalary)
                    {
                        Console.WriteLine($"Name: {pair.Key}");
                        Console.WriteLine($"Salary: {pair.Value:F2}");
                        Console.WriteLine(new string('=', 20));
                    }
                    break;

                case "Position":
                    foreach (KeyValuePair<string, string> pair in nameAndPosition)
                    {
                        Console.WriteLine($"Name: {pair.Key}");
                        Console.WriteLine($"Position: {pair.Value}");
                        Console.WriteLine(new string('=', 20));
                    }
                    break;
            }
        }
    }
}
