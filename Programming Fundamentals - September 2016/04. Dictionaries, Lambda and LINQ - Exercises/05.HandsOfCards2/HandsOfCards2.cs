namespace _05.HandsOfCards2
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class HandsOfCards2
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
                    string name = new string(input.Take(input.IndexOf(":", StringComparison.Ordinal)).ToArray());
                    string[] nameAndHand = input.Split(new [] { ':', ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    List<string> currentHand = new List<string>();

                    for (int i = 1; i < nameAndHand.Length; i++)
                    {
                        currentHand.Add(nameAndHand[i]);
                    }

                    foreach (string card in currentHand)
                    {
                        if (nameAndCards.ContainsKey(name))
                        {
                            if (nameAndCards[name].Contains(card))
                                continue;

                            nameAndCards[name].Add(card);
                        }
                        else
                        {
                            nameAndCards[name] = new List<string>
                            {
                                card
                            };
                        }
                    }
                }
            }

            List<List<long>> playersScore = new List<List<long>>();

            foreach (List<string> cards in nameAndCards.Values)
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
