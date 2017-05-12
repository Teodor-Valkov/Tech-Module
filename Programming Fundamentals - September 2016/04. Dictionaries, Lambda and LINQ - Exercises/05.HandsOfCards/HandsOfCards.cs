namespace _05.HandsOfCards
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class HandsOfCards
    {
        static void Main()
        {
                Dictionary<string, HashSet<string>> nameAndCards = new Dictionary<string, HashSet<string>>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input.ToLower() == "joker")
                    break;
                
                string[] inputArgs = input.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                string name = inputArgs[0];
                string cards = inputArgs[1];

                string[] cardsArray = cards.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (!nameAndCards.ContainsKey(name))
                {
                    nameAndCards.Add(name, new HashSet<string>());
                }

                foreach (string card in cardsArray)
                {
                    nameAndCards[name].Add(card);
                }
            }

            PrintingResult(nameAndCards);
        }

        private static void PrintingResult(Dictionary<string, HashSet<string>> nameAndCards)
        {
            foreach (KeyValuePair<string, HashSet<string>> pair in nameAndCards)
            {
                long cardsScore = 0;

                string name = pair.Key;
                HashSet<string> cards = pair.Value;

                foreach (string card in cards)
                {
                    string rank = card.Length == 2 ? card.First().ToString() : "10";
                    string suite = card.Last().ToString();

                    int rankPower = GetRankPower(rank);
                    int suitePower = GetSuitePower(suite);

                    cardsScore += rankPower * suitePower;
                }

                Console.WriteLine($"{name}: {cardsScore}");
            }
        }

        private static int GetRankPower(string rank)
        {
            int rankPower = 0;

            switch (rank)
            {
                case "2": rankPower = 2; break; 
                case "3": rankPower = 3; break;
                case "4": rankPower = 4; break;
                case "5": rankPower = 5; break;
                case "6": rankPower = 6; break;
                case "7": rankPower = 7; break;
                case "8": rankPower = 8; break;
                case "9": rankPower = 9; break;
                case "10":rankPower = 10; break;
                case "J": rankPower = 11; break;
                case "Q": rankPower = 12; break;
                case "K": rankPower = 13; break;
                case "A": rankPower = 14; break;
            }

            return rankPower;
        }

        private static int GetSuitePower(string suite)
        {
            int suitePower = 0;

            switch (suite)
            {
                case "C": suitePower = 1; break;
                case "D": suitePower = 2; break;
                case "H": suitePower = 3; break;
                case "S": suitePower = 4; break;
            }

            return suitePower;
        }
    }
}
