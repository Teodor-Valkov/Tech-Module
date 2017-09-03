namespace _12.ValidUsername
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    internal class ValidUsername
    {
        private static void Main()
        {
            // We can also use "/b" - the input args are splitted in different "words"
            string pattern = @"^[A-Za-z]\w{2,24}$";
            string input = Console.ReadLine();

            if (input != null)
            {
                string[] inputArgs = input.Split(new[] { ' ', '/', '\\', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);

                List<string> validUsers = new List<string>();
                Regex regex = new Regex(pattern);

                string[] tempResult = new string[2];
                string[] result = new string[2];

                foreach (string arg in inputArgs)
                {
                    Match match = regex.Match(arg);
                    if (match.Success)
                    {
                        validUsers.Add(arg);
                    }
                }

                for (int i = 0; i < validUsers.Count - 1; i++)
                {
                    if (i == 0)
                    {
                        result[0] = string.Empty;
                        result[1] = string.Empty;
                    }

                    tempResult[0] = validUsers[i];
                    tempResult[1] = validUsers[i + 1];

                    if (tempResult[0].Length + tempResult[1].Length > result[0].Length + result[1].Length)
                    {
                        result[0] = tempResult[0];
                        result[1] = tempResult[1];
                    }
                }

                Console.WriteLine(result[0]);
                Console.WriteLine(result[1]);
            }
        }
    }
}