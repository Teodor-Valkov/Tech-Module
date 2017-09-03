namespace _02.AdvertisementMessage
{
    using System;

    internal class AdvertisementMessage
    {
        private static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Random rnd = new Random();

            string[] phrases =
            {
                "Excellent product",
                "Such a great product",
                "I always use that product",
                "Best product of its category"
            };

            string[] events =
            {
                "Now I feel good",
                "I have succeeded to change",
                "That makes miracles",
                "I cannot believe but now I feel awesome",
                "Try it yourself, I am very satisfied"
            };

            string[] authors =
            {
                "Diana",
                "Petya",
                "Stella",
                "Elena",
                "Katya",
                "Iva",
                "Annie",
                "Misha"
            };

            string[] cities =
            {
                "Burgas",
                "Sofia",
                "Plovdiv",
                "Varna",
                "Ruse"
            };

            for (int i = 0; i < n; i++)
            {
                int randomNumber = rnd.Next(phrases.Length);
                string currentPhrase = phrases[randomNumber];

                randomNumber = rnd.Next(events.Length);
                string currentEvent = events[randomNumber];

                randomNumber = rnd.Next(authors.Length);
                string currentAuthor = authors[randomNumber];

                randomNumber = rnd.Next(cities.Length);
                string currentCity = cities[randomNumber];

                Console.WriteLine($"{currentPhrase}. {currentEvent}. {currentAuthor} - {currentCity}");
            }
        }
    }
}