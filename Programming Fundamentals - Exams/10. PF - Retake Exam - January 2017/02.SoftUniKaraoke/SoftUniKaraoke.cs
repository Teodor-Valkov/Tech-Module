namespace _02.SoftUniKaraoke
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Singer
    {
        public Singer()
        {
            Songs = new List<string>();
            Awards = new List<string>();
        }

        public string Name { get; set; }
        public List<string> Songs { get; set; }
        public List<string> Awards { get; set; }
    }

    internal class SoftUniKaraoke
    {
        private static void Main()
        {
            List<Singer> singers = new List<Singer>();
            List<string> givenAwards = new List<string>();

            string[] inputSingers = Console.ReadLine().Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] inputSongs = Console.ReadLine().Split(',');

            List<string> songs = new List<string>();
            foreach (string song in inputSongs)
            {
                songs.Add(song.Trim());
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input != null && input.ToLower() == "dawn")
                    break;

                if (input != null)
                {
                    string[] inputArgs = input.Split(',');
                    string currentSingerName = inputArgs[0].Trim();
                    string currentSong = inputArgs[1].Trim();
                    string currentAward = inputArgs[2].Trim();

                    if (!inputSingers.Contains(currentSingerName))
                        continue;

                    if (!songs.Contains(currentSong))
                        continue;

                    if (singers.Any(s => s.Name == currentSingerName))
                    {
                        Singer singer = singers.First(s => s.Name == currentSingerName);
                        if (!singer.Songs.Contains(currentSong))
                        {
                            singer.Songs.Add(currentSong);
                        }
                        if (!singer.Awards.Contains(currentAward) && !givenAwards.Contains(currentAward))
                        {
                            singer.Awards.Add(currentAward);
                        }
                    }
                    else
                    {
                        Singer singer = new Singer
                        {
                            Name = currentSingerName
                        };

                        singer.Songs.Add(currentSong);
                        singer.Awards.Add(currentAward);

                        singers.Add(singer);
                    }

                    givenAwards.Add(currentAward);
                }
            }

            foreach (Singer singer in singers.OrderByDescending(x => x.Awards.Count).ThenBy(x => x.Name))
            {
                Console.WriteLine($"{singer.Name}: {singer.Awards.Count} awards");
                foreach (string award in singer.Awards.OrderBy(x => x))
                {
                    Console.WriteLine($"--{award}");
                }
            }

            if (singers.Count == 0)
            {
                Console.WriteLine("No awards");
            }
        }
    }
}