namespace _01.SoftuniCoffeeOrders
{
    using System;
    using System.Globalization;

    class SoftuniCoffeeOrders
    {
        static void Main()
        {
            long orders = long.Parse(Console.ReadLine());
            decimal totalPrice = 0;

            for (int i = 0; i < orders; i++)
            {
                decimal priceForCapsule = decimal.Parse(Console.ReadLine());
                DateTime currentDate = DateTime.ParseExact(Console.ReadLine(), "d/M/yyyy", CultureInfo.InvariantCulture);
                long capsulesCount = long.Parse(Console.ReadLine());

                int daysInMonth = DateTime.DaysInMonth(currentDate.Year, currentDate.Month);
                decimal coffeePrice = priceForCapsule * daysInMonth * capsulesCount;

                totalPrice += coffeePrice;
                Console.WriteLine($"The price for the coffee is: ${coffeePrice:F2}");
            }

            Console.WriteLine($"Total: ${totalPrice:F2}");
        }
    }
}
