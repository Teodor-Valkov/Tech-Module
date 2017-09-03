namespace _05.HandsOfCards2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class HandsOfCards2
    {
        private static void Main()
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

            PrintResults(nameAndCards);
        }

        private static void PrintResults(Dictionary<string, HashSet<string>> nameAndCards)
        {
            List<List<long>> playersScore = new List<List<long>>();

            foreach (HashSet<string> cards in nameAndCards.Values)
            {
                List<long> currentPlayerScore = new List<long>();
                int currentCardScore = 0;

                foreach (string currentCard in cards)
                {
                    if (currentCard.Length == 3)
                    {
                        currentCardScore += 10;
                    }

                    foreach (char cardAndType in currentCard)
                    {
                        switch (cardAndType)
                        {
                            case '2': currentCardScore += 2; break;
                            case '3': currentCardScore += 3; break;
                            case '4': currentCardScore += 4; break;
                            case '5': currentCardScore += 5; break;
                            case '6': currentCardScore += 6; break;
                            case '7': currentCardScore += 7; break;
                            case '8': currentCardScore += 8; break;
                            case '9': currentCardScore += 9; break;
                            case 'J': currentCardScore += 11; break;
                            case 'Q': currentCardScore += 12; break;
                            case 'K': currentCardScore += 13; break;
                            case 'A': currentCardScore += 14; break;
                            case 'C': currentCardScore *= 1; break;
                            case 'D': currentCardScore *= 2; break;
                            case 'H': currentCardScore *= 3; break;
                            case 'S': currentCardScore *= 4; break;
                        }
                    }

                    currentPlayerScore.Add(currentCardScore);
                    currentCardScore = 0;
                }

                playersScore.Add(currentPlayerScore);
            }

            int counter = 0;
            foreach (string name in nameAndCards.Keys)
            {
                Console.WriteLine($"{name}: {playersScore[counter].Sum()}");
                counter++;
            }
        }
    }
}