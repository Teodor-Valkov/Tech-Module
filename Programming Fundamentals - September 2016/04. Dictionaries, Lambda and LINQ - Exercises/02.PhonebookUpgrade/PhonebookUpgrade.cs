namespace _02.PhonebookUpgrade
{
    using System;
    using System.Collections.Generic;

    internal class PhonebookUpgrade
    {
        private static void Main()
        {
            string input = Console.ReadLine();
            SortedDictionary<string, string> phonebook = new SortedDictionary<string, string>();

            while (input != null && input.ToUpper() != "END")
            {
                if (input == "ListAll")
                {
                    foreach (KeyValuePair<string, string> contact in phonebook)
                    {
                        Console.WriteLine($"{contact.Key} -> {contact.Value}");
                    }

                    input = Console.ReadLine();
                    continue;
                }

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
                        Console.WriteLine(answer);
                    }
                    else
                    {
                        answer = $"Contact {name} does not exist.";
                        Console.WriteLine(answer);
                    }
                }

                input = Console.ReadLine();
            }
        }
    }
}