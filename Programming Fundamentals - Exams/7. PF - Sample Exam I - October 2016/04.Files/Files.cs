namespace _04.Files
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class Files
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<string> files = new List<string>();
            bool hasAnswer = false;

            for (int i = 0; i < n; i++)
            {
                files.Add(Console.ReadLine());
            }

            string query = Console.ReadLine();
            if (query != null)
            {
                string[] extensionInRoot = query.Split(' ');
                string extension = extensionInRoot[0];
                string root = extensionInRoot[2];

                Dictionary<string, long> fileNameAndFileSize = new Dictionary<string, long>();
                foreach (string file in files)
                {
                    string[] currentFileParts = file.Split('\\');
                    string currentFileRoot = currentFileParts[0];

                    string[] currentFileNameAndSize = currentFileParts[currentFileParts.Length - 1].Split(';');
                    string currentFileName = currentFileNameAndSize[0];
                    long currentFileSize = long.Parse(currentFileNameAndSize[1]);

                    if (currentFileRoot != root)
                    {
                        continue;
                    }

                    if (fileNameAndFileSize.ContainsKey(currentFileName))
                    {
                        fileNameAndFileSize[currentFileName] = currentFileSize;
                    }
                    else
                    {
                        fileNameAndFileSize.Add(currentFileName, currentFileSize);
                    }
                }

                foreach (KeyValuePair<string, long> pair in fileNameAndFileSize.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    if (pair.Key.Contains("." + extension))
                    {
                        hasAnswer = true;
                        Console.WriteLine($"{pair.Key} - {pair.Value} KB");
                    }
                }

                if (!hasAnswer)
                {
                    Console.WriteLine("No");
                }
            }
        }
    }
}
