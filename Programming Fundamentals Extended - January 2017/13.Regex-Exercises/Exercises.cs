namespace _13.Regex_Exercises
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    class Exercises
    {
        static void Main()
        {
            // Task 1
            Cards();

            // Task 2
            FishStatistics();

            // Task 3
            WordEncounter();

            // Task 4
            HappinessIndex();

            // Task 5
            Commits();
        }

        private static void Cards()
        {
            string input = Console.ReadLine();
            List<string> result = new List<string>();

            string pattern = "([1]?[0-9JQKA])([CDHS])";
            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(input);
            foreach (Match match in matches)
            {
                int number = 0;

                if (int.TryParse(match.Groups[1].Value, out number))
                {
                    if (number < 2 || number > 10)
                    {
                        continue;
                    }
                }

                result.Add(match.Value);
            }

            Console.WriteLine(string.Join(", ", result));
        }

        private static void FishStatistics()
        {
            string input = Console.ReadLine();

            string pattern = @"(>*)<(\(+)(\'|-|x)>";
            Regex regex = new Regex(pattern);

            bool hasMatch = false;
            MatchCollection matches = regex.Matches(input);
            for (int i = 0; i < matches.Count; i++)
            {
                string fish = matches[i].Groups[0].Value;
                int tailLength = matches[i].Groups[1].Length;
                int bodyLength = matches[i].Groups[2].Length;
                string status = matches[i].Groups[3].Value;

                string tailType = string.Empty;
                if (tailLength > 5)
                {
                    tailType = "Long";
                }
                else if (tailLength > 1)
                {
                    tailType = "Medium";
                }
                else if (tailLength == 1)
                {
                    tailType = "Short";
                }
                else
                {
                    tailType = "None";
                }

                string bodyType = string.Empty;
                if (bodyLength > 10)
                {
                    bodyType = "Long";
                }
                else if (bodyLength > 5)
                {
                    bodyType = "Medium";
                }
                else
                {
                    bodyType = "Short";
                }

                switch (status)
                {
                    case "'": status = "Awake"; break;
                    case "-": status = "Asleep"; break;
                    case "x": status = "Dead"; break;
                }

                hasMatch = true;

                Console.WriteLine($"Fish {i + 1}: {fish}");

                Console.WriteLine(tailType != "None"
                    ? $"  Tail type: {tailType} ({tailLength * 2} cm)"
                    : $"  Tail type: {tailType}");

                Console.WriteLine($"  Body type: {bodyType} ({bodyLength * 2} cm)");
                Console.WriteLine($"  Status: {status}");
            }

            if (!hasMatch)
            {
                Console.WriteLine("No fish found.");
            }
        }

        private static void WordEncounter()
        {
            string filter = Console.ReadLine();
            char symbol = filter[0];
            int count = int.Parse(filter[1].ToString());

            List<string> validWords = new List<string>();
            while (true)
            {
                string input = Console.ReadLine();

                if (input.ToLower() == "end")
                    break;

                string patternForSentences = @"^([A-Z].*)[\.|!|?]$";
                Regex regexForSentences = new Regex(patternForSentences);

                if (regexForSentences.IsMatch(input))
                {
                    Match match = regexForSentences.Match(input);
                    string sentence = match.Groups[1].Value;

                    string patternForWords = @"[A-Za-z]+";
                    Regex regexForWords = new Regex(patternForWords);

                    MatchCollection matchesWords = regexForWords.Matches(sentence);
                    foreach (Match word in matchesWords)
                    {
                        if (word.Value.Count(letter => letter == symbol) >= count)
                        {
                            validWords.Add(word.Value);
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(", ", validWords));
        }

        private static void HappinessIndex()
        {
            string input = Console.ReadLine();
            int happyCount = 0;
            int sadCount = 0;

            string pattern = "(?<happy>:\\)|:D|;\\)|:\\*|:]|;]|:}|;}|\\(:|\\*:|c:|\\[:|\\[;)|(?<sad>:\\(|D:|;\\(|:\\[|;\\[|:{|;{|\\):|:c|]:|];)";
            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(input);
            foreach (Match match in matches)
            {
                if (match.Groups["happy"].Success)
                {
                    happyCount++;
                }

                if (match.Groups["sad"].Success)
                {
                    sadCount++;
                }
            }

            double happinessIndex = (double)happyCount / sadCount;
            string finalEmoticon = string.Empty;

            if (happinessIndex >= 2)
            {
                finalEmoticon = ":D";
            }
            else if (happinessIndex > 1)
            {
                finalEmoticon = ":)";
            }
            else if (happinessIndex == 1)
            {
                finalEmoticon = ":|";
            }
            else if (happinessIndex < 1)
            {
                finalEmoticon = ":(";
            }

            Console.WriteLine($"Happiness index: {happinessIndex:F2} {finalEmoticon}");
            Console.WriteLine($"[Happy count: {happyCount}, Sad count: {sadCount}]");
        }

        private static void Commits()
        {
            Dictionary<string, Dictionary<string, List<Commit>>> usersAndRepos = new Dictionary<string, Dictionary<string, List<Commit>>>();

            while (true)
            {
                string input = Console.ReadLine();

                // check !!!
                if (input.ToLower() == "git push")
                    break;

                string pattern = "https:\\/\\/github\\.com\\/(?<user>[A-Za-z0-9-]+)\\/(?<repo>[A-Z-a-z-_]+)\\/commit\\/(?<hash>[0-9a-f]{40}),(?<message>[^\\r\\n|\\r|\\n]+),(?<additions>[0-9]+),(?<deletions>[0-9]+)";
                Regex regex = new Regex(pattern);

                if (regex.IsMatch(input))
                {
                    Match match = regex.Match(input);
                    string user = match.Groups["user"].Value;
                    string repo = match.Groups["repo"].Value;
                    string hash = match.Groups["hash"].Value;
                    string message = match.Groups["message"].Value;
                    double additions = double.Parse(match.Groups["additions"].Value);
                    double deletions = double.Parse(match.Groups["deletions"].Value);

                    if (!usersAndRepos.ContainsKey(user))
                    {
                        usersAndRepos[user] = new Dictionary<string, List<Commit>>();
                    }

                    if (!usersAndRepos[user].ContainsKey(repo))
                    {
                        usersAndRepos[user][repo] = new List<Commit>();
                    }

                    Commit commit = new Commit
                    {
                        Message = message,
                        Hash = hash,
                        Additions = additions,
                        Deletions = deletions
                    };

                    usersAndRepos[user][repo].Add(commit);
                }
            }

            foreach (KeyValuePair<string, Dictionary<string, List<Commit>>> user in usersAndRepos.OrderBy(u => u.Key))
            {
                Console.WriteLine($"{user.Key}:");

                foreach (KeyValuePair<string, List<Commit>> repo in user.Value.OrderBy(r => r.Key))
                {
                    Console.WriteLine($"  {repo.Key}:");

                    foreach (Commit commit in repo.Value)
                    {
                        Console.WriteLine($"    commit {commit.Hash}: {commit.Message} ({commit.Additions} additions, {commit.Deletions} deletions)");
                    }

                    Console.WriteLine($"    Total: {repo.Value.Sum(commit => commit.Additions)} additions, {repo.Value.Sum(commit => commit.Deletions)} deletions");
                }
            }

            // Only the zero tests passes with this type of printing
            //
            //usersAndRepos
            //    .OrderBy(u => u.Key)
            //    .ToList()
            //    .ForEach(user => user.Value.OrderBy(r => r.Key).ToList()
            //    .ForEach(repo =>
            //        Console.WriteLine($"{user.Key}:\n  " +
            //                          $"{repo.Key}:\n    " +
            //                          $"commit {string.Join("\n    commit ", repo.Value)}\n    " +
            //                          $"Total: {repo.Value.Sum(c => c.Additions)} additions, {repo.Value.Sum(c => c.Deletions)} deletions")));
        }
    }

    class Commit
    {
        public string Hash { get; set; }
        public string Message { get; set; }
        public double Additions { get; set; }
        public double Deletions { get; set; }

        public override string ToString()
        {
            return string.Format($"{this.Hash}: {this.Message} ({this.Additions} additions, {this.Deletions} deletions)");
        }
    }
}
