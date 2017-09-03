namespace _11.Files_Directories_Exercises
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    internal class Exercises
    {
        private static void Main()
        {
            // Task 1
            FilterExtensions();

            // Task 2
            HtmlContents();

            // Task 3
            UserDatabase();

            // Task 4
            ReDirectory();
        }

        private static void FilterExtensions()
        {
            string extension = Console.ReadLine();

            List<string> files = Directory.GetFiles("../../input-task1").ToList();
            foreach (string file in files)
            {
                string newFile = file.Replace("../../input-task1\\", string.Empty);
                string temp = newFile.Split('.').Last();

                if (temp == extension)
                {
                    Console.WriteLine(newFile);
                }
            }
        }

        private static void HtmlContents()
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input.ToLower() == "exit")
                    break;

                string[] inputArgs = input.Split();

                if (inputArgs[0] == "title")
                {
                    string headIn = "<!DOCTYPE>\r\n" + "<html>\r\n" + "<head>\r\n" +
                                    $"\t<title>{string.Join(" ", inputArgs.Skip(1))}</title>\r\n" +
                                    "</head>\r\n" + "<body>\r\n";

                    File.WriteAllText("../../HTML/head.txt", headIn);
                }
                else
                {
                    string bodyIn = $"\t<{inputArgs[0]}>{string.Join(" ", inputArgs.Skip(1))}</{inputArgs[0]}>\r\n";

                    File.AppendAllText("../../HTML/body.txt", bodyIn);
                }
            }

            List<string> head = File.ReadAllLines("../../HTML/head.txt").ToList();
            List<string> body = File.ReadAllLines("../../HTML/body.txt").ToList();
            string end = "</body>\r\n" + "</html>";

            File.AppendAllLines("../../HTML/index.html", head);
            File.AppendAllLines("../../HTML/index.html", body);
            File.AppendAllText("../../HTML/index.html", end);
        }

        private static void UserDatabase()
        {
            Directory.CreateDirectory("../../Users");
            string userDirectory = "../../Users";

            while (true)
            {
                string input = Console.ReadLine();

                if (input.ToLower() == "exit")
                    break;

                string[] inputArgs = input.Split();

                string command = inputArgs[0];
                string name = string.Empty;
                string password = string.Empty;
                string confirmPassword = string.Empty;

                switch (command)
                {
                    case "register":
                        name = inputArgs[1];
                        password = inputArgs[2];
                        confirmPassword = inputArgs[3];

                        string[] files = Directory.GetFiles(userDirectory);

                        if (files.Contains($"{userDirectory}\\{name}.txt"))
                        {
                            Console.WriteLine("The given username already exists.");
                            continue;
                        }

                        if (password != confirmPassword)
                        {
                            Console.WriteLine("The two passwords must match.");
                            continue;
                        }

                        File.WriteAllText($"{userDirectory}/{name}.txt", password);
                        break;

                    case "login":
                        name = inputArgs[1];
                        password = inputArgs[2];

                        string[] users = Directory.GetFiles(userDirectory);

                        if (users.Contains($"{userDirectory}\\{name}.txt"))
                        {
                            string content = File.ReadAllText($"{userDirectory}/{name}.txt");

                            if (!content.Contains(password))
                            {
                                Console.WriteLine("The password you entered is incorrect.");
                                continue;
                            }

                            if (content.Contains(password) && content.Contains("logged in"))
                            {
                                Console.WriteLine("There is already a logged in user.");
                                continue;
                            }

                            File.AppendAllText($"{userDirectory}/{name}.txt", " logged in");
                        }
                        else
                        {
                            Console.WriteLine("There is no user with the given username.");
                        }
                        break;

                    case "logout":
                        files = Directory.GetFiles(userDirectory);

                        foreach (string file in files)
                        {
                            string content = File.ReadAllText($"{file}");

                            if (content.Contains("logged in"))
                            {
                                content = content.Replace("logged in", string.Empty);
                            }

                            File.WriteAllText($"{file}", content);
                        }
                        break;
                }
            }
        }

        private static void ReDirectory()
        {
            string[] files = Directory.GetFiles("../../input-task2");

            if (!Directory.Exists("../../output"))
            {
                Directory.CreateDirectory("../../output");
            }

            foreach (string file in files)
            {
                string[] content = file.Split(new[] { '.', '/', '\\' }, StringSplitOptions.RemoveEmptyEntries);

                string extension = content.Last();

                string fileName = string.Join(".", content.Skip(1));

                if (!File.Exists($"../../output/{extension}s.txt"))
                {
                    File.WriteAllText($"../../output/{extension}s.txt", fileName + "\r\n");
                }
                else
                {
                    File.AppendAllText($"../../output/{extension}s.txt", fileName + "\r\n");
                }
            }
        }
    }
}