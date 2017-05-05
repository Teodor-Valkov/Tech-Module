namespace _04.RoliTheCoderClass
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class Event
    {
        public Event()
        {
            Participants = new List<string>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public List<string> Participants { get; set; }
    }

    class RoliTheCoderClass
    {
        static void Main()
        { 
            List<Event> allEvents = new List<Event>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input != null && input.ToLower() == "time for code")
                    break;

                if (input != null && !input.Contains("#"))
                    continue;

                if (input != null)
                {
                    string[] inputArgs = input.Split(new [] { ' ', '#', '@' }, StringSplitOptions.RemoveEmptyEntries);
                    string tempId = inputArgs[0];
                    string tempName = inputArgs[1];
                    
                    if (input.Contains("@"))
                    {
                        Event currentEvent = new Event();

                        if (allEvents.All(ev => ev.Id != tempId))
                        {
                            currentEvent.Id = tempId;
                            currentEvent.Name = tempName;
                            for (int i = 2; i < inputArgs.Length; i++)
                            {
                                string tempParticipant = inputArgs[i];
                                if (!currentEvent.Participants.Contains(tempParticipant))
                                {
                                    currentEvent.Participants.Add(tempParticipant);
                                }
                            }

                            allEvents.Add(currentEvent);
                        }
                        else
                        {
                            int index = allEvents.FindIndex(ev => ev.Id == tempId);
                            if (allEvents[index].Name == tempName)
                            {
                                for (int i = 2; i < inputArgs.Length; i++)
                                {
                                    string tempParticipant = inputArgs[i];
                                    if (!allEvents[index].Participants.Contains(tempParticipant))
                                    {
                                        allEvents[index].Participants.Add(tempParticipant);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (allEvents.All(x => x.Name != tempName))
                        {
                            Event current = new Event
                            {
                                Id = tempId,
                                Name = tempName
                            };

                            allEvents.Add(current);
                        }
                    }
                }
            }

            allEvents = allEvents.OrderByDescending(x => x.Participants.Count).ThenBy(x => x.Name).ToList();

            foreach (Event currentEvent in allEvents)
            {
                Console.WriteLine($"{currentEvent.Name} - {currentEvent.Participants.Count}");
                foreach (string participant in currentEvent.Participants.OrderBy(x => x))
                {
                    Console.WriteLine($"@{participant}");
                }
            }
        }
    }
}
