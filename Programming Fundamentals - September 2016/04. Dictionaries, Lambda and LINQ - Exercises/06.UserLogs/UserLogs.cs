namespace _06.UserLogs
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class UserLogs
    {
        static void Main()
        {
            Dictionary<string, Dictionary<string, int>> userAddressCount = new Dictionary<string, Dictionary<string, int>>();

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

            foreach (string user in userAddressCount.Keys.OrderBy(x => x))
            {
                Console.WriteLine($"{user}: ");
                int currentUserAddresses = userAddressCount[user].Values.Count;

                List<string> currentUserAddressesString = new List<string>();
                currentUserAddressesString.AddRange(userAddressCount[user].Keys);

                List<int> currentUserAddressesInt= new List<int>();
                currentUserAddressesInt.AddRange(userAddressCount[user].Values);

                for (int i = 0; i < currentUserAddresses; i++)
                {
                    if (i == currentUserAddresses - 1)
                    {
                        Console.WriteLine($"{currentUserAddressesString[i]} => {currentUserAddressesInt[i]}.");
                    }
                    else
                    {
                        Console.Write($"{currentUserAddressesString[i]} => {currentUserAddressesInt[i]}, ");
                    }
                }
            }
        }
    }
}
