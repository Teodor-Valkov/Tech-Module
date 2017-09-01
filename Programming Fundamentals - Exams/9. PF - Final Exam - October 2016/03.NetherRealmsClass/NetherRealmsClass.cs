namespace _03.NetherRealmsClass
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class Dragon
    {
        public long Health { get; set; }
        public double Damage { get; set; }
        public string Name { get; set; }
    }

    class NetherRealmsClass
    {
        static void Main()
        {
            List<Dragon> dragons = new List<Dragon>();
            string input = Console.ReadLine();

            if (input != null)
            {
                string[] inputArgs = input.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string arg in inputArgs)
                {
                    Dragon currentDragon = new Dragon();
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

                    currentDragon.Name = arg;
                    currentDragon.Health = health;
                    currentDragon.Damage = baseDamage;

                    dragons.Add(currentDragon);
                }
            }

            foreach (Dragon currentDragon in dragons.OrderBy(x => x.Name))
            {
                Console.WriteLine($"{currentDragon.Name} - {currentDragon.Health} health, {currentDragon.Damage:F2} damage");
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
