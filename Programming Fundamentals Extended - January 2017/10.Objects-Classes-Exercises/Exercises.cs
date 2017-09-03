namespace _10.Objects_Classes_Exercises
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Exercises
    {
        private static void Main()
        {
            // Task 1
            MoreExercises();

            // Task 2
            OptimizedBankingSystem();

            // Task 3
            Animals();

            // Task 4
            Websites();

            // Task 5
            Boxes();

            // Task 6
            Messages();
        }

        private static void MoreExercises()
        {
            List<Exercise> exercises = new List<Exercise>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input.ToLower() == "go go go")
                    break;

                string[] inputArgs = input.Split(new[] { " -> ", ", " }, StringSplitOptions.RemoveEmptyEntries);

                List<string> currentProblems = new List<string>();
                for (int i = 3; i < inputArgs.Length; i++)
                {
                    currentProblems.Add(inputArgs[i]);
                }

                Exercise currentExercise = new Exercise
                {
                    Topic = inputArgs[0],
                    CourseName = inputArgs[1],
                    JudgeContestLink = inputArgs[2],
                    Problems = currentProblems
                };

                exercises.Add(currentExercise);
            }

            foreach (Exercise exercise in exercises)
            {
                Console.WriteLine($"Exercises: {exercise.Topic}");
                Console.WriteLine($"Problems for exercises and homework for the \"{exercise.CourseName}\" course @ SoftUni.");
                Console.WriteLine($"Check your solutions here: {exercise.JudgeContestLink}");

                for (int i = 0; i < exercise.Problems.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {exercise.Problems[i]}");
                }
            }
        }

        private static void OptimizedBankingSystem()
        {
            List<BankAccount> bankAccounts = new List<BankAccount>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input.ToLower() == "end")
                    break;

                string[] inputArgs = input.Split(new[] { " | " }, StringSplitOptions.RemoveEmptyEntries);

                BankAccount currentBankAccount = new BankAccount
                {
                    Bank = inputArgs[0],
                    Name = inputArgs[1],
                    Balance = decimal.Parse(inputArgs[2])
                };

                bankAccounts.Add(currentBankAccount);
            }

            foreach (BankAccount account in bankAccounts.OrderByDescending(ac => ac.Balance).ThenBy(ac => ac.Bank.Length))
            {
                Console.WriteLine($"{account.Name} -> {account.Balance} ({account.Bank})");
            }

            //bankAccounts
            //    .OrderByDescending(ac => ac.Balance)
            //    .ThenBy(ac => ac.Bank.Length)
            //    .ToList()
            //    .ForEach(account => Console.WriteLine($"{account.Name} -> {account.Balance} ({account.Bank})"));
        }

        private static void Animals()
        {
            List<Dog> dogs = new List<Dog>();
            List<Cat> cats = new List<Cat>();
            List<Snake> snakes = new List<Snake>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input.ToLower() == "i'm your huckleberry")
                    break;

                string[] inputArgs = input.Split();
                string type = inputArgs[0];
                string name = inputArgs[1];
                int age = 0;

                switch (type)
                {
                    case "talk":
                        if (dogs.Any(d => d.Name == name))
                        {
                            Dog foundDog = dogs.Single(neededDog => neededDog.Name == name);
                            foundDog.ProduceSound();
                        }

                        if (cats.Any(c => c.Name == name))
                        {
                            Cat foundCat = cats.Single(neededCat => neededCat.Name == name);
                            foundCat.ProduceSound();
                        }

                        if (snakes.Any(sn => sn.Name == name))
                        {
                            Snake foundSnake = snakes.Single(neededSnake => neededSnake.Name == name);
                            foundSnake.ProduceSound();
                        }
                        break;

                    case "Dog":
                        age = int.Parse(inputArgs[2]);
                        int numberOfLegs = int.Parse(inputArgs[3]);

                        Dog dog = new Dog
                        {
                            Name = name,
                            Age = age,
                            NumberOfLegs = numberOfLegs
                        };

                        dogs.Add(dog);
                        break;

                    case "Cat":
                        age = int.Parse(inputArgs[2]);
                        int intelligenceQontient = int.Parse(inputArgs[3]);

                        Cat cat = new Cat
                        {
                            Name = name,
                            Age = age,
                            IntelligenceQuotient = intelligenceQontient
                        };

                        cats.Add(cat);
                        break;

                    case "Snake":
                        age = int.Parse(inputArgs[2]);
                        int crueltyCoefficient = int.Parse(inputArgs[3]);

                        Snake snake = new Snake
                        {
                            Name = name,
                            Age = age,
                            CrueltyCoefficient = crueltyCoefficient
                        };

                        snakes.Add(snake);
                        break;
                }
            }

            dogs.ForEach(dog =>
                Console.WriteLine($"Dog: {dog.Name}, Age: {dog.Age}, Number Of Legs: {dog.NumberOfLegs}"));

            cats.ForEach(cat =>
                Console.WriteLine($"Cat: {cat.Name}, Age: {cat.Age}, IQ: {cat.IntelligenceQuotient}"));

            snakes.ForEach(snake =>
                Console.WriteLine($"Snake: {snake.Name}, Age: {snake.Age}, Cruelty: {snake.CrueltyCoefficient}"));
        }

        private static void Websites()
        {
            List<Website> websites = new List<Website>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input.ToLower() == "end")
                    break;

                string[] inputArgs = input.Split(new[] { " | ", "," }, StringSplitOptions.RemoveEmptyEntries);
                string host = inputArgs[0];
                string domain = inputArgs[1];
                List<string> queries = new List<string>();

                if (inputArgs.Length > 2)
                {
                    for (int i = 2; i < inputArgs.Length; i++)
                    {
                        queries.Add(inputArgs[i]);
                    }
                }

                Website currentWebsite = new Website
                {
                    Host = host,
                    Domain = domain,
                    Queries = queries,
                };

                websites.Add(currentWebsite);
            }

            foreach (Website website in websites)
            {
                Console.WriteLine(website.Queries.Any()
                    ? $"https://www.{website.Host}.{website.Domain}/query?=[{string.Join("]&[", website.Queries)}]"
                    : $"https://www.{website.Host}.{website.Domain}");
            }
        }

        private static void Boxes()
        {
            List<Box> boxes = new List<Box>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input.ToLower() == "end")
                    break;

                string[] cordinates = input.Split(new[] { " | " }, StringSplitOptions.RemoveEmptyEntries);
                string[] firstPoint = cordinates[0].Split(new[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                string[] secondPoint = cordinates[1].Split(new[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                string[] thirdPoint = cordinates[2].Split(new[] { ":" }, StringSplitOptions.RemoveEmptyEntries);

                Box box = new Box();
                {
                    box.X1 = int.Parse(firstPoint[0]);
                    box.X2 = int.Parse(secondPoint[0]);
                    box.Y1 = int.Parse(secondPoint[1]);
                    box.Y2 = int.Parse(thirdPoint[1]);
                }

                boxes.Add(box);
            }

            foreach (Box box in boxes)
            {
                int widht = Math.Abs(box.X1 - box.X2);
                int height = Math.Abs(box.Y1 - box.Y2);

                Console.WriteLine($"Box: {widht}, {height}");
                Console.WriteLine($"Perimeter: {Box.CalculatePerimeter(widht, height)}");
                Console.WriteLine($"Area: {Box.CalculateArea(widht, height)}");
            }
        }

        private static void Messages()
        {
            List<User> registeredUsers = new List<User>();
            List<Message> messages = new List<Message>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input.ToLower() == "exit")
                    break;

                string[] inputArgs = input.Split();

                string name = string.Empty;
                string sender = string.Empty;
                string receiver = string.Empty;
                string content = string.Empty;

                if (inputArgs[0] == "register")
                {
                    name = inputArgs[1];

                    User user = new User();
                    {
                        user.Username = name;
                        user.ReceivedMessages = new List<Message>();
                    }

                    registeredUsers.Add(user);
                }
                else
                {
                    sender = inputArgs[0];
                    receiver = inputArgs[2];
                    content = string.Join(" ", inputArgs.Skip(3));

                    if (registeredUsers.Any(user => user.Username == sender) && registeredUsers.Any(user => user.Username == receiver))
                    {
                        Message mesages = new Message();
                        {
                            mesages.Content = content;
                            mesages.Sender = registeredUsers.First(user => user.Username == sender);
                        }

                        messages.Add(mesages);
                        registeredUsers.First(u => u.Username == receiver).ReceivedMessages.Add(mesages);
                    }
                }
            }

            string[] users = Console.ReadLine().Split();
            User firstUser = registeredUsers.First(user => user.Username == users[0]);
            User secondUser = registeredUsers.First(user => user.Username == users[1]);

            List<string> firstUserMessages = new List<string>();
            List<string> secondUserMessages = new List<string>();

            foreach (User user in registeredUsers)
            {
                foreach (Message message in user.ReceivedMessages)
                {
                    if (message.Sender == firstUser && user == secondUser)
                    {
                        firstUserMessages.Add(message.Content);
                    }
                }
            }

            foreach (User user in registeredUsers)
            {
                foreach (Message message in user.ReceivedMessages)
                {
                    if (message.Sender == secondUser && user == firstUser)
                    {
                        secondUserMessages.Add(message.Content);
                    }
                }
            }

            bool hasMessages = true;
            int moreMessagesCount = Math.Max(firstUserMessages.Count, secondUserMessages.Count);

            for (int i = 0; i < moreMessagesCount; i++)
            {
                if (i < firstUserMessages.Count)
                {
                    Console.WriteLine($"{firstUser.Username}: {firstUserMessages[i]}");
                    hasMessages = false;
                }

                if (i < secondUserMessages.Count)
                {
                    Console.WriteLine($"{secondUserMessages[i]} :{secondUser.Username}");
                    hasMessages = false;
                }
            }

            if (hasMessages)
            {
                Console.WriteLine("No messages");
            }
        }
    }

    internal class Exercise
    {
        public string Topic { get; set; }
        public string CourseName { get; set; }
        public string JudgeContestLink { get; set; }
        public List<string> Problems { get; set; }
    }

    internal class BankAccount
    {
        public string Name { get; set; }
        public string Bank { get; set; }
        public decimal Balance { get; set; }
    }

    internal class Animal
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    internal class Dog : Animal
    {
        public int NumberOfLegs { get; set; }

        public void ProduceSound()
        {
            Console.WriteLine("I'm a Distinguishedog, and I will now produce a distinguished sound! Bau Bau.");
        }
    }

    internal class Cat : Animal
    {
        public int IntelligenceQuotient { get; set; }

        public void ProduceSound()
        {
            Console.WriteLine("I'm an Aristocat, and I will now produce an aristocratic sound! Myau Myau.");
        }
    }

    internal class Snake : Animal
    {
        public int CrueltyCoefficient { get; set; }

        public void ProduceSound()
        {
            Console.WriteLine("I'm a Sophistisnake, and I will now produce a sophisticated sound! Honey, I'm home.");
        }
    }

    internal class Website
    {
        public string Host { get; set; }
        public string Domain { get; set; }
        public List<string> Queries { get; set; }
    }

    internal class Box
    {
        public int X1 { get; set; }
        public int X2 { get; set; }
        public int Y1 { get; set; }
        public int Y2 { get; set; }

        public static int CalculatePerimeter(int width, int height)
        {
            return 2 * width + 2 * height;
        }

        public static int CalculateArea(int width, int height)
        {
            return width * height;
        }
    }

    internal class User
    {
        public string Username { get; set; }
        public List<Message> ReceivedMessages { get; set; }
    }

    internal class Message
    {
        public string Content { get; set; }
        public User Sender { get; set; }
    }
}