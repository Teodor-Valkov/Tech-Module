namespace _02.Ladybugs3
{
    using System;
    using System.Linq;

    internal class Ladybugs3
    {
        private static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            long[] occupiedIndexes = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();

            int[] fieldSize = new int[size];

            for (long i = 0; i < occupiedIndexes.Length; i++)
            {
                if (occupiedIndexes[i] < fieldSize.Length && occupiedIndexes[i] >= 0)
                {
                    fieldSize[occupiedIndexes[i]] = 1;
                }
            }

            string command = Console.ReadLine();

            while (command != null && !command.Equals("end"))
            {
                string[] commandArgs = command.Split(' ');

                int currentLadybugPosition = int.Parse(commandArgs[0]);
                string direction = commandArgs[1];
                int currentLadybugFlyLength = int.Parse(commandArgs[2]);

                if (currentLadybugPosition >= 0 && currentLadybugPosition < fieldSize.Length)
                {
                    if (fieldSize[currentLadybugPosition] != 0)
                    {
                        if (direction == "right" && currentLadybugFlyLength > 0 || direction == "left" && currentLadybugFlyLength < 0)
                        {
                            currentLadybugFlyLength = Math.Abs(currentLadybugFlyLength);
                            fieldSize[currentLadybugPosition] = 0;

                            while (true)
                            {
                                if (currentLadybugPosition + currentLadybugFlyLength < fieldSize.Length)
                                {
                                    if (fieldSize[currentLadybugPosition + currentLadybugFlyLength] == 1)
                                    {
                                        currentLadybugFlyLength += currentLadybugFlyLength;
                                    }
                                    else
                                    {
                                        fieldSize[currentLadybugPosition + currentLadybugFlyLength] = 1;
                                        break;
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        else if (direction == "right" && currentLadybugFlyLength < 0 || direction == "left" && currentLadybugFlyLength > 0)
                        {
                            currentLadybugFlyLength = Math.Abs(currentLadybugFlyLength);
                            fieldSize[currentLadybugPosition] = 0;

                            while (true)
                            {
                                if (currentLadybugPosition - currentLadybugFlyLength >= 0)
                                {
                                    if (fieldSize[currentLadybugPosition - currentLadybugFlyLength] == 1)
                                    {
                                        currentLadybugFlyLength += currentLadybugFlyLength;
                                    }
                                    else
                                    {
                                        fieldSize[currentLadybugPosition - currentLadybugFlyLength] = 1;
                                        break;
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", fieldSize));
        }
    }
}