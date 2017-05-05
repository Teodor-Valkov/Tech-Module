namespace _03.FootballLeagueNew
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class FootballLeagueNew
    {
        static void Main()
        {
            string key = Console.ReadLine();
            string command = Console.ReadLine();

            SortedDictionary<string, long> classification = new SortedDictionary<string, long>();
            SortedDictionary<string, long> scorers = new SortedDictionary<string, long>();

            while (command != null && command.ToUpper() != "FINAL")
            {
                //Finding teams names;
                string homeTeam = string.Empty;
                string awayTeam = string.Empty;
                string[] teamsNamesAndResult = command.Split(' ');
                string decryptedHomeTeamName = teamsNamesAndResult[0];
                string decryptedAwayTeamName = teamsNamesAndResult[1];

                int startIndex = 0;
                int endIndex = 0;

                startIndex = decryptedHomeTeamName.IndexOf(key);
                endIndex = decryptedHomeTeamName.LastIndexOf(key);
                string reversedHomeTeam = decryptedHomeTeamName.Substring(startIndex + key.Length, endIndex - startIndex - key.Length);
                char[] homeTeamChars = reversedHomeTeam.ToUpper().ToCharArray();
                Array.Reverse(homeTeamChars);
                homeTeam = new string(homeTeamChars);

                startIndex = decryptedAwayTeamName.IndexOf(key);
                endIndex = decryptedAwayTeamName.LastIndexOf(key);
                string reversedAwayTeam = decryptedAwayTeamName.Substring(startIndex + key.Length, endIndex - startIndex - key.Length);
                char[] awayTeamChars = reversedAwayTeam.ToUpper().ToCharArray();
                Array.Reverse(awayTeamChars);
                awayTeam = new string(awayTeamChars);

                //Finding goals and points'
                long[] goals = teamsNamesAndResult[2].Split(':').Select(long.Parse).ToArray();
                long homeTeamGoals = goals[0];
                long awayTeamGoals = goals[1];
                long homeTeamPoints = 1;
                long awayTeamPoints = 1;
                
                if (homeTeamGoals > awayTeamGoals)
                {
                    homeTeamPoints = 3;
                    awayTeamPoints = 0;
                }
                else if (homeTeamGoals < awayTeamGoals)
                {
                    homeTeamPoints = 0;
                    awayTeamPoints = 3;
                }

                //Updating the standings
                if (classification.ContainsKey(homeTeam))
                    classification[homeTeam] += homeTeamPoints;
                else
                    classification[homeTeam] = homeTeamPoints;

                if (classification.ContainsKey(awayTeam))
                    classification[awayTeam] += awayTeamPoints;
                else
                    classification[awayTeam] = awayTeamPoints;

                //Updating the scorers
                if (scorers.ContainsKey(homeTeam))
                    scorers[homeTeam] += homeTeamGoals;
                else
                    scorers[homeTeam] = homeTeamGoals;

                if (scorers.ContainsKey(awayTeam))
                    scorers[awayTeam] += awayTeamGoals;
                else
                    scorers[awayTeam] = awayTeamGoals;

                command = Console.ReadLine();
            }

            //Printing the result
            int counter = 1;
            Console.WriteLine("League standings:");
            foreach (KeyValuePair<string, long> team in classification.OrderByDescending(team => team.Value))
            {
                Console.WriteLine("{0}. {1} {2}", counter, team.Key, team.Value);
                counter++;
            }

            Console.WriteLine("Top 3 scored goals:");
            foreach (KeyValuePair<string, long> country in scorers.OrderByDescending(country => country.Value).Take(3))
            {
                Console.WriteLine("- {0} -> {1}", country.Key, country.Value);
            }
        }
    }
}
