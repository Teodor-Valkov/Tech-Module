namespace _06.Algorithms_More_Exercises
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Exercises
    {
        private static void Main()
        {
            // Task 1
            RabbitHole();

            // Task 2
            JapaneseRoulette();

            // Task 3
            IncreasingCrisis();

            // Task 4
            Extremums();
        }

        private static void RabbitHole()
        {
            List<string> obstacles = Console.ReadLine().Split(' ').ToList();
            int energy = int.Parse(Console.ReadLine());

            bool bombExplosion = false;
            string currentObstacle = string.Empty;
            int position = 0;

            while (true)
            {
                currentObstacle = obstacles[position];

                if (energy <= 0 && bombExplosion)
                {
                    Console.WriteLine("You are dead due to bomb explosion!");
                    break;
                }

                if (energy <= 0)
                {
                    Console.WriteLine("You are tired. You can't continue the mission.");
                    break;
                }

                if (currentObstacle.ToLower() == "rabbithole")
                {
                    Console.WriteLine("You have 5 years to save Kennedy!");
                    break;
                }

                string[] currentObstacleElements = currentObstacle.Split('|');
                string direction = currentObstacleElements[0];
                int jumps = int.Parse(currentObstacleElements[1]);

                bombExplosion = false;

                switch (direction.ToLower())
                {
                    case "right":
                        position = position + (jumps % obstacles.Count);
                        break;

                    case "left":
                        position = position - (jumps % obstacles.Count);
                        position = Math.Abs(position);
                        break;

                    case "bomb":
                        obstacles.RemoveAt(position);
                        position = 0;
                        bombExplosion = true;
                        break;
                }

                energy -= jumps;

                if (obstacles.Last().ToLower() != "rabbithole")
                {
                    obstacles.RemoveAt(obstacles.Count - 1);
                }

                obstacles.Add(string.Format($"Bomb|{energy}"));
            }
        }

        private static void JapaneseRoulette()
        {
            List<int> cylinder = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<string> players = Console.ReadLine().Split(' ').ToList();

            int beginPosition = cylinder.FindIndex(num => num == 1);
            int endPosition = 0;

            for (int i = 0; i < players.Count; i++)
            {
                string[] currentPlayer = players[i].Split(',');
                int strength = int.Parse(currentPlayer[0]);
                string direction = currentPlayer[1];

                switch (direction.ToLower())
                {
                    case "right":
                        endPosition = beginPosition + (strength % cylinder.Count);

                        if (endPosition >= cylinder.Count)
                        {
                            endPosition -= cylinder.Count;
                        }

                        beginPosition = endPosition;
                        break;

                    case "left":
                        endPosition = beginPosition - (strength % cylinder.Count);

                        if (endPosition < 0)
                        {
                            endPosition += cylinder.Count;
                        }

                        beginPosition = endPosition;
                        break;
                }

                if (endPosition == 2)
                {
                    Console.WriteLine($"Game over! Player {i} is dead.");
                    return;
                }

                beginPosition++;
            }

            Console.WriteLine("Everybody got lucky!");
        }

        private static void IncreasingCrisis()
        {
            int number = int.Parse(Console.ReadLine());
            List<int> numbers = new List<int>();

            for (int i = 0; i < number; i++)
            {
                List<int> currentNumbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

                if (i == 0 || numbers.Last() <= currentNumbers.First())
                {
                    numbers.AddRange(currentNumbers);
                }
                else
                {
                    int currentFirstNumber = currentNumbers.First();
                    int indexToInsert = numbers.FindLastIndex(num => num <= currentFirstNumber) + 1;

                    for (int j = 0; j < currentNumbers.Count; j++)
                    {
                        numbers.Insert(indexToInsert + j, currentNumbers[j]);

                        if (numbers[indexToInsert + j] > numbers[indexToInsert + j + 1])
                        {
                            break;
                        }
                    }

                    for (int j = 0; j < numbers.Count - 1; j++)
                    {
                        if (numbers[j] > numbers[j + 1])
                        {
                            int numbersToRemove = numbers.Count - j - 1;
                            numbers.RemoveRange(j + 1, numbersToRemove);
                            break;
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void Extremums()
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            string minOrMax = Console.ReadLine();

            List<int> result = new List<int>();

            if (minOrMax != null && minOrMax.ToLower() == "min")
            {
                int minNumber = 0;
                int currentNumber = 0;
                string currentNumberAsString = string.Empty;

                foreach (int number in numbers)
                {
                    int counter = number.ToString().Length;
                    currentNumberAsString = number.ToString();
                    minNumber = number;

                    for (int i = 0; i < counter; i++)
                    {
                        currentNumberAsString = currentNumberAsString.Insert(currentNumberAsString.Length, currentNumberAsString[0].ToString());
                        currentNumberAsString = currentNumberAsString.Remove(0, 1);
                        currentNumber = int.Parse(currentNumberAsString);

                        if (minNumber > currentNumber)
                        {
                            minNumber = currentNumber;
                        }
                    }

                    result.Add(minNumber);
                }
            }

            if (minOrMax != null && minOrMax.ToLower() == "max")
            {
                int maxNumber = 0;
                int currentNumber = 0;
                string currentNumberAsString = string.Empty;

                foreach (int number in numbers)
                {
                    int counter = number.ToString().Length;
                    currentNumberAsString = number.ToString();
                    maxNumber = number;

                    for (int i = 0; i < counter; i++)
                    {
                        currentNumberAsString = currentNumberAsString.Insert(currentNumberAsString.Length, currentNumberAsString[0].ToString());
                        currentNumberAsString = currentNumberAsString.Remove(0, 1);
                        currentNumber = int.Parse(currentNumberAsString);

                        if (maxNumber < currentNumber)
                        {
                            maxNumber = currentNumber;
                        }
                    }

                    result.Add(maxNumber);
                }
            }

            Console.WriteLine(string.Join(", ", result));
            Console.WriteLine(result.Sum());
        }
    }
}