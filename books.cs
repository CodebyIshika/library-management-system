using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    internal class Books
    {
        Dictionary<int, Dictionary<string, string>> library = new Dictionary<int, Dictionary<string, string>>();
        int bookId = 1;

        public void AddBooksToLibrary()
        {
            Dictionary<string, string> userBooks = new Dictionary<string, string>();

            Console.Write("Enter the title of the book: ");
            userBooks["Title"] = Console.ReadLine();

            Console.Write("Enter the author name: ");
            userBooks.Add("Author", Console.ReadLine());

            Console.Write("Enter the publication year: ");
            userBooks["PublishedYear"] = Console.ReadLine();

            Console.Write("Enter the Genre: ");
            userBooks["Genre"] = Console.ReadLine();

            library.Add(bookId, userBooks);
            Console.WriteLine("The book is added successfully!");
            bookId++;
        }

        public void DisplayLibraryCatalog()
        {
            if (library.Count == 0)
            {
                Console.WriteLine("Sorry, no books are present in library.");
            }
            else
            {
                Console.WriteLine("Libray Catalog : ");
                Console.WriteLine("1. View all the books");
                Console.WriteLine("2. Views Books by Genre");
                Console.Write("Enter your choice (1-2) : ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            DisplayAllBooks();
                            break;
                        case 2:
                            Console.Write("Enter the genre: ");
                            string genre = Console.ReadLine();
                            DisplayBooksByGenre(genre);
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please enter 1 or 2.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }

        }

        public void DisplayDetailsOfBook(int bookId, Dictionary<string, string> book)
        {
            Console.WriteLine($"ID: {bookId}, Title: {book["Title"]}, Author: {book["Author"]}, Year: {book["PublishedYear"]}, Genre: {book["Genre"]}");
        }

        public void DisplayAllBooks()
        {
            Console.WriteLine("Libray Catalog : ");
            foreach (var book in library)
            {
                DisplayDetailsOfBook(book.Key, book.Value);
            }
        }

        public void DisplayBooksByGenre(string genre)
        {
            Console.WriteLine($"Books in '{genre}' genre : ");
            bool isBookFound = false;

            foreach (var book in library)
            {
                if (book.Value["Genre"].ToLower() == genre.ToLower())
                {
                    DisplayDetailsOfBook(book.Key, book.Value);
                    isBookFound = true;
                }
            }

            if (!isBookFound)
            {
                Console.WriteLine($"Sorry, no book of '{genre}' is present in library.");
            }
        }

        public void SearchBooks()
        {
            try
            {
                Console.WriteLine("Search Books: ");
                Console.WriteLine("1. Search by Title");
                Console.WriteLine("2. Search by Author");
                Console.WriteLine("3. Search by ID");
                Console.Write("Enter your choice (1-3): ");

                int userSearchChoice = int.Parse(Console.ReadLine());

                switch (userSearchChoice)
                {
                    case 1:
                        Console.Write("Enter the title of the book: ");
                        string bookByTitle = Console.ReadLine();
                        SearchBooksByTitle(bookByTitle);
                        break;

                    case 2:
                        Console.Write("Enter the author of the book: ");
                        string bookByAuthor = Console.ReadLine();
                        SearchBooksByAuthor(bookByAuthor);
                        break;

                    case 3:
                        Console.Write("Enter the ID of the book: ");
                        if (int.TryParse(Console.ReadLine(), out int bookByID))
                        {
                            SearchBooksById(bookByID);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid ID.");
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 3.");
                        break;
                }

            }
            catch (FormatException)
            {
                Console.WriteLine("");
                Console.WriteLine("Error: Please enter a valid choice.");
            }
        }

        public void SearchBooksByTitle(string title)
        {
            bool isBookFound = false;

            foreach (var book in library)
            {
                if (book.Value["Title"].ToLower().Contains(title.ToLower()))
                {
                    DisplayDetailsOfBook(book.Key, book.Value);
                    isBookFound = true;
                }
            }

            if (!isBookFound)
            {
                Console.WriteLine($"Sorry, no books with '{title}' title is found.");
            }
        }

        public void SearchBooksByAuthor(string author)
        {
            bool isBookFound = false;

            foreach (var book in library)
            {
                if (book.Value["Author"].ToLower().Contains(author.ToLower()))
                {
                    DisplayDetailsOfBook(book.Key, book.Value);
                    isBookFound = true;
                }
            }

            if (!isBookFound)
            {
                Console.WriteLine($"Sorry, no books by '{author}' is found.");
            }
        }

        public void SearchBooksById(int id)
        {
            if (library.ContainsKey(id))
            {
                Console.WriteLine($"Book found with ID {id}:");
                DisplayDetailsOfBook(id, library[id]);
            }
            else
            {
                Console.WriteLine($"Sorry, no book is found with ID {id}.");
            }
        }
    }
}
