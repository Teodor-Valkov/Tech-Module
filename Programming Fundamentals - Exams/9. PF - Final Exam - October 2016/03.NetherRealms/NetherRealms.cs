namespace _03.NetherRealms
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class NetherRealms
    {
        static void Main()
        {
            string input = Console.ReadLine();
            Dictionary<string, Dictionary<long, double>> nameHealthDamage = new Dictionary<string, Dictionary<long, double>>();

            if (input != null)
            {
                string[] inputArgs = input.Split(new [] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                
                foreach (string arg in inputArgs)
                {
                    long health = DemonHealth(arg);

                    bool negative = false;
                    double baseDamage = 0;
                    string numberString = string.Empty;

                    for (int i = 0; i < arg.Length; i++)
                    {
                        if (char.IsDigit(arg[i]))
                        {
                            if (i > 0)
                            {
                                if (arg[i - 1] == '-')
                                {
                                    negative = true;
                                }
                            }

                            for (int j = i; j < arg.Length; j++)
                            {
                                if (char.IsDigit(arg[j]) || arg[j] == '.')
                                {
                                    numberString += arg[j];
                                    if (j == arg.Length - 1)
                                    {
                                        i = arg.Length - 1;
                                    }
                                }
                                else
                                {
                                    i = j - 1;
                                    break;
                                }
                            }

                            double currentNumber = double.Parse(numberString);

                            if (negative)
                            {
                                currentNumber *= -1;
                            }

                            negative = false;
                            baseDamage += currentNumber;
                            numberString = string.Empty;
                        }
                    }

                    foreach (char symbol in arg)
                    {
                        if (symbol == '*')
                        {
                            baseDamage *= 2;
                        }
                        if (symbol == '/')
                        {
                            baseDamage /= 2;
                        }
                    }


                    nameHealthDamage.Add(arg, new Dictionary<long, double>());
                    nameHealthDamage[arg].Add(health, baseDamage);

                }

                foreach (KeyValuePair<string, Dictionary<long, double>> dragon in nameHealthDamage.OrderBy(x => x.Key))
                {
                    Console.Write($"{dragon.Key} - ");
                    foreach (KeyValuePair<long, double> dragonStats in dragon.Value)
                    {
                        Console.WriteLine($"{dragonStats.Key} health, {dragonStats.Value:F2} damage");
                    }
                }
            }
        }

        private static long DemonHealth(string arg)
        {
            long health = 0;
            string forbiddenSymbols = "0123456789+-*/.";

            foreach (char symbol in arg)
            {
                if (!forbiddenSymbols.Contains(symbol))
                {
                    health += symbol;
                }
            }

            return health;
        }
    }
}
