namespace _08.LogsAggregator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class LogsAggregator
    {
        private static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            SortedDictionary<string, SortedDictionary<string, long>> userAddressesDurations = new SortedDictionary<string, SortedDictionary<string, long>>();

            for (int i = 0; i < number; i++)
            {
                string input = Console.ReadLine();

                string[] inputArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string address = inputArgs[0];
                string user = inputArgs[1];
                long duration = long.Parse(inputArgs[2]);

                if (!userAddressesDurations.ContainsKey(user))
                {
                    userAddressesDurations.Add(user, new SortedDictionary<string, long>());
                }

                if (!userAddressesDurations[user].ContainsKey(address))
                {
                    userAddressesDurations[user][address] = 0;
                }

                userAddressesDurations[user][address] += duration;
            }

            foreach (KeyValuePair<string, SortedDictionary<string, long>> pair in userAddressesDurations)
            {
                string user = pair.Key;
                long userDuration = pair.Value.Values.Sum();
                string[] userAddresses = pair.Value.Keys.ToArray();

                Console.WriteLine($"{user}: {userDuration} [{string.Join(", ", userAddresses)}]");
            }
        }
    }
}