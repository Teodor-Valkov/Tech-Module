namespace _01.LargestCommonEnd
{
    using System;

    class LargestCommonEnd
    {
        static void Main()
        {
            string[] firstArray = Console.ReadLine().Split(' ');
            string[] secondArray = Console.ReadLine().Split(' ');

            int smallerArrayLength = Math.Min(firstArray.Length, secondArray.Length);
            int leftWordsCounter = 0;
            int rightWordsCounter = 0;
            
            leftWordsCounter = LeftEqualWords(firstArray, secondArray, leftWordsCounter, smallerArrayLength);
            rightWordsCounter = RightEqualWords(firstArray, secondArray, rightWordsCounter, smallerArrayLength);

            Console.WriteLine(Math.Max(leftWordsCounter, rightWordsCounter));
        }

        private static int LeftEqualWords(string[] firstArray, string[] secondArray, int leftWordsCounter, int smallerArrayLength)
        {
            for (int i = 0; i < smallerArrayLength; i++)
            {
                if (firstArray[i] == secondArray[i])
                {
                    leftWordsCounter++;
                }
            }

            return leftWordsCounter;
        }

        private static int RightEqualWords(string[] firstArray, string[] secondArray, int rightWordsCounter, int smallerArrayLength)
        {
            for (int i = 0; i < smallerArrayLength; i++)
            {
                if (firstArray[firstArray.Length - i - 1] == secondArray[secondArray.Length - i - 1])
                {
                    rightWordsCounter++;
                }
            }

            return rightWordsCounter;
        }
    }
}
