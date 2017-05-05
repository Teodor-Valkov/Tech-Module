namespace _01.ConvertFromBaseToBase
{
    using System;
    using System.Linq;
    using System.Numerics;

    class ConvertFromBaseToBase
    {
        static void Main()
        {
            BigInteger[] baseNumberAndNumber = Console.ReadLine().Split(' ').Select(BigInteger.Parse).ToArray();

            BigInteger baseNumber = baseNumberAndNumber[0];
            BigInteger number = baseNumberAndNumber[1];

            string newNumber = string.Empty;

            while (number > 0)
            {
                newNumber = number % baseNumber + newNumber;
                number = number / baseNumber;
            }

            Console.WriteLine(newNumber);
        }
    }
}
