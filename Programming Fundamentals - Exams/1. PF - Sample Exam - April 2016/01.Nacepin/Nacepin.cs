namespace _01.Nacepin
{
    using System;

    class Nacepin
    {
        static void Main()
        {
            decimal usaPrice = decimal.Parse(Console.ReadLine()) / 0.58m;
            decimal usaWeight = decimal.Parse(Console.ReadLine());
            
            decimal englandPrice = decimal.Parse(Console.ReadLine()) / 0.41m;
            decimal englandWeight = decimal.Parse(Console.ReadLine());

            decimal chinaPrice = decimal.Parse(Console.ReadLine()) * 0.27m;
            decimal chinaWeight = decimal.Parse(Console.ReadLine());

            decimal usaProductPerKg = usaPrice / usaWeight;
            decimal englandProductPerKg = englandPrice / englandWeight;
            decimal chinaProductPerKg = chinaPrice / chinaWeight;

            string usa = "US";
            string england = "UK";
            string china = "Chinese";

            decimal lowestPrice = Math.Min(usaProductPerKg, (Math.Min(englandProductPerKg, chinaProductPerKg)));
            decimal highestPrice = Math.Max(usaProductPerKg, (Math.Max(englandProductPerKg, chinaProductPerKg)));
            decimal diff = highestPrice - lowestPrice;

            if (lowestPrice == usaProductPerKg)
            {
                Console.WriteLine($"{usa} store. {lowestPrice:F2} lv/kg");
                Console.WriteLine($"Difference {diff:F2} lv/kg");
            }
            else if (lowestPrice == englandProductPerKg)
            {
                Console.WriteLine($"{england} store. {lowestPrice:F2} lv/kg");
                Console.WriteLine($"Difference {diff:F2} lv/kg");
            }
            else if (lowestPrice == chinaProductPerKg)
            {
                Console.WriteLine($"{china} store. {lowestPrice:F2} lv/kg");
                Console.WriteLine($"Difference {diff:F2} lv/kg");
            }
        }
    }
}
