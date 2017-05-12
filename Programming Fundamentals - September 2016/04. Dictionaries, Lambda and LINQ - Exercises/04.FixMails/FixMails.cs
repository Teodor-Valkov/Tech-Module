namespace _04.FixMails
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class FixMails
    {
        static void Main()
        {
           Dictionary<string, string> nameAndEmail = new Dictionary<string, string>();

            while (true)
            {
                string name = Console.ReadLine();

                if (name.ToLower() == "stop")
                    break;

                string email = Console.ReadLine();

                string emailDomain = new string(email.Skip(email.Length - 2).ToArray());

                if (emailDomain == "us" || emailDomain == "uk")
                {
                    continue;
                }
                
                nameAndEmail[name] = email;
            }

            foreach (KeyValuePair<string, string> pair in nameAndEmail)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value}");
            }
        }
    }
}
