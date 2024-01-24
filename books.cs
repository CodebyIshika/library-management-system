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
            try
            {
                Dictionary<string, string> userBooks = new Dictionary<string, string>();

                Console.Write("Enter the title of the book: ");
                string title = Console.ReadLine();
                userBooks["Title"] = char.ToUpper(title[0]) + title.Substring(1);

                Console.Write("Enter the author name: ");
                string author = Console.ReadLine();
                userBooks["Author"] = char.ToUpper(author[0]) + author.Substring(1);

                while (true)
                {
                    Console.Write("Enter the publication year: ");
                    if (int.TryParse(Console.ReadLine(), out int publishedYear))
                    {
                        userBooks["PublishedYear"] = publishedYear.ToString();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input for publication year. Please enter a valid year.");
                    }
                }

                Console.Write("Enter the Genre: ");
                string genre = Console.ReadLine();
                userBooks["Genre"] = char.ToUpper(genre[0]) + genre.Substring(1);

                userBooks["IsBookAvailable"] = "Yes";

                library.Add(bookId, userBooks);
                Console.WriteLine("The book is added successfully!");
                bookId++;
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void DisplayDetailsOfBook(int bookId, Dictionary<string, string> book)
        {
            Console.WriteLine(
                $"ID: {bookId}, " +
                $"Title: {char.ToUpper(book["Title"][0]) + book["Title"].Substring(1)}, " +
                $"Author: {char.ToUpper(book["Author"][0]) + book["Author"].Substring(1)}, " +
                $"Year: {book["PublishedYear"]}," +
                $" Genre: {char.ToUpper(book["Genre"][0]) + book["Genre"].Substring(1)}"
                );
        }

        public void DisplayLibraryCatalog()
        {
            try
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
                        throw new FormatException("Invalid input. Please enter a number.");
                    }
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
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
            try
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
                    throw new Exception($"Sorry, no book of '{genre}' is present in library.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
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
                            throw new Exception("Invalid input. Please enter a valid ID.");
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 3.");
                        break;
                }

            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Please enter a valid choice.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }

        public void SearchBooksByTitle(string title)
        {
            try
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
                    throw new Exception($"Sorry, no books with '{title}' title is found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }

        }

        public void SearchBooksByAuthor(string author)
        {
            try
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
                    throw new Exception($"Sorry, no books by '{author}' is found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }

        }

        public void SearchBooksById(int id)
        {
            try
            {
                if (library.ContainsKey(id))
                {
                    Console.WriteLine($"Book found with ID {id}:");
                    DisplayDetailsOfBook(id, library[id]);
                }
                else
                {
                    throw new Exception($"Sorry, no book is found with ID {id}.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }

        public void BorrowBookFromLibrary()
        {
            try
            {
                Console.Write("Enter the ID of the book that you want to borrow: ");

                if (int.TryParse(Console.ReadLine(), out int bookId))
                {
                    if (library.ContainsKey(bookId))
                    {
                        if (library[bookId]["IsBookAvailable"].ToLower() == "yes")
                        {
                            library[bookId]["IsBookAvailable"] = "No";
                            Console.WriteLine($"Book with ID {bookId} has been borrowed successfully.");
                        }
                        else
                        {
                            throw new Exception($"The book with ID {bookId} is already borrowed.");
                        }
                    }
                    else
                    {
                        throw new Exception($"No book is found with ID {bookId}.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid ID.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void ReturnBookToLibrary()
        {
            try
            {
                Console.Write("Enter the ID of the book that you have to return: ");

                if (int.TryParse(Console.ReadLine(), out int bookId))
                {
                    if (library.ContainsKey(bookId))
                    {
                        if (library[bookId]["IsBookAvailable"].ToLower() == "no")
                        {
                            library[bookId]["IsBookAvailable"] = "Yes";
                            Console.WriteLine($"Book with ID {bookId} has been returned successfully.");
                        }
                        else
                        {
                            throw new Exception($"The book with ID {bookId} is not currently borrowed.");
                        }
                    }
                    else
                    {
                        throw new Exception($"No book is found with ID {bookId}.");
                    }
                }
                else
                {
                    throw new Exception("Invalid input. Please enter a valid ID.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
