namespace _12.MaxSequenceOfEqualElements
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class MaxSequenceOfEqualElements
    {
        static void Main()
        {
            List<int> nums = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            int longestSequenceCount = 0;
            int numberOfTheSequence = 0;

            // There is valid solution with two 'foreach' loops instead of one 'while' loop
            for (int start = 0; start < nums.Count; start++)
            {
                int counter = 1;

                while (start + counter < nums.Count && nums[start] == nums[start + counter])
                {
                    counter++;
                }

                if (counter > longestSequenceCount)
                {
                    longestSequenceCount = counter;
                    numberOfTheSequence = nums[start];
                }

                start = start + counter - 1;
            }

            for (int i = 0; i < longestSequenceCount; i++)
            {
                if (i == longestSequenceCount - 1)
                {
                    Console.WriteLine(numberOfTheSequence);
                }
                else
                {
                    Console.Write(numberOfTheSequence + " ");
                }
            }
        }
    }
}
