﻿namespace _02.SignOfIntegerNumber
{
    using System;

    class SignOfIntegerNumber
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            PrintSign(n);
        }

        private static void PrintSign(int n)
        {
            if (n > 0)
                Console.WriteLine($"The number {n} is positive.");
            else if (n < 0)
                Console.WriteLine($"The number {n} is negative.");
            else
                Console.WriteLine($"The number {n} is zero.");
        }
    }
}