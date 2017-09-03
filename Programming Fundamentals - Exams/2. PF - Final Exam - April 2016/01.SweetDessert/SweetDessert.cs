namespace _01.SweetDessert
{
    using System;

    internal class SweetDessert
    {
        private static void Main()
        {
            decimal moneyOwn = decimal.Parse(Console.ReadLine());
            decimal guests = int.Parse(Console.ReadLine());
            decimal bananaPrice = decimal.Parse(Console.ReadLine());
            decimal eggsPrice = decimal.Parse(Console.ReadLine());
            decimal berriesPrice = decimal.Parse(Console.ReadLine());

            decimal bananasPerSet = bananaPrice * 2;
            decimal eggsPerSet = eggsPrice * 4;
            decimal berriesPerSet = berriesPrice * 0.2m;

            decimal portionNeeded = Math.Ceiling(guests / 6);
            decimal productsPerSet = bananasPerSet + eggsPerSet + berriesPerSet;
            decimal moneyNeeded = productsPerSet * portionNeeded;

            Console.WriteLine(moneyNeeded <= moneyOwn
                ? $"Ivancho has enough money - it would cost {moneyNeeded:F2}lv."
                : $"Ivancho will have to withdraw money - he will need {moneyNeeded - moneyOwn:F2}lv more.");
        }
    }
}