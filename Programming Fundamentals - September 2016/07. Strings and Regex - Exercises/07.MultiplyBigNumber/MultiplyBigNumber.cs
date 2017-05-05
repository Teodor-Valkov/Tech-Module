namespace _07.MultiplyBigNumber
{
    using System;
    using System.Text;
    using System.Numerics;

    class MultiplyBigNumber
    {
        static void Main()
        {
            // Solution with BigInteger
            //BigInteger firstNumber = BigInteger.Parse(Console.ReadLine());
            //BigInteger secondNumber = BigInteger.Parse(Console.ReadLine());
            //BigInteger multiplication = firstNumber * secondNumber;
            //
            //Console.WriteLine(multiplication);

            // Solution without BigInteger
            string firstNumber = Console.ReadLine().TrimStart('0');
            int secondNumber = int.Parse(Console.ReadLine());

            if (firstNumber == "0" || secondNumber == 0 || firstNumber == "")
            {
                Console.WriteLine(0);
                return;
            }

            int numberInMind = 0;
            StringBuilder result = new StringBuilder();

            for (int i = firstNumber.Length - 1; i >= 0; i--)
            {
                int product = int.Parse(firstNumber[i].ToString()) * secondNumber + numberInMind;

                numberInMind = product / 10;
                int remainder = product % 10;

                result.Append(remainder);

                if (i == 0 && numberInMind != 0)
                {
                    result.Append(numberInMind);
                }

            }

            char[] resultToCharArr = result.ToString().ToCharArray();
            Array.Reverse(resultToCharArr);

            Console.WriteLine(new string(resultToCharArr));
        }
    }
}
