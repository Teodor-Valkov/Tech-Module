namespace _01.Phonebook
{
    using System;
    using System.Collections.Generic;

    class Phonebook
    {
        static void Main()
        {
            // Here we can save the result in a new List and print it after the end of all input lines, but
            // in the upgraded version of the problem the results should be printed on each iteration of the loop

            string input = Console.ReadLine();

            Dictionary<string, string> phonebook = new Dictionary<string, string>();
            List<string> result = new List<string>();

            while (input != null && input.ToUpper() != "END")
            {
                string[] text = input.Split(' ');
                string action = text[0];
                string name = text[1];

                if (action == "A")
                {
                    string number = text[2];
                    phonebook[name] = number;

                    // With the single line above we are doing the same as the code below
                    //if (phonebook.ContainsKey(name))
                    //{
                    //    phonebook[name] = number;
                    //}
                    //else
                    //{
                    //    phonebook.Add(name, number);
                    //} 
                }
                else if (action == "S")
                {
                    string answer = string.Empty;

                    if (phonebook.ContainsKey(name))
                    {
                        answer = $"{name} -> {phonebook[name]}";
                    }
                    else
                    {
                        answer = $"Contact {name} does not exist.";
                    }

                    result.Add(answer);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join("\n", result));
        }
    }
}
