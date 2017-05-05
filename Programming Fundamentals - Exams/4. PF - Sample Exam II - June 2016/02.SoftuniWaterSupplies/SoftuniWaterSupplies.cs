namespace _02.SoftuniWaterSupplies
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class SoftuniWaterSupplies
    {
        static void Main()
        {
            double waterStorage = int.Parse(Console.ReadLine());
            List<double> bottlesFilled = Console.ReadLine().Split(' ').Select(double.Parse).ToList();
            double capacity = int.Parse(Console.ReadLine());

            List<double> bottlesWithoutWater = new List<double>();
            int bottlesWithoutWaterCount = 0;

            if (waterStorage % 2 == 0)
            {
                for (int i = 0; i < bottlesFilled.Count; i++)
			    {
			        double currentBottleFilled = bottlesFilled[i];
                    double toBeFilled = capacity - currentBottleFilled;

                    if (waterStorage >= capacity)
                    {
                        waterStorage -= toBeFilled;
                    }
                    else
                    {
                        waterStorage -= toBeFilled;

                        if (waterStorage < 0)
                        {
                            bottlesWithoutWater.Add(i);
                            bottlesWithoutWaterCount++;
                        }
                    }                    
			    }   
            }
            else
            {
                for (int i = bottlesFilled.Count - 1; i >= 0 ; i--)
                {
                    double currentBottleFilled = bottlesFilled[i];
                    double toBeFilled = capacity - currentBottleFilled;
                     
                    if (waterStorage >= capacity)
                    {
                        waterStorage -= toBeFilled;
                    }
                    else
                    {
                        waterStorage -= toBeFilled;

                        if (waterStorage < 0)
                        {
                            bottlesWithoutWater.Add(i);
                            bottlesWithoutWaterCount++;
                        }
                    }
                }
            }

            if (waterStorage >= 0)
            {
                Console.WriteLine("Enough water!");
                Console.WriteLine($"Water left: {waterStorage}l.");
            }
            else
            {
                Console.WriteLine("We need more water!");
                Console.WriteLine($"Bottles left: {bottlesWithoutWaterCount}");
                Console.WriteLine($"With indexes: {string.Join(", ", bottlesWithoutWater)}");
                Console.WriteLine($"We need {Math.Abs(waterStorage)} more liters!");
            }
        }
    }
}
