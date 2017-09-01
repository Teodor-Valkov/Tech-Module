namespace _04.TrippleSum
{
    using System;
    using System.Linq;

    class TrippleSum
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            bool answer = false;

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    int sum = numbers[i] + numbers[j];

                    if (numbers.Contains(sum))
                    {
                        answer = true;
                        Console.WriteLine($"{numbers[i]} + {numbers[j]} == {sum}");
                    }
                }
            }

            if (!answer)
            {
                Console.WriteLine("No");
            }
        }
    }
}
