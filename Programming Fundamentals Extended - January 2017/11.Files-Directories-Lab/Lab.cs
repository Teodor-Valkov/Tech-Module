namespace _11.Files_Directories_Lab
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    internal class Lab
    {
        private static void Main()
        {
            // Task 1
            OddLines();

            // Task 2
            LineNumbers();

            // Task 3
            WordCount();

            // Task 4
            MergeFiles();

            // Task 5
            FolderSize();
        }

        private static void OddLines()
        {
            string[] fileInput = File.ReadAllLines("new folder/input.txt");

            for (int i = 1; i < fileInput.Length; i += 2)
            {
                File.AppendAllText("output.txt", fileInput[i] + Environment.NewLine);
            }

            //File.WriteAllLines("output.txt", fileInput.Where((line, index) => index % 2 == 1));
        }

        private static void LineNumbers()
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

        private static void WordCount()
        {
            string separators = "/n/r,.!?- ";

            string[] text = File.ReadAllText("New folder/input.txt").ToLower().Split(separators.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            string[] words = File.ReadAllText("New folder/words.txt").ToLower().Split(' ');
            //string[] words = File.ReadAllLines("New folder/words.txt");
            //If the sentences are separated in new lines, the method itself splits them in new lines

            Dictionary<string, int> wordCount = new Dictionary<string, int>();

            foreach (string word in words)
            {
                wordCount[word] = 0;
            }

            foreach (string word in text)
            {
                if (wordCount.ContainsKey(word))
                {
                    wordCount[word]++;
                }
            }

            foreach (KeyValuePair<string, int> pair in wordCount.OrderByDescending(x => x.Value))
            {
                File.AppendAllText("Output/output.txt", $"{pair.Key} - {pair.Value}{Environment.NewLine}");
            }
        }

        private static void MergeFiles()
        {
            string[] firstFile = File.ReadAllLines("New folder/FileOne.txt");
            string[] secondFile = File.ReadAllLines("New folder/FileTwo.txt");

            for (int i = 0; i < firstFile.Length; i++)
            {
                File.AppendAllText("Output/ouput.txt", firstFile[i] + Environment.NewLine + secondFile[i] + Environment.NewLine);

                //File.AppendAllLines("Output/ouput.txt", new [] {firstFile[i], secondFile[i]});
                //The method itself has a separator for new line and we can just pass the parameters from the arrays
            }
        }

        private static void FolderSize()
        {
            string[] files = Directory.GetFiles("New folder/TestFolder");
            double sum = 0;

            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                sum += fileInfo.Length;
            }

            sum = sum / 1024 / 1024;

            File.WriteAllText("Output/output.txt", sum.ToString());
        }
    }
}