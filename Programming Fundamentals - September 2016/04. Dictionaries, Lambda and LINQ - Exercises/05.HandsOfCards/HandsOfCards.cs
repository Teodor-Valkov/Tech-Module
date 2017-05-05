namespace _05.HandsOfCards
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class HandsOfCards
    {
        static void Main()
        {
            Dictionary<string, List<string>> nameAndCards = new Dictionary<string, List<string>>();
            
            while (true)
            {
                string input = Console.ReadLine();

                if (input != null && input.ToLower() == "joker")
                    break;

                if (input != null)
                {
                    string[] inputArgs = input.Split(new [] {':'}, StringSplitOptions.RemoveEmptyEntries);

                    //string name = input.Substring(0, input.IndexOf(":"));
                    //string name = new string(input.Take(input.IndexOf(":")).ToArray());

                    string name = inputArgs[0];
                    string cards = inputArgs[1];
                    string[] cardsArray = cards.Split(new [] {',', ' '}, StringSplitOptions.RemoveEmptyEntries);

                    if (!nameAndCards.ContainsKey(name))
                    {
                        nameAndCards.Add(name, new List<string>());
                    }

                    nameAndCards[name].AddRange(cardsArray);
                }
            }

            PrintingResultOnTheConsole(nameAndCards);
        }

        private static void PrintingResultOnTheConsole(Dictionary<string, List<string>> nameAndCards)
        {
            foreach (KeyValuePair<string, List<string>> currentNameAndCards in nameAndCards)
            {
                long cardsScore = 0;
                string name = currentNameAndCards.Key;
                List<string> cards = currentNameAndCards.Value.Distinct().ToList();

                foreach (string card in cards)
                {
                    string rank = card.Substring(0, card.Length - 1);
                    string suite = card.Last().ToString();

                    int rankPower = GetRankPower(rank);
                    int suitePower = GetSuitePower(suite);
                    cardsScore += rankPower*suitePower;
                }

                Console.WriteLine($"{name}: {cardsScore}");
            }
        }

        private static int GetRankPower(string rank)
        {
            switch (rank)
            {
                case "2": return 2; 
                case "3": return 3; 
                case "4": return 4; 
                case "5": return 5; 
                case "6": return 6; 
                case "7": return 7; 
                case "8": return 8; 
                case "9": return 9;
                case "10": return 10;
                case "J": return 11;
                case "Q": return 12;
                case "K": return 13;
                case "A": return 14; 
                default: return 1;
            }
        }

        private static int GetSuitePower(string suite)
        {
            switch (suite)
            {
                case "C": return 1;
                case "D": return 2;
                case "H": return 3;
                case "S": return 4;
                default : return 1;
            }
        }
    }
}
