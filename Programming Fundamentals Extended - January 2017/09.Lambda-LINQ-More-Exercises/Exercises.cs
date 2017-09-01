namespace _09.Lambda_LINQ_More_Exercises
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class Exercises
    {
        static void Main()
        {
            // Task 1
            LambadaExpressions();

            // Task 1
            LambadaExpressionsInnerDict();

            // Task 2
            OrderedBankingSystem();

            // Task 3
            Linquistics();
        }

        private static void LambadaExpressions()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input.ToLower() == "lambada")
                    break;

                if (input.ToLower() == "dance")
                {
                    dict = dict.ToDictionary(pair => pair.Key, pair => pair.Value.Substring(0, pair.Value.IndexOf('.') + 1) + pair.Value);
                }
                else
                {
                    string[] inputArgs = input.Split(new[] { " => " }, StringSplitOptions.RemoveEmptyEntries);
                    string selector = inputArgs[0];

                    string[] inputArgsElements = inputArgs[1].Split('.');
                    string selectorObject = inputArgsElements[0];
                    string selectorProperty = inputArgsElements[1];

                    dict[selector] = selectorObject + "." + selectorProperty;
                }
            }

            //dict.ToList()
            //    .ForEach(pair => Console.WriteLine($"{pair.Key} => {pair.Value}"));

            foreach (KeyValuePair<string, string> pair in dict)
            {
                Console.WriteLine($"{pair.Key} => {pair.Value}");
            }
        }

        private static void LambadaExpressionsInnerDict()
        {
            Dictionary<string, Dictionary<string, string>> dict = new Dictionary<string, Dictionary<string, string>>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input.ToLower() == "lambada")
                    break;

                if (input.ToLower() == "dance")
                {
                    dict = dict
                        .ToDictionary(pair => pair.Key, pair => pair.Value
                            .ToDictionary(innerPair => innerPair.Key, innerPair => innerPair.Key + "." + innerPair.Value));
                }
                else
                {
                    string[] inputArgs = input.Split(new[] { " => " }, StringSplitOptions.RemoveEmptyEntries);
                    string selector = inputArgs[0];

                    string[] inputArgsElements = inputArgs[1].Split('.');
                    string selectorObject = inputArgsElements[0];
                    string selectorProperty = inputArgsElements[1];

                    if (!dict.ContainsKey(selector))
                    {
                        dict[selector] = new Dictionary<string, string>();
                    }

                    dict[selector][selectorObject] = selectorProperty;
                }
            }

            //dict.ToList()
            //    .ForEach(pair => pair.Value
            //    .ToList()
            //    .ForEach(innerPair => Console.WriteLine($"{pair.Key} => {innerPair.Key}.{innerPair.Value}")));

            foreach (KeyValuePair<string, Dictionary<string, string>> pair in dict)
            {
                foreach (KeyValuePair<string, string> innerPair in pair.Value)
                {
                    Console.WriteLine($"{pair.Key} => {innerPair.Key}.{innerPair.Value}");
                }
            }

        }

        private static void OrderedBankingSystem()
        {
            Dictionary<string, Dictionary<string, decimal>> bankAccountAndMoney = new Dictionary<string, Dictionary<string, decimal>>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input.ToLower() == "end")
                    break;

                string[] inputArgs = input.Split(new[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
                string bank = inputArgs[0];
                string account = inputArgs[1];
                decimal money = decimal.Parse(inputArgs[2]);

                if (!bankAccountAndMoney.ContainsKey(bank))
                {
                    bankAccountAndMoney.Add(bank, new Dictionary<string, decimal>());
                }

                if (!bankAccountAndMoney[bank].ContainsKey(account))
                {
                    bankAccountAndMoney[bank][account] = money;
                }
                else
                {
                    bankAccountAndMoney[bank][account] += money;
                }
            }

            //bankAccountAndMoney
            //    .OrderByDescending(pair => pair.Value.Sum(innerPair => innerPair.Value))
            //    .ThenByDescending(pair => pair.Value.Max(innerPair => innerPair.Value))
            //    .ToList()
            //    .ForEach(pair => pair.Value
            //        .OrderByDescending(innerPair => innerPair.Value)
            //        .ToList()
            //        .ForEach(innerPair => Console.WriteLine($"{innerPair.Key} -> {innerPair.Value} ({pair.Key})")));

            bankAccountAndMoney = bankAccountAndMoney
                .OrderByDescending(pair => pair.Value.Sum(innerPair => innerPair.Value))
                .ThenByDescending(pair => pair.Value.Max(innerPair => innerPair.Value))
                .ToDictionary(pair => pair.Key, pair => pair.Value);

            foreach (KeyValuePair<string, Dictionary<string, decimal>> bank in bankAccountAndMoney)
            {
                foreach (KeyValuePair<string, decimal> accountAndMoney in bank.Value.OrderByDescending(accountAndMoney => accountAndMoney.Value))
                {
                    Console.WriteLine($"{accountAndMoney.Key} -> {accountAndMoney.Value} ({bank.Key})");
                }
            }
        }

        private static void Linquistics()
        {
            Dictionary<string, HashSet<string>> collectionAndMethods = new Dictionary<string, HashSet<string>>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input.ToLower() == "exit")
                    break;

                string[] inputArgs = input.Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries);

                string collection = string.Empty;
                List<string> methods = new List<string>();

                for (int i = 0; i < inputArgs.Length; i++)
                {
                    if (i == 0)
                    {
                        collection = inputArgs[i];
                    }
                    else
                    {
                        methods.Add(inputArgs[i].TrimEnd('(', ')'));
                    }
                }

                if (IsInputNumber(collection))
                {
                    int number = int.Parse(collection);

                    //List<string> currentCollectionMethods =
                        collectionAndMethods
                            .OrderByDescending(pair => pair.Value.Count)
                            .Take(1)
                            .SelectMany(pair => pair.Value)
                            .OrderBy(method => method.Length)
                            .Take(number)
                            .ToList()
                            .ForEach(method => Console.WriteLine($"* {method}"));

                    //foreach (string method in currentCollectionMethods)
                    //{
                    //    Console.WriteLine($"* {method}");
                    //}
                }

                if (IsCollectionExistingInDictionary(collection, collectionAndMethods) && !methods.Any())
                {
                    //List<string> currentCollectionMethods =
                        collectionAndMethods
                            .Where(pair => pair.Key == collection)
                            .SelectMany(pair => pair.Value)
                            .OrderByDescending(method => method.Length)
                            .ThenByDescending(method => method.Distinct().Count())
                            .ToList()
                            .ForEach(method => Console.WriteLine($"* {method}"));
                    
                    //foreach (string method in currentCollectionMethods)
                    //{
                    //    Console.WriteLine($"* {method}");
                    //}
                }

                if (!collectionAndMethods.ContainsKey(collection))
                {
                    collectionAndMethods[collection] = new HashSet<string>();
                }

                foreach (string method in methods)
                {
                    collectionAndMethods[collection].Add(method);
                }
            }

            string[] methodAndSelection = Console.ReadLine().Split();
            string neededMethod = methodAndSelection[0];
            string neededsSelection = methodAndSelection[1];

            if (neededsSelection.ToLower() == "collection")
            {
                //List<string> neededCollections =
                collectionAndMethods
                    .Where(pair => pair.Value.Contains(neededMethod))
                    .OrderByDescending(pair => pair.Value.Count)
                    .ThenByDescending(pair => pair.Value.Min(method => method.Length))
                    .Select(pair => pair.Key)
                    .ToList()
                    .ForEach(collection => Console.WriteLine($"{collection}"));

                //foreach (string collection in neededCollections)
                //{
                //    Console.WriteLine($"{collection}");
                //}
            }

            if (neededsSelection.ToLower() == "all")
            {

                //collectionAndMethods
                //    .Where(pair => pair.Value.Contains(neededMethod))
                //    .OrderByDescending(pair => pair.Value.Count)
                //    .ThenByDescending(pair => pair.Value.Min(method => method.Length))
                //    .ToList()
                //    .ForEach(collection =>
                //    Console.WriteLine($"{collection.Key}\n* {string.Join("\n* ", collection.Value.OrderByDescending(method => method.Length))}"));

                Dictionary<string, HashSet<string>> neededCollections =
                          collectionAndMethods
                            .Where(pair => pair.Value.Contains(neededMethod))
                            .OrderByDescending(pair => pair.Value.Count)
                            .ThenByDescending(pair => pair.Value.Min(method => method.Length))
                            .ToDictionary(pair => pair.Key, pair => pair.Value);

                foreach (KeyValuePair<string, HashSet<string>> pair in neededCollections)
                {
                    Console.WriteLine(pair.Key);
                    foreach (string method in pair.Value.OrderByDescending(method => method.Length))
                    {
                        Console.WriteLine($"* {method}");
                    }
                }
            }
        }

        private static bool IsCollectionExistingInDictionary(string collection, Dictionary<string, HashSet<string>> dict)
        {
            return dict.ContainsKey(collection);
        }

        private static bool IsInputNumber(string collection)
        {
            foreach (char symbol in collection)
            {
                if (char.IsDigit(symbol))
                {
                    continue;
                }

                return false;
            }

            return true;
        }
    }
}
