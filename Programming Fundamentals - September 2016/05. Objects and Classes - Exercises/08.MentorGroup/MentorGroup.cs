namespace _08.MentorGroup
{
    using System;
    using System.Linq;
    using System.Globalization;
    using System.Collections.Generic;

    class User
    {
        public User()
        {
            Comments = new List<string>();
            Dates = new List<DateTime>();
        }

        public string Name { get; set; }
        public List<DateTime> Dates { get; set; }
        public List<string> Comments { get; set; }
    }

    class MentorGroup
    {
        static void Main()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Dictionary<string, User> nameUsersDictionary = new Dictionary<string, User>();

            FillingDatesInNameUsersDictionary(nameUsersDictionary);
            FillingCommentsInNameUsersDictionary(nameUsersDictionary);

            PrintingDictionaryOnConsole(nameUsersDictionary);
        }

        private static void FillingDatesInNameUsersDictionary(Dictionary<string, User> nameUsersDictionary)
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input != null && input.ToLower() == "end of dates")
                    break;

                if (input != null)
                {
                    string[] inputArgs = input.Split(' ', ',');
                    string currentName = inputArgs[0];

                    if (!nameUsersDictionary.ContainsKey(currentName))
                    {
                        nameUsersDictionary.Add(currentName, new User());
                    }

                    for (int i = 1; i < inputArgs.Length; i++)
                    {
                        DateTime currentDate = DateTime.ParseExact(inputArgs[i], "dd/MM/yyyy", CultureInfo.CurrentCulture);
                        nameUsersDictionary[currentName].Dates.Add(currentDate);
                    }
                }
            }
        }

        private static void FillingCommentsInNameUsersDictionary(Dictionary<string, User> nameUsersDictionary)
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input != null && input.ToLower() == "end of comments")
                    break;

                if (input != null)
                {
                    string[] inputArgs = input.Split('-');
                    string currentName = inputArgs[0];
                    string currentComment = inputArgs[1];

                    if (nameUsersDictionary.ContainsKey(currentName))
                    {
                        nameUsersDictionary[currentName].Comments.Add(currentComment);
                    }
                }
            }
        }

        private static void PrintingDictionaryOnConsole(Dictionary<string, User> nameUsersDictionary)
        {
            foreach (KeyValuePair<string, User> pair in nameUsersDictionary.OrderBy(x => x.Key))
            {
                string currentUser = pair.Key;
                Console.WriteLine(currentUser);

                Console.WriteLine("Comments:");
                foreach (string comment in nameUsersDictionary[currentUser].Comments)
                {
                    Console.WriteLine($"- {comment}");
                }

                Console.WriteLine("Dates attended:");
                foreach (DateTime date in nameUsersDictionary[currentUser].Dates.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {date.ToString("dd/MM/yyyy", CultureInfo.CurrentCulture)}");
                }
            }
        }
    }
}
