namespace _02.TrophonTheGrumpyCat
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class TrophonTheGrumpyCat
    {
        static void Main()
        {
            List<int> items = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int startingItem = int.Parse(Console.ReadLine());
            string typeOfItems = Console.ReadLine();
            string typeOfPriceRatings = Console.ReadLine();

            long leftSum = 0;
            long rightSum = 0;

            for (int i = 0; i < startingItem; i++)
            {
                switch (typeOfPriceRatings)
                {
                    case "all":
                        if (typeOfItems == "expensive" && items[i] >= items[startingItem])
                        {
                            leftSum += items[i];
                        }
                        else if (typeOfItems == "cheap" && items[i] < items[startingItem])
                        {
                            leftSum += items[i];
                        }
                        break;

                    case "negative":
                        if (typeOfItems == "expensive" && items[i] >= items[startingItem] && items[i] < 0)
                        {
                            leftSum += items[i];
                        }
                        else if (typeOfItems == "cheap" && items[i] < items[startingItem] && items[i] < 0)
                        {
                            leftSum += items[i];
                        }
                        break;

                    case "positive":
                        if (typeOfItems == "expensive" && items[i] >= items[startingItem] && items[i] > 0)
                        {
                            leftSum += items[i];
                        }
                        else if (typeOfItems == "cheap" && items[i] < items[startingItem] && items[i] > 0)
                        {
                            leftSum += items[i];
                        }
                        break;
                }
            }

            for (int i = startingItem + 1; i < items.Count; i++)
            {
                switch (typeOfPriceRatings)
                {
                    case "all":
                        if (typeOfItems == "expensive" && items[i] >= items[startingItem])
                        {
                            rightSum += items[i];
                        }
                        else if (typeOfItems == "cheap" && items[i] < items[startingItem])
                        {
                            rightSum += items[i];
                        }
                        break;

                    case "negative":
                        if (typeOfItems == "expensive" && items[i] >= items[startingItem] && items[i] < 0)
                        {
                            rightSum += items[i];
                        }
                        else if (typeOfItems == "cheap" && items[i] < items[startingItem] && items[i] < 0)
                        {
                            rightSum += items[i];
                        }
                        break;

                    case "positive":
                        if (typeOfItems == "expensive" && items[i] >= items[startingItem] && items[i] > 0)
                        {
                            rightSum += items[i];
                        }
                        else if (typeOfItems == "cheap" && items[i] < items[startingItem] && items[i] > 0)
                        {
                            rightSum += items[i];
                        }
                        break;
                }
            }

            Console.WriteLine(leftSum >= rightSum ? $"Left - {leftSum}" : $"Right - {rightSum}");
        }
    }
}