namespace _06.UserLogs
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class UserLogs
    {
        static void Main()
        {
            SortedDictionary<string, Dictionary<string, int>> userAddressCount = new SortedDictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input.ToLower() == "end")
                    break;

                string[] inputArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string user = inputArgs[2].Substring(5);
                string address = new string(inputArgs[0].Skip(3).Take(inputArgs[0].Length).ToArray());

                if (!userAddressCount.ContainsKey(user))
                {
                    userAddressCount[user] = new Dictionary<string, int>();
                }

                if (!userAddressCount[user].ContainsKey(address))
                {
                    userAddressCount[user][address] = 0;
                }

                userAddressCount[user][address]++;
            }

            foreach (KeyValuePair<string, Dictionary<string, int>> pair in userAddressCount)
            {
                Console.WriteLine($"{pair.Key}: ");

                int counter = 1;
                foreach (KeyValuePair<string, int> innerPair in pair.Value)
                {
                    Console.Write(counter == pair.Value.Count
                        ? $"{innerPair.Key} => {innerPair.Value}.\n"
                        : $"{innerPair.Key} => {innerPair.Value}, ");

                    counter++;
                }
            }
        }
    }
}
