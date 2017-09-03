namespace _15.InstructionSet
{
    using System;
    using System.Numerics;

    internal class InstructionSet
    {
        private static void Main()
        {
            string command = Console.ReadLine();

            while (command != null && command.ToLower() != "end")
            {
                string[] arguments = command.Split(' ');

                BigInteger result = 0;

                switch (arguments[0])
                {
                    //Everything should be of type 'long' because of an overflow even with +/- 1, or first we have to cast to 'long' and then +/- 1;

                    case "INC":
                        {
                            int operandOne = int.Parse(arguments[1]);
                            result = (long)operandOne + 1;
                            break;
                        }
                    case "DEC":
                        {
                            int operandOne = int.Parse(arguments[1]);
                            result = (long)operandOne - 1;
                            break;
                        }
                    case "ADD":
                        {
                            int operandOne = int.Parse(arguments[1]);
                            int operandTwo = int.Parse(arguments[2]);
                            result = (BigInteger)operandOne + operandTwo;
                            break;
                        }
                    case "MLA":
                        {
                            int operandOne = int.Parse(arguments[1]);
                            int operandTwo = int.Parse(arguments[2]);
                            result = (BigInteger)operandOne * operandTwo;
                            break;
                        }
                }

                command = Console.ReadLine();

                Console.WriteLine(result);
            }
        }
    }
}