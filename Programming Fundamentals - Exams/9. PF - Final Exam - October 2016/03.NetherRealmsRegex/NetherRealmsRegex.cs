namespace _03.NetherRealmsRegex
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    class NetherRealmsRegex
    {
        static void Main()
        {
            string[] demons = Console.ReadLine().Split(new [] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).OrderBy(x => x).ToArray();

            foreach (string demon in demons)
            {
                double demonHealth = GetDemonHealth(demon);
                decimal demonDamage = GetDemonDamage(demon);
                Console.WriteLine($"{demon} - {demonHealth} health, {demonDamage:F2} damage");
            }
        }

        private static double GetDemonHealth(string demon)
        {
            // Regex for finding Health (all the symbols without numbers and math signs) 
            string demonHealthPattern = @"[^\d\.\+\-\*\/]";
            Regex regex = new Regex(demonHealthPattern);

            double health = 0;
            MatchCollection collection = regex.Matches(demon);
            foreach (Match match in collection)
            {
                foreach (char symbol in match.Value)
                {
                    health += symbol;
                }
            }

            return health;
        }

        private static decimal GetDemonDamage(string demon)
        {
            // Regex for finding Damage (numbers and float numbers);
            string demonDamagePattern = @"[\-\+]?\d+(\.\d+)?";
            Regex regex = new Regex(demonDamagePattern);

            decimal damage = 0;
            MatchCollection collection = regex.Matches(demon);
            foreach (Match match in collection)
            {
                damage += decimal.Parse(match.Value);
            }

            foreach (char symbol in demon.Where(x => x == '*' || x == '/'))
            {
                if (symbol == '*')
                {
                    damage *= 2;
                }
                else
                {
                    damage /= 2;
                }
            }

            return damage;
        }
    }
}
