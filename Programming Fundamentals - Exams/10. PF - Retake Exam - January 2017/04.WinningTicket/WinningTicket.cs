namespace _04.WinningTicket
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class WinningTicket
    {
        static void Main()
        {
            List<string> tickets = Console.ReadLine().Split(new [] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            
            foreach (string ticket in tickets)
            {
                if (ticket.Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                    continue;
                }

                string firstHalf = ticket.Substring(0, 10);
                string secondHalf = ticket.Substring(10);

                int counterFirst = 0;
                int maxFirst = 0;
                char winningFirst = ' ';
                char symbolFirst = ' ';

                for (int i = 0; i < firstHalf.Length; i++)
                {
                    symbolFirst = firstHalf[i];

                    if (symbolFirst == '@' || symbolFirst == '#' || symbolFirst == '$' || symbolFirst == '^')
                    {
                        for (int j = i; j < firstHalf.Length; j++)
                        {
                            if (symbolFirst == firstHalf[j])
                            {
                                counterFirst++;
                                i = j;
                            }
                            else
                            {
                                if (counterFirst > maxFirst)
                                {
                                    maxFirst = counterFirst;
                                    winningFirst = firstHalf[j - 1];
                                }
                                counterFirst = 0;
                                break;
                            }

                            if (j == firstHalf.Length - 1)
                            {
                                if (counterFirst > maxFirst)
                                {
                                    maxFirst = counterFirst;
                                    winningFirst = firstHalf[j];
                                }
                            }
                        }
                    }
                }

                int counterSecond = 0;
                int maxSecond = 0;
                char winningSecond = ' ';
                char symbolSecond = ' ';

                for (int i = 0; i < secondHalf.Length; i++)
                {
                    symbolSecond = secondHalf[i];

                    if (symbolSecond == '@' || symbolSecond == '#' || symbolSecond == '$' || symbolSecond == '^')
                    {
                        for (int j = i; j < secondHalf.Length; j++)
                        {
                            if (symbolSecond == secondHalf[j])
                            {
                                counterSecond++;
                                i = j;
                            }
                            else
                            {
                                if (counterSecond > maxSecond)
                                {
                                    maxSecond = counterSecond;
                                    winningSecond = secondHalf[j - 1];
                                }
                                counterSecond = 0;
                                break;
                            }

                            if (j == secondHalf.Length - 1)
                            {
                                if (counterSecond > maxSecond)
                                {
                                    maxSecond = counterSecond;
                                    winningSecond = secondHalf[j - 1];
                                }
                            }
                        }
                    }
                }

                if (maxFirst == 10 && maxSecond == 10 && winningFirst == winningSecond)
                {
                    Console.WriteLine($"ticket \"{ticket}\" - {maxFirst}{winningFirst} Jackpot!");
                    continue;
                }

                int smallerWinningTicketSymbolsCount = maxFirst > maxSecond ? maxSecond : maxFirst;
                if (winningFirst == winningSecond && maxFirst >= 6 && maxSecond >= 6)
                {
                    Console.WriteLine($"ticket \"{ticket}\" - {smallerWinningTicketSymbolsCount}{winningFirst}");
                }
                else
                {
                    Console.WriteLine($"ticket \"{ticket}\" - no match");
                }
            }
        }
    }
}
