namespace _02.CommandInterpreter
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class CommandInterpreter
    {
        static void Main()
        {
            List<string> input = Console.ReadLine().Split(new [] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            string[] command = Console.ReadLine().Split(' ');
            List<string> currentList = new List<string>();
            int start = 0;
            int count = 0;

            while (command[0] != null && command[0] != "end")
            {
                switch (command[0])
                {
                    case "reverse":
                        count = int.Parse(command[4]);
                        start = int.Parse(command[2]);

                        if (start < 0 || count < 0 || start >= input.Count || (start + count) > input.Count)
                        {
                            Console.WriteLine("Invalid input parameters.");
                            break;
                        }

                        currentList = input.Skip(start).Take(count).Reverse().ToList();

                        input.RemoveRange(start, count);
                        input.InsertRange(start, currentList);
                        break;

                    case "sort":
                        start = int.Parse(command[2]);
                        count = int.Parse(command[4]);

                        if (start < 0 || count < 0 || start >= input.Count || (start + count) > input.Count)
                        {
                            Console.WriteLine("Invalid input parameters.");
                            break;
                        }

                        currentList = input.Skip(start).Take(count).OrderBy(x => x).ToList();

                        input.RemoveRange(start, count);
                        input.InsertRange(start, currentList);
                        break;

                    case "rollLeft":
                        count = int.Parse(command[1]);

                        if (count < 0)
                        {
                            Console.WriteLine("Invalid input parameters.");
                            break;
                        }

                        for (int i = 0; i < count % input.Count; i++)
                        {
                            string element = input[0];
                            input.RemoveAt(0);
                            input.Add(element);
                        }
                        break;

                    case "rollRight":
                        count = int.Parse(command[1]);

                        if (count < 0)
                        {
                            Console.WriteLine("Invalid input parameters.");
                            break;
                        }

                        for (int i = 0; i < count % input.Count; i++)
                        {
                            string element = input[input.Count - 1];
                            input.RemoveAt(input.Count - 1);
                            input.Insert(0, element);
                        }
                        break;
                }

                command = Console.ReadLine().Split(' ');
            }

            Console.WriteLine($"[{string.Join(", ", input)}]");
        }
    }
}
