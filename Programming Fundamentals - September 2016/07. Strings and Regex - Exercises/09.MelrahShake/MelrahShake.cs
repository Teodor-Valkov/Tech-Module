namespace _09.MelrahShake
{
    using System;
    using System.Text;

    class MelrahShake
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string pattern = Console.ReadLine();

            while (true)
            {
                if (input != null)
                {
                    if (pattern != null)
                    {
                        int firstIndex = input.IndexOf(pattern, StringComparison.Ordinal);
                        int lastIndex = input.LastIndexOf(pattern, StringComparison.Ordinal);

                        if (firstIndex >= 0 && lastIndex >= 0 && firstIndex != lastIndex && pattern.Length > 0)
                        {
                            StringBuilder sb = new StringBuilder(input);

                            sb.Remove(firstIndex, pattern.Length);
                            sb.Remove(lastIndex - pattern.Length, pattern.Length);
                            input = sb.ToString();

                            Console.WriteLine("Shaked it.");

                            sb = new StringBuilder(pattern);
                            sb.Remove(pattern.Length / 2, 1);
                            pattern = sb.ToString();
                        }
                        else
                        {
                            Console.WriteLine("No shake.");
                            Console.WriteLine(input);
                            break;
                        }
                    }
                }
            }
        }
    }
}
