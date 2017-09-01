namespace _02.SpyGram
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    class StartUp
    {
        static void Main()
        {
            string key = Console.ReadLine();

            SortedDictionary<string, List<string>> nameAndMessage = new SortedDictionary<string, List<string>>();
            while (true)
            {
                string input = Console.ReadLine();

                if (input.ToLower() == "end")
                    break;

                string pattern = "TO:\\s([A-Z]+);\\sMESSAGE:\\s.+;";
                Regex regex = new Regex(pattern);

                Match match = regex.Match(input);

                if (match.Success)
                {
                    string name = match.Groups[1].Value;
                    string encryptedMessage = string.Empty;

                    for (int i = 0; i < input.Length; i++)
                    {
                        encryptedMessage += Convert.ToChar(input[i] + int.Parse(key[i % key.Length].ToString()));
                    }

                    if (!nameAndMessage.ContainsKey(name))
                    {
                        nameAndMessage[name] = new List<string>();                    
                    }

                    nameAndMessage[name].Add(encryptedMessage);
                }
            }

            foreach (KeyValuePair<string, List<string>> pair in nameAndMessage)
            {
                Console.WriteLine($"{string.Join("\n", pair.Value)}");
            }
        }
    }
}
