namespace _02.ReverseArrayOfIntegers
{
    using System;
    using System.Collections.Generic;

    class ReverseArrayOfIntegers
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];

            for (int i = 0; i < n; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            // First Solution

            for (int i = n - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    Console.WriteLine("{0} ", numbers[i]);
                }
                else
                {   
                    Console.Write("{0} ", numbers[i]);                
                }
            }

            // Second Solution 

            List<int> reversedNumbers = new List<int>(n);
            reversedNumbers.AddRange(numbers);
            reversedNumbers.Reverse();

            Console.WriteLine(string.Join(" ", reversedNumbers));
        }
    }
}
