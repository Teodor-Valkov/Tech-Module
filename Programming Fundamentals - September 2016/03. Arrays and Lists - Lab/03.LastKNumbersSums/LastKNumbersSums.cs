namespace _03.LastKNumbersSums
{
    using System;

    internal class LastKNumbersSums
    {
        private static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            long[] numbers = new long[n];
            numbers[0] = 1;

            for (int i = 1; i < n; i++)
            {
                long sum = 0;

                for (int previous = i - k; previous <= i - 1; previous++)
                {
                    if (previous >= 0)
                    {
                        sum += numbers[previous];
                    }

                    numbers[i] = sum;
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}