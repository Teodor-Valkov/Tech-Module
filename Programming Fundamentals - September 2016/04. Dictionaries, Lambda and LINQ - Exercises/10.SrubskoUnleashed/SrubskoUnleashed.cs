namespace _10.SrubskoUnleashed
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class SrubskoUnleashed
    {
        static void Main()
        {
            Dictionary<string, Dictionary<string, double>> venueSingerMoneyDictionary = new Dictionary<string, Dictionary<string, double>>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input != null && input.ToLower() == "end")
                    break;

                string currentVenue = string.Empty;
                string currentSinger = string.Empty;
                double ticketPrice = 0;
                double ticketCount = 0;

                if (input != null)
                {
                    int indexOfSingerNameEnd = input.IndexOf("@", StringComparison.Ordinal) - 1;

                    if (input[indexOfSingerNameEnd] == ' ')
                    {
                        currentSinger = input.Substring(0, indexOfSingerNameEnd);
                    }
                    else
                    {
                        continue;
                    }
                }

                if (input != null)
                {
                    int indexOfVenueStart = input.IndexOf("@", StringComparison.Ordinal) + 1;
                    int indexOfFirstDigit = GetFirstDigitInInput(input);

                    if (input[indexOfFirstDigit - 1] == ' ')
                    {
                        currentVenue = input.Substring(indexOfVenueStart, indexOfFirstDigit - indexOfVenueStart - 1);
                    }
                    else
                    {
                        continue;
                    }
                }

                if (input != null)
                {
                    string[] priceAndMoney = input.Split(' ');
                    ticketPrice = double.Parse(priceAndMoney[priceAndMoney.Length - 2]);
                    ticketCount = double.Parse(priceAndMoney[priceAndMoney.Length - 1]);
                }

                if (!venueSingerMoneyDictionary.ContainsKey(currentVenue))
                {
                    venueSingerMoneyDictionary.Add(currentVenue, new Dictionary<string, double>());
                    venueSingerMoneyDictionary[currentVenue].Add(currentSinger, ticketPrice * ticketCount);
                }
                else
                {
                    if (!venueSingerMoneyDictionary[currentVenue].ContainsKey(currentSinger))
                    {
                        venueSingerMoneyDictionary[currentVenue].Add(currentSinger, ticketPrice*ticketCount);
                    }
                    else
                    {
                        venueSingerMoneyDictionary[currentVenue][currentSinger] += ticketPrice * ticketCount;
                    }
                }
            }

            foreach (KeyValuePair<string, Dictionary<string, double>> pair in venueSingerMoneyDictionary)
            {
                Console.WriteLine(pair.Key);

                foreach (KeyValuePair<string, double> singerMoney in venueSingerMoneyDictionary[pair.Key].OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {singerMoney.Key} -> {singerMoney.Value}");
                }
            }
        }


        private static int GetFirstDigitInInput(string input)
        {
            int index = 0;

            foreach (char symbol in input)
            {
                if (char.IsDigit(symbol))
                {
                    index = input.IndexOf(symbol);
                    return index;
                }
            }

            return index;
        }
    }
}
