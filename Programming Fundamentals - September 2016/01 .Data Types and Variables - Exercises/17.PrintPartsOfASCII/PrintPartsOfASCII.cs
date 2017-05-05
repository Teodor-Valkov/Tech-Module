namespace _17.PrintPartsOfASCII
{
    using System;
    using System.Collections.Generic;

    class PrintPartsOfAscii
    {
        static void Main()
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            List<char> symbols = new List<char>();

            for (int i = start; i <= end; i++)
            {
                symbols.Add(Convert.ToChar(i));
            }
            
            Console.WriteLine(string.Join(" ", symbols));
        }
    }
}
