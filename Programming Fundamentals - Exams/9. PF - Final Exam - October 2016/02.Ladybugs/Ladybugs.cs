namespace _02.Ladybugs
{
    using System;
    using System.Linq;

    internal class Ladybugs
    {
        private static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            int[] ladybugIndexes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int[] fieldSize = new int[size];

            foreach (int currentLadybugIndex in ladybugIndexes)
            {
                if (currentLadybugIndex >= 0 && currentLadybugIndex < fieldSize.Length)
                {
                    int ladybugPosition = currentLadybugIndex;
                    fieldSize[ladybugPosition] = 1;
                }
            }

            while (true)
            {
                string command = Console.ReadLine();

                if (command != null && command.ToLower() == "end")
                    break;

                if (command != null)
                {
                    string[] commandArgs = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    int currentLadybugPosition = int.Parse(commandArgs[0]);
                    string direction = commandArgs[1];
                    int currentLadybugFlyLength = int.Parse(commandArgs[2]);

                    if (currentLadybugPosition < 0)
                    {
                        continue;
                    }

                    if (currentLadybugPosition >= fieldSize.Length)
                    {
                        continue;
                    }

                    if (fieldSize[currentLadybugPosition] == 0)
                    {
                        continue;
                    }

                    if (currentLadybugFlyLength == 0)
                    {
                        continue;
                    }

                    if (direction.ToLower() == "right")
                    {
                        while (true)
                        {
                            if (currentLadybugFlyLength > 0)
                            {
                                if (currentLadybugPosition + currentLadybugFlyLength > fieldSize.Length - 1)
                                {
                                    fieldSize[currentLadybugPosition] = 0;
                                    break;
                                }
                            }

                            if (currentLadybugFlyLength < 0)
                            {
                                if (currentLadybugPosition + currentLadybugFlyLength < 0)
                                {
                                    fieldSize[currentLadybugPosition] = 0;
                                    break;
                                }
                            }

                            if (fieldSize[currentLadybugPosition + currentLadybugFlyLength] == 1)
                            {
                                if (currentLadybugFlyLength > 0)
                                {
                                    currentLadybugFlyLength += currentLadybugFlyLength;
                                }
                                else
                                {
                                    currentLadybugFlyLength -= currentLadybugFlyLength;
                                }
                            }
                            else
                            {
                                fieldSize[currentLadybugPosition] = 0;
                                fieldSize[currentLadybugPosition + currentLadybugFlyLength] = 1;
                                break;
                            }
                        }
                    }

                    if (direction.ToLower() == "left")
                    {
                        if (currentLadybugFlyLength > 0)
                        {
                            while (true)
                            {
                                if (currentLadybugPosition - currentLadybugFlyLength < 0)
                                {
                                    fieldSize[currentLadybugPosition] = 0;
                                    break;
                                }

                                if (fieldSize[currentLadybugPosition - currentLadybugFlyLength] == 1)
                                {
                                    currentLadybugFlyLength += currentLadybugFlyLength;
                                }
                                else
                                {
                                    fieldSize[currentLadybugPosition] = 0;
                                    fieldSize[currentLadybugPosition - currentLadybugFlyLength] = 1;
                                    break;
                                }
                            }
                        }

                        if (currentLadybugFlyLength < 0)
                        {
                            while (true)
                            {
                                if (currentLadybugPosition - currentLadybugFlyLength > fieldSize.Length - 1)
                                {
                                    fieldSize[currentLadybugPosition] = 0;
                                    break;
                                }

                                if (fieldSize[currentLadybugPosition - currentLadybugFlyLength] == 1)
                                {
                                    currentLadybugFlyLength -= currentLadybugFlyLength;
                                }
                                else
                                {
                                    fieldSize[currentLadybugPosition] = 0;
                                    fieldSize[currentLadybugPosition - currentLadybugFlyLength] = 1;
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(" ", fieldSize));
        }
    }
}