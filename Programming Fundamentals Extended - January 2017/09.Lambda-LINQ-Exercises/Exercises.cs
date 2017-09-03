namespace _09.Lambda_LINQ_Exercises
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    internal class Exercises
    {
        private static void Main()
        {
            // Task 1
            RegisteredUsers();

            // Task 2
            DefaultValues();

            // Task 3
            FlattenDictionary();

            // Task 4
            CottageScraper();
        }

        private static void RegisteredUsers()
        {
            Dictionary<string, DateTime> usernameAndDate = new Dictionary<string, DateTime>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input.ToLower() == "end")
                    break;

                string[] inputArgs = input.Split(new[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
                string username = inputArgs[0];
                DateTime date = DateTime.ParseExact(inputArgs[1], "dd/MM/yyyy", CultureInfo.InvariantCulture);

                usernameAndDate[username] = date;
            }

            usernameAndDate =
                usernameAndDate
                 .Reverse()
                 .OrderBy(pair => pair.Value)
                 .Take(5)
                 .OrderByDescending(pair => pair.Value)
                 .ToDictionary(pair => pair.Key, pair => pair.Value);

            foreach (KeyValuePair<string, DateTime> pair in usernameAndDate)
            {
                Console.WriteLine(pair.Key);
            }
        }

        private static void DefaultValues()
        {
            Dictionary<string, string> keysAndValues = new Dictionary<string, string>();
            string defaultValue = string.Empty;

            while (true)
            {
                string input = Console.ReadLine();

                if (input.ToLower() == "end")
                {
                    defaultValue = Console.ReadLine();
                    break;
                }

                string[] inputArgs = input.Split(new[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
                string key = inputArgs[0];
                string value = inputArgs[1];

                keysAndValues[key] = value;
            }

            Dictionary<string, string> originalKeysAndValues =
                keysAndValues
                 .Where(pair => pair.Value != "null")
                 .OrderByDescending(pair => pair.Value.Length)
                 .ToDictionary(pair => pair.Key, pair => pair.Value);

            foreach (KeyValuePair<string, string> pair in originalKeysAndValues)
            {
                Console.WriteLine($"{pair.Key} <-> {pair.Value}");
            }

            Dictionary<string, string> replacedKeysAndValues =
                keysAndValues
                 .Where(pair => pair.Value == "null")
                 .ToDictionary(pair => pair.Key, pair => pair.Value);

            foreach (KeyValuePair<string, string> pair in replacedKeysAndValues)
            {
                Console.WriteLine($"{pair.Key} <-> {defaultValue}");
            }
        }

        private static void FlattenDictionary()
        {
            Dictionary<string, Dictionary<string, string>> dictAndInnerDict = new Dictionary<string, Dictionary<string, string>>();
            string flattenKey = string.Empty;

            while (true)
            {
                string input = Console.ReadLine();

                if (input.ToLower() == "end")
                    break;

                if (input.ToLower().Contains("flatten"))
                {
                    int startIndex = "flatten ".Length;
                    flattenKey = input.Substring(startIndex);

                    dictAndInnerDict[flattenKey] = dictAndInnerDict[flattenKey]
                        .ToDictionary(innerPair => innerPair.Key + innerPair.Value, innerPair => "flatten");
                }
                else
                {
                    string[] inputArgs = input.Split();
                    string key = inputArgs[0];
                    string innerKey = inputArgs[1];
                    string innerValue = inputArgs[2];

                    if (!dictAndInnerDict.ContainsKey(key))
                    {
                        dictAndInnerDict[key] = new Dictionary<string, string>();
                    }

                    dictAndInnerDict[key][innerKey] = innerValue;
                }
            }

            dictAndInnerDict =
                dictAndInnerDict
                 .OrderByDescending(pair => pair.Key.Length)
                 .ToDictionary(pair => pair.Key, pair => pair.Value);

            int counter = 1;
            foreach (KeyValuePair<string, Dictionary<string, string>> pair in dictAndInnerDict)
            {
                Console.WriteLine($"{pair.Key}");

                Dictionary<string, string> notFlattenedDict =
                    pair.Value
                     .Where(innerPair => innerPair.Value != "flatten")
                     .OrderBy(innerPair => innerPair.Key.Length)
                     .ToDictionary(innerPair => innerPair.Key, innerPair => innerPair.Value);

                foreach (KeyValuePair<string, string> innerPair in notFlattenedDict)
                {
                    Console.WriteLine($"{counter++}. {innerPair.Key} - {innerPair.Value}");
                }

                if (pair.Key == flattenKey)
                {
                    Dictionary<string, string> flattenedDict =
                        pair.Value
                         .Where(innerPair => innerPair.Value == "flatten")
                         .ToDictionary(innerPair => innerPair.Key, innerPair => innerPair.Value);

                    foreach (KeyValuePair<string, string> innerPair in flattenedDict)
                    {
                        Console.WriteLine($"{counter++}. {innerPair.Key}");
                    }
                }

                counter = 1;
            }
        }

        private static void CottageScraper()
        {
            Dictionary<string, List<int>> treeAndHeight = new Dictionary<string, List<int>>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input.ToLower() == "chop chop")
                    break;

                string[] inputArgs = input.Split(new[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
                string tree = inputArgs[0];
                int height = int.Parse(inputArgs[1]);

                if (!treeAndHeight.ContainsKey(tree))
                {
                    treeAndHeight.Add(tree, new List<int>());
                }

                treeAndHeight[tree].Add(height);
            }

            string neededTree = Console.ReadLine();
            int neededHeight = int.Parse(Console.ReadLine());

            double allheightSum = treeAndHeight.Sum(pair => pair.Value.Sum());
            double pricePerMeter = Math.Round(allheightSum / treeAndHeight.Sum(pair => pair.Value.Count), 2);

            List<int> unneededTreesHeight =
                treeAndHeight
                 .Where(pair => pair.Key != neededTree)
                 .SelectMany(pair => pair.Value).ToList();

            List<int> neededTreesUnsuficientHeight =
                treeAndHeight[neededTree]
                 .Where(value => value < neededHeight)
                 .ToList();

            double unneededTreesPrice = Math.Round((neededTreesUnsuficientHeight.Sum() + unneededTreesHeight.Sum()) * pricePerMeter * 0.25, 2);

            List<int> neededTreesHeight =
                treeAndHeight[neededTree]
                .Where(value => value >= neededHeight)
                .ToList();

            double neededTreesPrice = Math.Round(pricePerMeter * neededTreesHeight.Sum(), 2);

            double totalPrice = Math.Round(unneededTreesPrice + neededTreesPrice, 2);

            Console.WriteLine($"Price per meter: ${pricePerMeter:F2}");
            Console.WriteLine($"Used logs price: ${neededTreesPrice:F2}");
            Console.WriteLine($"Unused logs price: ${unneededTreesPrice:F2}");
            Console.WriteLine($"CottageScraper subtotal: ${totalPrice:F2}");
        }
    }
}