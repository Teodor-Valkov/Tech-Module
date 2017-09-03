namespace _09.TeamworkProjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Team
    {
        public Team()
        {
            TeamUsers = new List<string>();
        }

        public string TeamName { get; set; }
        public string TeamCreator { get; set; }
        public List<string> TeamUsers { get; set; }
    }

    internal class TeamworkProjects
    {
        private static void Main()
        {
            int teamsNumber = int.Parse(Console.ReadLine());

            Dictionary<string, Team> creatorTeamDictionary = new Dictionary<string, Team>();

            for (int i = 0; i < teamsNumber; i++)
            {
                string[] input = Console.ReadLine().Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                string creator = input[0];
                string teamName = input[1];

                if (creatorTeamDictionary.Any(x => x.Value.TeamName == teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                }
                else if (creatorTeamDictionary.Any(x => x.Value.TeamCreator == creator))
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                }
                else
                {
                    creatorTeamDictionary.Add(creator, new Team());
                    creatorTeamDictionary[creator].TeamName = teamName;
                    creatorTeamDictionary[creator].TeamCreator = creator;

                    Console.WriteLine($"Team {teamName} has been created by {creator}!");
                }
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input != null && input.ToLower() == "end of assignment")
                    break;

                if (input != null)
                {
                    string[] inputArgs = input.Split(new[] { '-', '>' }, StringSplitOptions.RemoveEmptyEntries);
                    string userToJoin = inputArgs[0];
                    string teamToJoin = inputArgs[1];

                    if (creatorTeamDictionary.All(x => x.Value.TeamName != teamToJoin))
                    {
                        Console.WriteLine($"Team {teamToJoin} does not exist!");
                        continue;
                    }

                    if (creatorTeamDictionary.Any(x => x.Value.TeamUsers.Contains(userToJoin)) ||
                        creatorTeamDictionary.Any(x => x.Value.TeamCreator == userToJoin))
                    {
                        Console.WriteLine($"Member {userToJoin} cannot join team {teamToJoin}!");
                        continue;
                    }

                    string creator = string.Empty;

                    foreach (KeyValuePair<string, Team> pair in creatorTeamDictionary)
                    {
                        if (pair.Value.TeamName == teamToJoin)
                        {
                            creator = pair.Key;
                        }
                    }

                    creatorTeamDictionary[creator].TeamUsers.Add(userToJoin);
                }
            }

            creatorTeamDictionary = creatorTeamDictionary
                .OrderByDescending(x => x.Value.TeamUsers.Count)
                .ThenBy(x => x.Value.TeamName)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (Team currentTeam in creatorTeamDictionary.Values)
            {
                if (currentTeam.TeamUsers.Count == 0)
                    continue;

                Console.WriteLine(currentTeam.TeamName);
                Console.WriteLine($"- {currentTeam.TeamCreator}");
                foreach (string currentUser in currentTeam.TeamUsers.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {currentUser}");
                }
            }

            Console.WriteLine("Teams to disband:");
            foreach (Team currentTeam in creatorTeamDictionary.Values.OrderBy(x => x.TeamName))
            {
                if (currentTeam.TeamUsers.Count == 0)
                {
                    Console.WriteLine(currentTeam.TeamName);
                }
            }
        }
    }
}