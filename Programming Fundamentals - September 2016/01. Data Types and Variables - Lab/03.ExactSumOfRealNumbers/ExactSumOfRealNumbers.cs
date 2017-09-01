namespace _03.ExactSumOfRealNumbers
{
    using System;

    class ExactSumOfRealNumbers
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            decimal sum = 0m;

            for (int i = 0; i < n; i++)
            {
                sum += decimal.Parse(Console.ReadLine());
            }

            Console.WriteLine(sum);
        }
    }
}
