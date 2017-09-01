namespace _02.CircleArea
{   
    using System;

    class CircleArea
    {
        static void Main()
        {
            double radius = double.Parse(Console.ReadLine());
            double area = Math.PI * Math.Pow(radius, 2);

            Console.WriteLine("{0:f12}", area);
        }
    }
}
