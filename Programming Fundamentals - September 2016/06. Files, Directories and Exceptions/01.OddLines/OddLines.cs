namespace _01.OddLines
{
    using System;
    using System.IO;

    internal class OddLines
    {
        private static void Main()
        {
            string[] fileInput = File.ReadAllLines("new folder/input.txt");

            for (int i = 1; i < fileInput.Length; i += 2)
            {
                File.AppendAllText("output.txt", fileInput[i] + Environment.NewLine);
            }

            //File.WriteAllLines("output.txt", fileInput.Where((line, index) => index % 2 == 1));
        }
    }
}