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

                if (name != null && name.ToLower() == "stop")
                    break;

                string email = Console.ReadLine();

                if (email != null)
                {
                    string currentDomainString = new string(email.Skip(email.Length - 2).ToArray());

                    if (currentDomainString == "us" || currentDomainString == "uk")
                        continue;
                }

                if (nameAndEmail.ContainsKey(name))
                {
                    nameAndEmail[name] = email;
                }
                else
                {
                    nameAndEmail.Add(name, email);
                }
            }

            foreach (KeyValuePair<string, string> pair in nameAndEmail)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value}");    
            }
        }
    }
}
