namespace _02.HornetComm
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class HornetComm
    {
        private static void Main()
        {
            List<string> messages = new List<string>();
            List<string> broadcasts = new List<string>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input != null && input.ToLower() == "hornet is green")
                    break;

                if (input != null)
                {
                    string[] inputArgs = input.Split(new[] { " <-> " }, StringSplitOptions.RemoveEmptyEntries);

                    if (inputArgs.Length != 2)
                    {
                        continue;
                    }

                    string recipientCode = inputArgs[0];
                    string messageFirst = inputArgs[1];

                    bool isMessageValid = true;

                    if (recipientCode.All(char.IsDigit))
                    {
                        foreach (char symbol in messageFirst)
                        {
                            if (char.IsLetterOrDigit(symbol))
                            {
                                continue;
                            }

                            isMessageValid = false;
                            break;
                        }

                        if (isMessageValid)
                        {
                            char[] recipientCodeArray = recipientCode.ToCharArray();
                            Array.Reverse(recipientCodeArray);
                            string recipientCodeReversed = string.Join("", recipientCodeArray);

                            string result = recipientCodeReversed + " -> " + messageFirst;
                            messages.Add(result);

                            continue;
                        }
                    }

                    string messageSecond = inputArgs[0];
                    string frequency = inputArgs[1];

                    bool isFrequencyValid = true;

                    if (!messageSecond.Any(char.IsDigit))
                    {
                        foreach (char symbol in frequency)
                        {
                            if (char.IsLetterOrDigit(symbol))
                            {
                                continue;
                            }

                            isFrequencyValid = false;
                            break;
                        }

                        if (isFrequencyValid)
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

                            result += " -> " + messageSecond;
                            broadcasts.Add(result);
                        }
                    }
                }
            }

            Console.WriteLine("Broadcasts:");
            Console.WriteLine(broadcasts.Any() ? string.Join("\n", broadcasts) : "None");

            Console.WriteLine("Messages:");
            Console.WriteLine(messages.Count != 0 ? string.Join("\n", messages) : "None");
        }
    }
}