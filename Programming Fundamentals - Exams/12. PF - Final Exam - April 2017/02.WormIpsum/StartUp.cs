namespace _02.WormIpsum
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    class StartUp
    {
        static void Main()
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input.ToLower() == "worm ipsum")
                    break;

                string patternForSentence = @"^([A-Z][^\.|?|!]+)[\.|!|?]$";
                Regex regex = new Regex(patternForSentence);

                Match match = regex.Match(input);
                if (match.Success)
                {
                    string sentence = match.Value;

                    string patternForWords = @"[A-Za-z]+";
                    Regex regexForWords = new Regex(patternForWords);

                    MatchCollection matchesWords = regexForWords.Matches(sentence);
                    foreach (Match word in matchesWords)
                    {
                        Dictionary<char, int> symbolsAndCount = new Dictionary<char, int>();

                        foreach (char symbol in word.Value)
                        {
                            if (word.Value.Count(letter => letter == symbol) > 1)
                            {
                                if (!symbolsAndCount.ContainsKey(symbol))
                                {
                                    symbolsAndCount[symbol] = 0;
                                }

                                symbolsAndCount[symbol]++;
                            }
                        }

                        if (symbolsAndCount.Count > 0)
                        {
                            char symbolWithMostOccurrences = 
                                symbolsAndCount
                                 .OrderByDescending(pair => pair.Value)
                                 .ToDictionary(pair => pair.Key, pair => pair.Value)
                                 .Keys
                                 .First();

                            sentence = sentence.Replace(word.Value, new string(symbolWithMostOccurrences, word.Value.Length));
                        }
                    }

                    Console.WriteLine(sentence);
                }
            }
        }
    }
}
