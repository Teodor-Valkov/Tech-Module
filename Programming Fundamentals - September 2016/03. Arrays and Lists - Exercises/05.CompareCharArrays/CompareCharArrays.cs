namespace _05.CompareCharArrays
{
    using System;
    using System.Collections.Generic;

    internal class CompareCharArrays
    {
        private static void Main()
        {
            string firstArray = Console.ReadLine();
            string secondArray = Console.ReadLine();

            List<string> alphabeticalOrder = new List<string>(new[] { firstArray, secondArray });
            alphabeticalOrder.Sort();

            foreach (string inputLine in alphabeticalOrder)
            {
                Console.WriteLine(string.Join("", inputLine.Replace(" ", "")));
            }

            //char[] firstArray = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
            //char[] secondArray = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
            //
            //string[] arrays = { new string(firstArray), new string(secondArray) };
            //Array.Sort(arrays);
            //
            //Console.WriteLine(string.Join("\n", arrays));
        }
    }
}