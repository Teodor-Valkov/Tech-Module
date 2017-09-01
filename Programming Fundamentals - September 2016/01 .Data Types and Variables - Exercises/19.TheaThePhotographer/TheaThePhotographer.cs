namespace _19.TheaThePhotographer
{
    using System;

    class TheaThePhotographer
    {
        static void Main()
        {
            long pictures = int.Parse(Console.ReadLine());
            long singlePictureTime = int.Parse(Console.ReadLine());
            long percentageOfPictures = int.Parse(Console.ReadLine());
            long timePerEveryFilteredPicture = int.Parse(Console.ReadLine());

            double filteredPictures = Math.Ceiling((pictures * ((double)percentageOfPictures / 100)));
            double totalPicturesTime = pictures * singlePictureTime;
            double filteredPicturesTime = filteredPictures * timePerEveryFilteredPicture;
            double timeNeededInSeconds = totalPicturesTime + filteredPicturesTime;
            
            //solution with TimeSpan
            //Console.WriteLine(TimeSpan.FromSeconds(timeNeededInSeconds).ToString((new string('d', 1) + "\\:hh\\:mm\\:ss")));
            
            double days = Math.Floor(timeNeededInSeconds/86400);
            timeNeededInSeconds -= days*86400;

            double hours = Math.Floor(timeNeededInSeconds/3600);
            timeNeededInSeconds -= hours*3600;

            double minutes = Math.Floor(timeNeededInSeconds/60);
            timeNeededInSeconds -= minutes*60;

            double seconds = timeNeededInSeconds;
            
            Console.WriteLine($"{days}:{hours:00}:{minutes:00}:{seconds.ToString().PadLeft(2, '0')}");
        }
    }
}
