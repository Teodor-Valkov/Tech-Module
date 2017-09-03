namespace _05.FolderSize
{
    using System.IO;

    internal class FolderSize
    {
        private static void Main()
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