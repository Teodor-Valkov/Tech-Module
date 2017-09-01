namespace _02.HogwartsSorting
{
    using System;
    using System.Collections.Generic;

    class HogwartsSorting
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string[] facultyNumber = new string[n];
            int[] homes = new int[4];

            List<string> results = new List<string>();
            for (int i = 0; i < n; i++)
            {
                string[] name = Console.ReadLine().Split(' ');

                string firstName = name[0];
                string secondName = name[1];
                string home = string.Empty;
                long sum = 0;
                   
                foreach (char letter in firstName)
                {
                    sum += letter;
                }

                foreach (char letter in secondName)
                {
                    sum += letter;
                }
                
                switch (sum % 4)
                {
                    case 0:
                        homes[0]++;
                        home = "Gryffindor";
                        facultyNumber[i] = sum.ToString() + firstName[0] + secondName[0];
                        break;
                    case 1:
                        homes[1]++;
                        home = "Slytherin";
                        facultyNumber[i] = sum.ToString() + firstName[0] + secondName[0];
                        break;
                    case 2:
                        homes[2]++;
                        home = "Ravenclaw";
                        facultyNumber[i] = sum.ToString() + firstName[0] + secondName[0];
                        break;
                    case 3:
                        homes[3]++;
                        home = "Hufflepuff";
                        facultyNumber[i] = sum.ToString() + firstName[0] + secondName[0];
                        break;
                    default:
                        continue;
                }

                string result = $"{home} {facultyNumber[i]}";
                results.Add(result);
            }

            Console.WriteLine(string.Join("\n", results));
            Console.WriteLine();
            Console.WriteLine($"Gryffindor: {homes[0]}");
            Console.WriteLine($"Slytherin: {homes[1]}");
            Console.WriteLine($"Ravenclaw: {homes[2]}");
            Console.WriteLine($"Hufflepuff: {homes[3]}");
        }
    }
}
