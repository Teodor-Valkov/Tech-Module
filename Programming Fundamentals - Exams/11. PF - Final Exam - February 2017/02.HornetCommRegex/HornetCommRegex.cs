namespace _02.HornetCommRegex
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    internal class HornetCommRegex
    {
        private static void Main()
        {
            List<string> messages = new List<string>();
            List<string> broadcasts = new List<string>();

            string messagePattern = @"^(\d+) <-> ([a-zA-Z0-9]+)$";
            string broadcastPattern = @"^(\D+) <-> ([a-zA-Z0-9]+)$";

            Regex messageRegex = new Regex(messagePattern);
            Regex broadcastRegex = new Regex(broadcastPattern);

            while (true)
            {
                string input = Console.ReadLine();

                if (input != null && input.ToLower() == "hornet is green")
                    break;

                if (input != null)
                {
                    Match messageMatch = messageRegex.Match(input);

                    if (messageMatch.Success)
                    {
                        string recipientCode = string.Join("", messageMatch.Groups[1].Value.Reverse());
                        string message = messageMatch.Groups[2].Value;

                        messages.Add(recipientCode + " -> " + message);
                    }
                }

                if (input != null)
                {
                    Match broadcastMatch = broadcastRegex.Match(input);

                    if (broadcastMatch.Success)
                    {
                        string message = broadcastMatch.Groups[1].Value;
                        string frequency = DecryptFrequency(broadcastMatch.Groups[2].Value);

                        broadcasts.Add(frequency + " -> " + message);
                    }
                }
            }

            Console.WriteLine("Broadcasts:");
            Console.WriteLine(broadcasts.Any() ? string.Join("\n", broadcasts) : "None");

            Console.WriteLine("Messages:");
            Console.WriteLine(messages.Count != 0 ? string.Join("\n", messages) : "None");
        }

        private static string DecryptFrequency(string frequency)
        {
            string result = string.Empty;

            foreach (char symbol in frequency)
            {
                if (char.IsLower(symbol))
                {
                    result += symbol.ToString().ToUpper();
                }
                else if (char.IsUpper(symbol))
                {
                    result += symbol.ToString().ToLower();
                }
                else
                {
                    result += symbol.ToString();
                }
            }

            return result;
        }
    }
}