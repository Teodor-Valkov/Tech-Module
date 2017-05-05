namespace _02.LineNumbers
{
    using System;
    using System.IO;

    class LineNumbers
    {
        static void Main()
        {
            //string[] text = File.ReadAllLines("Input/input.txt");
            //If the sentences are separated in new lines, the method itself splits them in new lines

            string[] text = File.ReadAllText("Input/input.txt").Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            //If the sentences are separated in new lines, we explicitly split them in new lines
            
            for (int i = 0; i < text.Length; i++)
            {
                File.AppendAllText("Output/output.txt", $"{i + 1}. {text[i]}{Environment.NewLine}");
            }
        }
    }
}
