namespace _06.SumBigNumbers
{
    using System;
    using System.Text;

    internal class SumBigNumbers
    {
        private static void Main()
        {
            // Solution with BigInteger
            //BigInteger firstNumber = BigInteger.Parse(Console.ReadLine());
            //BigInteger secondNumber = BigInteger.Parse(Console.ReadLine());
            //BigInteger sum = firstNumber + secondNumber;
            //
            //Console.WriteLine(sum);

            // Solution without BigInteger
            string firstNumber = Console.ReadLine().TrimStart('0');
            string secondNumber = Console.ReadLine().TrimStart('0');

            if (firstNumber.Length > secondNumber.Length)
            {
                secondNumber = secondNumber.PadLeft(firstNumber.Length, '0');
            }
            else
            {
                firstNumber = firstNumber.PadLeft(secondNumber.Length, '0');
            }

            int numberInMind = 0;
            StringBuilder result = new StringBuilder();

            for (int i = firstNumber.Length - 1; i >= 0; i--)
            {
                int sum = int.Parse(firstNumber[i].ToString()) + int.Parse(secondNumber[i].ToString()) + numberInMind;

                numberInMind = sum / 10;
                int remainder = sum % 10;

                result.Append(remainder);

                if (i == 0 && numberInMind != 0)
                {
                    result.Append(numberInMind);
                }
            }

            char[] resultToChar = result.ToString().ToCharArray();
            Array.Reverse(resultToChar);

            Console.WriteLine(new string(resultToChar));
        }
    }
}