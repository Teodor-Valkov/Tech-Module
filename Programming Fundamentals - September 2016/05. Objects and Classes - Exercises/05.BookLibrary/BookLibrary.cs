namespace _05.BookLibrary
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string IsbnNumber { get; set; }
        public decimal Price { get; set; }
    }

    class Library
    {
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }

    class BookLibrary
    {
        static void Main()
        {
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

            //List<decimal> prices = myLibrary.Books.Where(x => x.Author == x.Author).Sum(x => x.Price + x.Price).ToList();

            Dictionary<string, decimal> authorsAndPrices = new Dictionary<string, decimal>();

            foreach (Book currentBook in myLibrary.Books)
            {
                if (!authorsAndPrices.ContainsKey(currentBook.Author))
                {
                    authorsAndPrices[currentBook.Author] = currentBook.Price;
                    //authorsAndPrices.Add(currentBook.Author, currentBook.Price);    
                }
                else
                {
                    authorsAndPrices[currentBook.Author] += currentBook.Price;
                }
            }

            foreach (KeyValuePair<string, decimal> pair in authorsAndPrices.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value:F2}");
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
                ReleaseDate = DateTime.Parse(currentBookParameters[3]),
                IsbnNumber = currentBookParameters[4],
                Price = decimal.Parse(currentBookParameters[5])
            };

            return currentBook;
        }
    }
}
