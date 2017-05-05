namespace _09.TeamworkProjectsList
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class Team
    {
        public Team()
        {
            TeamUsers = new List<string>();
        }

        public string TeamName { get; set; }
        public string TeamCreator { get; set; }
        public List<string> TeamUsers { get; set; }
    }

    class TeamworkProjectList
    {
        static void Main()
        {
            int teamsNumber = int.Parse(Console.ReadLine());
            List<Team> teams = new List<Team>();

            CreatingTeams(teamsNumber, teams);
            UsersJoiningTeams(teams);
            PrintingTeams(teams);
        }

        private static void CreatingTeams(int teamsNumber, List<Team> teams)
        {
            for (int i = 0; i < teamsNumber; i++)
            {
                string[] input = Console.ReadLine().Split(new [] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                string creator = input[0];
                string teamName = input[1];

                if (teams.Any(x => x.TeamName == teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                }
                else if (teams.Any(x => x.TeamCreator == creator))
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                }
                else
                {
                    Team currentTeam = new Team()
                    {
                        TeamCreator = creator,
                        TeamName = teamName
                    };

                    teams.Add(currentTeam);

                    Console.WriteLine($"Team {teamName} has been created by {creator}!");
                }
            }
        }
        
        private static void UsersJoiningTeams(List<Team> teams)
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input != null && input.ToLower() == "end of assignment")
                    break;

                if (input != null)
                {
                    string[] inputArgs = input.Split(new [] {'-', '>'}, StringSplitOptions.RemoveEmptyEntries);
                    string userToJoin = inputArgs[0];
                    string teamToJoin = inputArgs[1];

                    if (teams.All(x => x.TeamName != teamToJoin))
                    {
                        Console.WriteLine($"Team {teamToJoin} does not exist!");
                        continue;
                    }

                    if (teams.Any(x => x.TeamUsers.Contains(userToJoin)) || teams.Any(x => x.TeamCreator == userToJoin))
                    {
                        Console.WriteLine($"Member {userToJoin} cannot join team {teamToJoin}!");
                        continue;
                    }

                    int teamToJoinIndex = teams.FindIndex(x => x.TeamName == teamToJoin);

                    teams[teamToJoinIndex].TeamUsers.Add(userToJoin);
                }
            }
        }

        private static void PrintingTeams(List<Team> teams)
        {
            teams = teams.OrderByDescending(x => x.TeamUsers.Count).ThenBy(x => x.TeamName).ToList();

            foreach (Team currentTeam in teams)
            {
                if (currentTeam.TeamUsers.Count == 0)
                    continue;

                Console.WriteLine($"{currentTeam.TeamName}");
                Console.WriteLine($"- {currentTeam.TeamCreator}");

                foreach (string currentUser in currentTeam.TeamUsers.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {currentUser}");
                }
            }

            Console.WriteLine("Teams to disband:");

            // If we don't want to use the 'if' clause in the 'foreach' loop
            //List<Team> disbanded = teams.FindAll(x => x.TeamUsers.Count == 0).ToList(); 
            //List<Team> disbanded = teams.Where(x => x.TeamUsers.Count == 0).ToList(); 

            foreach (Team currentTeam in teams.OrderBy(x => x.TeamName))
            {
                if (currentTeam.TeamUsers.Count == 0)
                {
                    Console.WriteLine($"{currentTeam.TeamName}");
                }
            }
        }
    }
}
