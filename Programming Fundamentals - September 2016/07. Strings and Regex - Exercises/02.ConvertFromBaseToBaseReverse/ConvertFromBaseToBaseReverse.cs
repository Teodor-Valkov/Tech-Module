namespace _02.ConvertFromBaseToBaseReverse
{
    using System;
    using System.Linq;
    using System.Numerics;

    internal class ConvertFromBaseToBaseReverse
    {
        private static void Main()
        {
            BigInteger[] baseNumberAndNumber = Console.ReadLine().Split(' ').Select(BigInteger.Parse).ToArray();

            BigInteger baseNumber = baseNumberAndNumber[0];

            char[] number = baseNumberAndNumber[1].ToString().ToCharArray();

            BigInteger num = ToDecimalBase(number, baseNumber);

            Console.WriteLine(num);
        }

        private static BigInteger ToDecimalBase(char[] number, BigInteger baseNumber)
        {
            int len = number.Length;
            BigInteger power = 1;
            BigInteger num = 0;
            int i;

            for (i = len - 1; i >= 0; i--)
            {
                if (Val(number[i]) >= baseNumber)
                {
                    Console.WriteLine("Invalid Number");
                    return -1;
                }

                num += Val(number[i]) * power;
                power = power * baseNumber;
            }

            return num;
        }

        private static int Val(char ch)
        {
            if (ch >= '0' && ch <= '9')
            {
                return ch - '0';
            }

            return ch - 'A' + 10;
        }
    }
}