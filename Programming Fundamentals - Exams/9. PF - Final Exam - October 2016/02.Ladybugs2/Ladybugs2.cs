namespace _02.Ladybugs2
{
    using System;
    using System.Linq;

    internal class Ladybugs2
    {
        private static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            int[] occupiedIndexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            bool[] fieldSize = new bool[size];

            foreach (int index in occupiedIndexes.Where(index => index >= 0 && index < size))
            {
                fieldSize[index] = true;
            }

            string input = Console.ReadLine();

            while (input != "end")
            {
                if (input != null)
                {
                    string[] commandArgs = input.Split();

                    int currentLadybugPosition = int.Parse(commandArgs[0]);
                    string direction = commandArgs[1];
                    int currentLadybugFlyLength = int.Parse(commandArgs[2]);

                    int initialIndex = currentLadybugPosition;

                    if (direction == "left")
                    {
                        currentLadybugFlyLength *= -1;
                    }

                    if (initialIndex >= 0 && initialIndex < fieldSize.Length && fieldSize[initialIndex] && currentLadybugFlyLength != 0)
                    {
                        while (currentLadybugPosition >= 0 && currentLadybugPosition < fieldSize.Length)
                        {
                            if (!fieldSize[currentLadybugPosition])
                            {
                                fieldSize[currentLadybugPosition] = true;
                                break;
                            }

                            currentLadybugPosition += currentLadybugFlyLength;
                        }

                        fieldSize[initialIndex] = false;
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", fieldSize.Select(isOccupied => isOccupied ? 1 : 0)));
        }
    }
}