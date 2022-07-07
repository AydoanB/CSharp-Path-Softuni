using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace BookShop
{
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            Console.WriteLine(RemoveBooks(db));
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var sb = new StringBuilder();

            string suitableCommand = command[0].ToString().ToUpper() + command.Substring(1).ToLower();

            var result = context.Books
                .ToList()
                .Where(x => x.AgeRestriction.ToString().Equals(suitableCommand))
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToList();

            foreach (var book in result)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().Trim();
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var result = context.Books
                .Where(x => x.Copies < 5000)
                .OrderBy(x => x.BookId);
            var sb = new StringBuilder();

            foreach (var book in result)
            {
                sb.AppendLine($"{book.Title}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var result = context.Books
                .Where(x => x.Price >= 40)
                .OrderByDescending(x => x.Price)
                .ToList();

            var sb = new StringBuilder();

            foreach (var book in result)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:f2}");
            }
            return sb.ToString().TrimEnd();

        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var result = context.Books
                .Where(x => x.ReleaseDate.Value.Year != year)
                .OrderBy(x => x.BookId)
                .ToList();

            var sb = new StringBuilder();

            foreach (var book in result)
            {
                sb.AppendLine(book.Title);
            }
            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var splittedInput = input.Split(" ").ToList().Select(element => element[0].ToString().ToUpper() + element.Substring(1).ToLower()).ToList();

            var books = context.Books
                .Where(x => x.BookCategories.Any(b => splittedInput.Contains(b.Category.Name)))
                .OrderBy(x => x.Title)
                .ToList();

            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().TrimEnd();

        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime parsedDate = DateTime.Parse(date);

            var results = context.Books
                .ToList()
                .Where(x => x.ReleaseDate.Value.Date < parsedDate)
                .Select(x => new
                {
                    x.Title,
                    Edition = x.EditionType.ToString(),
                    x.Price
                })
                .ToList();
            var sb = new StringBuilder();
            foreach (var book in results)
            {
                sb.AppendLine($"{book.Title} - {book.Edition} - {book.Price}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                .ToList()
                .Where(a => a.FirstName.EndsWith(input))
                .Select(x => new
                {
                    FullName = $"{x.FirstName} {x.LastName}"
                })
                .ToList();

            var sb = new StringBuilder();

            foreach (var author in authors)
            {
                sb.AppendLine(author.FullName);
            }

            return sb.ToString().TrimEnd();

        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context.Books
                .ToList()
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToList();

            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().TrimEnd();

        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var bookByAuthor = context.Books
                .ToList()
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .Select(b => new
                {
                    b.BookId,
                    b.Title,
                    AuthorFullName = $"{b.Author.FirstName} {b.Author.LastName}"
                })
                .OrderBy(x => x.BookId)
                .ToList();

            var sb = new StringBuilder();

            foreach (var book in bookByAuthor)
            {
                sb.AppendLine($"{book.Title} ({book.AuthorFullName})");
            }

            return sb.ToString().TrimEnd();
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var booksToRemove = context.Books
                .ToList()
                .Where(x => x.Copies < 4200)
                .ToList();
            
            context.Books.RemoveRange(booksToRemove);

            context.SaveChanges();
            return booksToRemove.Count;
        }
    }
}
