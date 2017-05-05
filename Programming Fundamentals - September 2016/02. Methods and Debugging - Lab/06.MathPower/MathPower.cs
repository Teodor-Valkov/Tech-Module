namespace _06.MathPower
{
    using System;

    class MathPower
    {
        static void Main()
        {
            double n = double.Parse(Console.ReadLine());
            double power = double.Parse(Console.ReadLine());
            double result = CalculateMathPower(n, power); 

            Console.WriteLine(result);
        }

        private static double CalculateMathPower(double number, double power)
        {
            double result = Math.Pow(number, power);
            return result;
        }
    }
}
