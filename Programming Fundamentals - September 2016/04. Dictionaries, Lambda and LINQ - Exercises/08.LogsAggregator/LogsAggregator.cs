    namespace _08.LogsAggregator
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class LogsAggregator
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, long>> userAddressDurationDictionary = new Dictionary<string, Dictionary<string, long>>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                if (input != null)
                {
                    string[] inputArgs = input.Split(new [] {' '}, StringSplitOptions.RemoveEmptyEntries);

                    string address = inputArgs[0];
                    string user = inputArgs[1];
                    long duration = long.Parse(inputArgs[2]);

                    if (!userAddressDurationDictionary.ContainsKey(user))
                    {
                        userAddressDurationDictionary.Add(user, new Dictionary<string, long>());
                        userAddressDurationDictionary[user].Add(address, duration);
                    }
                    else
                    {
                        if (!userAddressDurationDictionary[user].ContainsKey(address))
                        {
                            userAddressDurationDictionary[user].Add(address, duration);
                        }
                        else
                        {
                            userAddressDurationDictionary[user][address] += duration;
                        }
                    }
                }
            }

            foreach (KeyValuePair<string, Dictionary<string, long>> pair in userAddressDurationDictionary.OrderBy(x => x.Key))
            {
                string currentUser = pair.Key;
                long currentUserDuration = pair.Value.Values.Sum();
                string[] currentUserAddresses= pair.Value.Keys.OrderBy(x => x).ToArray();

                Console.WriteLine($"{currentUser}: {currentUserDuration} [{(string.Join(", ", currentUserAddresses))}]");
            }
        }
    }
}
