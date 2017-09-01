namespace _18.DifferentIntegersSize
{
    using System;

    class DifferentIntegersSize
    {
        static void Main()
        {
            string number = Console.ReadLine();
            bool answer = false;
            long l; sbyte sb; byte b; short sh; ushort us; int i; uint ui;

            if (long.TryParse(number, out l))
            {
                answer = true;
                Console.WriteLine("{0} can fit in: ", number);
            }
            if (sbyte.TryParse(number, out sb))
            {
                Console.WriteLine("* sbyte");
            }
            if (byte.TryParse(number, out b))
            {
                Console.WriteLine("* byte");
            }
            if (short.TryParse(number, out sh))
            {
                Console.WriteLine("* short");
            }
            if (ushort.TryParse(number, out us))
            {
                Console.WriteLine("* ushort");
            }
            if (int.TryParse(number, out i))
            {
                Console.WriteLine("* int");
            }
            if (uint.TryParse(number, out ui))
            {
                Console.WriteLine("* uint");
            }
            if (long.TryParse(number, out l))
            {
                Console.WriteLine("* long");
            }
            if (!answer)
            {
                Console.WriteLine($"{number} can't fit in any type");
            }
        }
    }
}
