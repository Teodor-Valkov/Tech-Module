namespace _04.RoliTheCoderSortedSet
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Event
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public SortedSet<string> Participants { get; set; }
    }

    class RoliTheCoderSortedSet
    {
        static void Main()
        {
            List<Event> events = new List<Event>();
            string input = Console.ReadLine();

            while (input != "Time for Code")
            {
                if (input != null)
                {
                    string[] inputArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    string tempId = inputArgs[0];
                    string tempName = inputArgs[1];
                    string[] participants = inputArgs.Skip(2).ToArray();

                    if (!tempName.StartsWith("#") || events.Any(ev => ev.Id == tempId && ev.Name != tempName.TrimStart('#')))
                    {
                        input = Console.ReadLine();
                        continue;
                    }

                    if (events.Any(e => e.Id == tempId))
                    {
                        Event currentEvent = events.First(e => e.Id == tempId);

                        foreach (string participant in participants)
                        {
                            currentEvent.Participants.Add(participant);
                        }
                    }
                    else
                    {
                        events.Add(new Event
                        {
                            Id = tempId,
                            Name = tempName.TrimStart('#'),
                            Participants = new SortedSet<string>(participants)
                        });
                    }
                }

                input = Console.ReadLine();
            }

            events = events.OrderByDescending(ev => ev.Participants.Count).ThenBy(ev => ev.Name).ToList();

            foreach (Event currentEvent in events)
            {
                Console.WriteLine($"{currentEvent.Name} - {currentEvent.Participants.Count}");
                foreach (string participant in currentEvent.Participants)
                {
                    Console.WriteLine(participant);
                }
            }
        }
    }
}
