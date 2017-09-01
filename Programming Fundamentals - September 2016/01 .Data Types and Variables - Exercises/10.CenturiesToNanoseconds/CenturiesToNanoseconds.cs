namespace _10.CenturiesToNanoseconds
{
    using System;
    using System.Numerics;

    class CenturiesToNanoseconds
    {
        static void Main()
        {
            byte centuries = byte.Parse(Console.ReadLine());
            short years = (short)(centuries * 100);
            int days = (int)(years * 365.2422);
            long hours = (long)(days * 24);
            long minutes = (long)(hours * 60);
            ulong seconds = (ulong)(minutes * 60);
            BigInteger milliseconds = (BigInteger)(seconds * 1000);
            BigInteger microseconds = (BigInteger)(milliseconds * 1000);
            BigInteger nanoseconds = (BigInteger)(microseconds * 1000);

            Console.WriteLine($"{centuries} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes = {seconds} seconds = {milliseconds} milliseconds = {microseconds} microseconds = {nanoseconds} nanoseconds");
        }
    }
}
