namespace _13.VowelOrDigit
{
    using System;

    class VowelOrDigit
    {
        static void Main()
        {
            char symbol = Convert.ToChar(Console.ReadLine());

            if (char.IsDigit(symbol))
            {
                Console.WriteLine("digit");
                return;
            }

            switch (symbol)
            {
                case 'a':
                    Console.WriteLine("vowel");
                    break;
                case 'o':
                    Console.WriteLine("vowel");
                    break;
                case 'u':
                    Console.WriteLine("vowel");
                    break;
                case 'e':
                    Console.WriteLine("vowel");
                    break;
                case 'i':
                    Console.WriteLine("vowel");
                    break;
                default:
                    Console.WriteLine("other");
                    break;
            }
        }
    }
}
