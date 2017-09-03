namespace _04.RoliTheCoderDictionaries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class RoliTheCoderDictionaries
    {
        private static void Main()
        {
            string input = Console.ReadLine();
            Dictionary<int, string> idAndEvent = new Dictionary<int, string>();
            Dictionary<string, List<string>> eventAndParticipants = new Dictionary<string, List<string>>();

            while (input != null && !input.Equals("Time for Code"))
            {
                // Regex for checking if the input line is valid
                //
                //string pattern = @"\d+\s+#[a-zA-Z0-9]+\s?(@[a-zA-Z]+\s+)*";
                //Regex regex = new Regex(pattern);
                //if (!regex.IsMatch(input))
                //{
                //    input = Console.ReadLine();
                //    continue;
                //}

                if (input.Contains("#"))
                {
                    string[] iputArgs = input.Split(new[] { ' ', '#' }, StringSplitOptions.RemoveEmptyEntries);
                    int id = int.Parse(iputArgs[0]);
                    string eventName = iputArgs[1];

                    List<string> participants = new List<string>();
                    if (iputArgs.Length > 2)
                    {
                        for (int i = 2; i < iputArgs.Length; i++)
                        {
                            participants.Add(iputArgs[i]);
                        }
                    }

                    if (!idAndEvent.ContainsKey(id))
                    {
                        idAndEvent.Add(id, eventName);
                        eventAndParticipants.Add(eventName, participants);
                    }
                    else if (idAndEvent[id] == eventName)
                    {
                        eventAndParticipants[eventName].AddRange(participants);
                    }
                }

                input = Console.ReadLine();
            }

            eventAndParticipants = eventAndParticipants.
                OrderByDescending(x => x.Value.Distinct().Count())
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (KeyValuePair<string, List<string>> pair in eventAndParticipants)
            {
                Console.WriteLine($"{pair.Key} - {pair.Value.Distinct().Count()}");

                foreach (string participant in pair.Value.OrderBy(x => x).Distinct())
                {
                    Console.WriteLine(participant);
                }
            }
        }
    }
}