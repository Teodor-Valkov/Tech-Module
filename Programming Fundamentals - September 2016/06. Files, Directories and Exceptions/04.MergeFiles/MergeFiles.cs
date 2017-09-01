namespace _04.MergeFiles
{
    using System;
    using System.IO;

    class MergeFiles
    {
        static void Main()
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
    }
}
