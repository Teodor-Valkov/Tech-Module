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

                if (input != null && input.ToLower() == "end")
                    break;

                if (input != null)
                {
                    string[] inputArs = input.Split(new [] {' '}, StringSplitOptions.RemoveEmptyEntries);

                    string user = inputArs[2];
                    string address = inputArs[0];

                    // Different ways to take the needed substring
                    user = user.Substring(5);
                    address = new string(address.Skip(3).Take(address.Length).ToArray());

                    if (!userAddressCount.ContainsKey(user))
                    {
                        userAddressCount.Add(user, new Dictionary<string, int>());
                        userAddressCount[user].Add(address, 1);
                    }
                    else
                    {
                        if (userAddressCount[user].ContainsKey(address))
                        {
                            userAddressCount[user][address] += 1;
                        }
                        else
                        {
                            userAddressCount[user][address] = 1;
                        }
                    }
                }
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
