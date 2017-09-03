namespace _06.BookLibraryModification
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    internal class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string IsbnNumber { get; set; }
        public decimal Price { get; set; }
    }

    internal class Library
    {
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }

    internal class BookLibrary
    {
        private static void Main()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            int n = int.Parse(Console.ReadLine());

            Library myLibrary = new Library
            {
                Books = new List<Book>()
            };

            for (int i = 0; i < n; i++)
            {
                Book currentBook = ReadBook();
                myLibrary.Books.Add(currentBook);
            }

            DateTime givenDate = DateTime.Parse(Console.ReadLine(), new CultureInfo("bg-BG"));

            Dictionary<string, DateTime> titleAndReleasedDate = new Dictionary<string, DateTime>();

            foreach (Book currentBook in myLibrary.Books)
            {
                if (currentBook.ReleaseDate > givenDate)
                {
                    titleAndReleasedDate.Add(currentBook.Title, currentBook.ReleaseDate);
                    //titleAndReleasedDate[currentBook.Title] = currentBook.ReleaseDate;
                }
            }

            foreach (KeyValuePair<string, DateTime> pair in titleAndReleasedDate.OrderBy(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value:dd.MM.yyyy}");
            }
        }

        private static Book ReadBook()
        {
            string[] currentBookParameters = Console.ReadLine().Split(' ');

            Book currentBook = new Book()
            {
                Title = currentBookParameters[0],
                Author = currentBookParameters[1],
                Publisher = currentBookParameters[2],
                ReleaseDate = DateTime.ParseExact(currentBookParameters[3], "dd.MM.yyyy", new CultureInfo("bg-BG")),
                IsbnNumber = currentBookParameters[4],
                Price = decimal.Parse(currentBookParameters[5])
            };

            return currentBook;
        }
    }
}