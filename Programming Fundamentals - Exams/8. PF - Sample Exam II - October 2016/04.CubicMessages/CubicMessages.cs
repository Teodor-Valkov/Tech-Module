namespace _04.CubicMessages
{
    using System;
    using System.Collections.Generic;

    internal class CubicMessages
    {
        private static void Main()
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input != null && input.ToLower() == "over!")
                    break;

                int number = int.Parse(Console.ReadLine());

                List<char> firstGroupDigits = new List<char>();
                List<char> secondGroupDigits = new List<char>();

                string message = GetDigtGroupsAndMessage(input, number, firstGroupDigits, secondGroupDigits);

                bool isMessageValid = CheckIfGroupsAndMessageAreValid(firstGroupDigits, secondGroupDigits, message);

                if (isMessageValid)
                {
                    string verificationCode = string.Empty;
                    List<int> verificationIndexes = new List<int>();

                    foreach (char symbol in firstGroupDigits)
                    {
                        if (char.IsDigit(symbol))
                        {
                            verificationIndexes.Add(int.Parse(symbol.ToString()));
                        }
                    }

                    foreach (char symbol in secondGroupDigits)
                    {
                        if (char.IsDigit(symbol))
                        {
                            verificationIndexes.Add(int.Parse(symbol.ToString()));
                        }
                    }

                    foreach (int index in verificationIndexes)
                    {
                        if (index >= message.Length)
                        {
                            verificationCode += " ";
                        }
                        else
                        {
                            verificationCode += message[index];
                        }
                    }

                    Console.WriteLine($"{message} == {verificationCode}");
                }
            }
        }

        private static string GetDigtGroupsAndMessage(string input, int number, List<char> firstGroupDigits, List<char> secondGroupDigits)
        {
            string message = string.Empty;

            foreach (char symbol in input)
            {
                if (char.IsDigit(symbol))
                {
                    firstGroupDigits.Add(symbol);
                }
                else
                {
                    break;
                }
            }

            for (int i = firstGroupDigits.Count; i < firstGroupDigits.Count + number; i++)
            {
                message += input[i];
            }

            for (int i = firstGroupDigits.Count + number; i < input.Length; i++)
            {
                secondGroupDigits.Add(input[i]);
            }

            return message;
        }

        private static bool CheckIfGroupsAndMessageAreValid(List<char> firstGroupDigits, List<char> secondGroupDigits, string message)
        {
            foreach (char symbol in firstGroupDigits)
            {
                if (char.IsDigit(symbol))
                {
                    continue;
                }

                return false;
            }

            foreach (char symbol in message)
            {
                if (char.IsLetter(symbol))
                {
                    continue;
                }

                return false;
            }

            foreach (char symbol in secondGroupDigits)
            {
                if (!char.IsLetter(symbol))
                {
                    continue;
                }

                return false;
            }

            return true;
        }
    }
}