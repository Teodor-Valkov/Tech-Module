namespace _08.Advanced_Collections_Exercises
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Exercises
    {
        private static void Main()
        {
            // Task 1
            Shellbound();

            // Task 2
            DictRefAdvanced();

            // Task 3
            ForumTopics();

            // Task 4
            SocialMediaPosts();
        }

        private static void Shellbound()
        {
            Dictionary<string, HashSet<int>> regionsAndShellSizes = new Dictionary<string, HashSet<int>>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input.ToLower() == "aggregate")
                    break;

                string[] inputArgs = input.Split();
                string region = inputArgs[0];
                int size = int.Parse(inputArgs[1]);

                if (!regionsAndShellSizes.ContainsKey(region))
                {
                    regionsAndShellSizes[region] = new HashSet<int>();
                }

                regionsAndShellSizes[region].Add(size);
            }

            foreach (KeyValuePair<string, HashSet<int>> pair in regionsAndShellSizes)
            {
                int giantShellSize = pair.Value.Sum() - (pair.Value.Sum() / pair.Value.Count);

                Console.WriteLine($"{pair.Key} -> {string.Join(", ", pair.Value)} ({giantShellSize})");
            }

            //regionAndShellSizes
            //    .ToList()
            //    .ForEach(pair =>
            //        Console.WriteLine($"{pair.Key} -> {string.Join(", ", pair.Value)} ({pair.Value.Sum() - (pair.Value.Sum() / pair.Value.Count)})"));
        }

        private static void DictRefAdvanced()
        {
            Dictionary<string, List<int>> nameAndValues = new Dictionary<string, List<int>>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input.ToLower() == "end")
                    break;

                string[] inputArgs = input.Split(new[] { " -> ", ", " }, StringSplitOptions.RemoveEmptyEntries);

                bool isInputContainingOtherKey = FindIfInputContainsOtherKey(inputArgs[1]);

                if (isInputContainingOtherKey)
                {
                    string firstName = inputArgs[0];
                    string secondName = inputArgs[1];

                    if (nameAndValues.ContainsKey(secondName))
                    {
                        nameAndValues[firstName] = new List<int>(nameAndValues[secondName]);
                    }
                }
                else
                {
                    string name = inputArgs[0];
                    List<int> values = new List<int>();

                    for (int i = 1; i < inputArgs.Length; i++)
                    {
                        values.Add(int.Parse(inputArgs[i]));
                    }

                    if (!nameAndValues.ContainsKey(name))
                    {
                        nameAndValues[name] = new List<int>();
                    }

                    nameAndValues[name].AddRange(values);
                }
            }

            foreach (KeyValuePair<string, List<int>> pair in nameAndValues)
            {
                Console.WriteLine($"{pair.Key} === {string.Join(", ", pair.Value)}");
            }

            //nameAndValues
            //    .ToList()
            //    .ForEach(pair =>
            //        Console.WriteLine($"{pair.Key} === {string.Join(", ", pair.Value)}"));
        }

        private static bool FindIfInputContainsOtherKey(string arg)
        {
            foreach (char symbol in arg)
            {
                if (char.IsDigit(symbol))
                {
                    return false;
                }
            }

            return true;
        }

        private static void ForumTopics()
        {
            Dictionary<string, HashSet<string>> topicsAndTags = new Dictionary<string, HashSet<string>>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input.ToLower() == "filter")
                    break;

                string[] inputArgs = input.Split(new[] { " -> ", ", " }, StringSplitOptions.RemoveEmptyEntries);
                string topic = inputArgs[0];
                HashSet<string> values = new HashSet<string>();

                for (int i = 1; i < inputArgs.Length; i++)
                {
                    values.Add(inputArgs[i]);
                }

                if (!topicsAndTags.ContainsKey(topic))
                {
                    topicsAndTags[topic] = new HashSet<string>();
                }

                foreach (string value in values)
                {
                    topicsAndTags[topic].Add(value);
                }
            }

            string[] neededTags = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

            foreach (KeyValuePair<string, HashSet<string>> pair in topicsAndTags)
            {
                for (int i = 0; i < neededTags.Length; i++)
                {
                    if (!pair.Value.Contains(neededTags[i]))
                    {
                        break;
                    }

                    if (i == neededTags.Length - 1)
                    {
                        Console.WriteLine($"{pair.Key} | #{string.Join(", #", pair.Value)}");
                    }
                }
            }

            //topicsAndTags
            //   .Where(pair => pair.Value.Count(tag => neededTags.Contains(tag)) == neededTags.Length)
            //   .ToList()
            //   .ForEach(pair => Console.WriteLine($"{pair.Key} | #{string.Join(", #", pair.Value)}"));
        }

        private static void SocialMediaPosts()
        {
            Dictionary<string, Dictionary<string, int>> likesAndDislikes = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, Dictionary<string, List<string>>> commentatorsAndComments = new Dictionary<string, Dictionary<string, List<string>>>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input.ToLower() == "drop the media")
                    break;

                string[] inputArgs = input.Split();
                string command = inputArgs[0];
                string action = inputArgs[1];

                switch (command)
                {
                    case "post":
                        if (!likesAndDislikes.ContainsKey(action))
                        {
                            likesAndDislikes.Add(action, new Dictionary<string, int>());
                            likesAndDislikes[action]["Likes"] = 0;
                            likesAndDislikes[action]["Dislikes"] = 0;
                        }
                        break;

                    case "like":
                        if (likesAndDislikes.ContainsKey(action))
                        {
                            likesAndDislikes[action]["Likes"]++;
                        }
                        break;

                    case "dislike":
                        if (likesAndDislikes.ContainsKey(action))
                        {
                            likesAndDislikes[action]["Dislikes"]++;
                        }
                        break;

                    case "comment":
                        string commentator = inputArgs[2];
                        List<string> comments = new List<string>();

                        for (int i = 3; i < inputArgs.Length; i++)
                        {
                            comments.Add(inputArgs[i]);
                        }

                        if (!commentatorsAndComments.ContainsKey(action))
                        {
                            commentatorsAndComments[action] = new Dictionary<string, List<string>>();
                        }

                        commentatorsAndComments[action][commentator] = comments;
                        break;
                }
            }

            foreach (KeyValuePair<string, Dictionary<string, int>> pair in likesAndDislikes)
            {
                Console.Write($"Post: {pair.Key}");

                foreach (KeyValuePair<string, int> innerPair in pair.Value)
                {
                    Console.Write($" | {innerPair.Key}: {Math.Max(innerPair.Value, 0)}");
                }

                Console.WriteLine("\nComments:");

                bool isPostCommented = commentatorsAndComments.ContainsKey(pair.Key);

                if (isPostCommented)
                {
                    foreach (KeyValuePair<string, Dictionary<string, List<string>>> comment in commentatorsAndComments.Where(comment => comment.Key == pair.Key))
                    {
                        foreach (KeyValuePair<string, List<string>> commentatorAndComment in comment.Value)
                        {
                            Console.WriteLine($"*  {commentatorAndComment.Key}: {string.Join(" ", commentatorAndComment.Value)}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("None");
                }
            }
        }
    }
}