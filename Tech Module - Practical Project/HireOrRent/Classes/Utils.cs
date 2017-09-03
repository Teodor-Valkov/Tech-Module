namespace HireOrRent.Classes
{
    public class Utils
    {
        public static string CutText(string text, int maxLength = 200)
        {
            if (text == null || text.Length <= maxLength)

            {
                return text;
            }
            var shortText = text.Substring(0, maxLength) + "...";
            return shortText;
        }
    }
}