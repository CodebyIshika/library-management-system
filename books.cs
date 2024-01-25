using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    internal class Books
    {
        // creates a library to store the information about the books in the library
        Dictionary<int, Dictionary<string, string>> library = new Dictionary<int, Dictionary<string, string>>();
        int bookId = 1;

        /// <summary>
        /// This method adds a new book to the library catalog by collecting details from user about the title,
        /// author, publication year and genre of the book.
        /// </summary>
        public void AddBooksToLibrary()
        {
            try
            {
                // dictionary to store the details of the book
                Dictionary<string, string> userBooks = new Dictionary<string, string>();


                Console.Write("Enter the title of the book: ");
                string title = Console.ReadLine();
                userBooks["Title"] = char.ToUpper(title[0]) + title.Substring(1);

                Console.Write("Enter the author name: ");
                string author = Console.ReadLine();
                userBooks["Author"] = char.ToUpper(author[0]) + author.Substring(1);

                // validate the publication year by checking if the int is passed 
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

                // make the book available for borrowing
                userBooks["IsBookAvailable"] = "Yes";

                library.Add(bookId, userBooks);
                Console.WriteLine("The book is added successfully!");

                // increment the book id for next book
                bookId++;
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }


        /// <summary>
        /// This method displays the details of the books that are present in library catalog
        /// </summary>
        /// <param name="bookId"></param>
        /// <param name="book"></param>
        public void DisplayDetailsOfBook(int bookId, Dictionary<string, string> book)
        {
            Console.WriteLine(
                $"ID: {bookId} | " +
                $"Title: {char.ToUpper(book["Title"][0]) + book["Title"].Substring(1)} | " +
                $"Author: {char.ToUpper(book["Author"][0]) + book["Author"].Substring(1)} | " +
                $"Year: {book["PublishedYear"]} | " +
                $" Genre: {char.ToUpper(book["Genre"][0]) + book["Genre"].Substring(1)}"
                );
        }

        /// <summary>
        /// This method displays the option to view the all books of library or 
        /// to view the books by genre
        /// </summary>
        public void DisplayLibraryCatalog()
        {
            try
            {
                // check if library is empty or not
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

                    // work according to the user choice
                    if (int.TryParse(Console.ReadLine(), out int choice))
                    {
                        switch (choice)
                        {
                            // display all the books
                            case 1:
                                Console.WriteLine("");
                                DisplayAllBooks();
                                break;

                            // display books by genre
                            case 2:
                                Console.Write("Enter the genre: ");
                                string genre = Console.ReadLine();
                                Console.WriteLine("");
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

        
        /// <summary>
        /// This method display details of all the books
        /// </summary>
        public void DisplayAllBooks()
        {
            Console.WriteLine("Libray Catalog : ");
            foreach (var book in library)
            {
                DisplayDetailsOfBook(book.Key, book.Value);
            }
        }

        /// <summary>
        /// This method display the details of the books of a specific genre
        /// </summary>
        /// <param name="genre"></param>
        public void DisplayBooksByGenre(string genre)
        {
            try
            {
                Console.WriteLine($"Books in '{genre}' genre : ");
                bool isBookFound = false;

                // Iterate through the library to find books in the specified genre
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


        /// <summary>
        /// This method allows the user to search for books based on title, author or ID.
        /// </summary>
        public void SearchBooks()
        {
            try
            {
                // ask the user to choose an option 
                Console.WriteLine("Search Books: ");
                Console.WriteLine("1. Search by Title");
                Console.WriteLine("2. Search by Author");
                Console.WriteLine("3. Search by ID");
                Console.Write("Enter your choice (1-3): ");

                int userSearchChoice = int.Parse(Console.ReadLine());

                // Execute the chosen search method based on user input
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

        /// <summary>
        /// This method searches for the book by the title and displays it details if any match is found.
        /// </summary>
        /// <param name="title"></param>
        public void SearchBooksByTitle(string title)
        {
            try
            {
                bool isBookFound = false;

                // Iterate through the library to find books with user mentioned title
                foreach (var book in library)
                {
                    if (book.Value["Title"].ToLower().Contains(title.ToLower()))
                    {
                        DisplayDetailsOfBook(book.Key, book.Value);
                        isBookFound = true;
                    }
                }

                // Throw an error if no book is found with the specified title
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

        /// <summary>
        /// This method searches for the book by the author and displays it details if any match is found.
        /// </summary>
        /// <param name="author"></param>
        public void SearchBooksByAuthor(string author)
        {
            try
            {
                bool isBookFound = false;

                // Iterate through the library to find books by user mentioned author
                foreach (var book in library)
                {
                    if (book.Value["Author"].ToLower().Contains(author.ToLower()))
                    {
                        DisplayDetailsOfBook(book.Key, book.Value);
                        isBookFound = true;
                    }
                }

                // Throw an error if no book is found by the specified author
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

        /// <summary>
        /// This method searches for the book by the id and displays it details if any match is found.
        /// </summary>
        /// <param name="id"></param>
        public void SearchBooksById(int id)
        {
            try
            {
                // Check if the library contains a book with the user mentioned ID
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


        /// <summary>
        /// This method allows the user to borrow the book from the library by providing the book's ID.
        /// </summary>
        public void BorrowBookFromLibrary()
        {
            try
            {
                // ask the user book's ID
                Console.Write("Enter the ID of the book that you want to borrow: ");

                if (int.TryParse(Console.ReadLine(), out int borrowBookId))
                {
                    // Check if the library contains a book with the specified ID
                    if (library.ContainsKey(borrowBookId))
                    {
                        // Check if the book is currently available for borrowing
                        if (library[borrowBookId]["IsBookAvailable"].ToLower() == "yes")
                        {
                            // Update the book's status to indicate it has been borrowed
                            library[borrowBookId]["IsBookAvailable"] = "No";
                            Console.WriteLine($"Book with ID {borrowBookId} has been borrowed successfully.");
                        }
                        else
                        {
                            // Throw an exception if the book is already borrowed
                            throw new Exception($"The book with ID {borrowBookId} is already borrowed.");
                        }
                    }
                    else
                    {
                        // Throw an exception if no book is found with the specified ID
                        throw new Exception($"No book is found with ID {borrowBookId}.");
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


        /// <summary>
        /// This method allow the user to return a borrowed book back to the library by providing the book's ID.
        /// </summary>
        public void ReturnBookToLibrary()
        {
            try
            {
                // ask the user book ID
                Console.Write("Enter the ID of the book that you have to return: ");

                if (int.TryParse(Console.ReadLine(), out int returnBookId))
                {
                    // Check if the library contains a book with the specified ID
                    if (library.ContainsKey(returnBookId))
                    {
                        // Check if the book is currently borrowed
                        if (library[returnBookId]["IsBookAvailable"].ToLower() == "no")
                        {
                            // Update the book's status to indicate it has been returned
                            library[returnBookId]["IsBookAvailable"] = "Yes";
                            Console.WriteLine($"Book with ID {returnBookId} has been returned successfully.");
                        }
                        else
                        {
                            // Throw an exception if the book is not currently borrowed
                            throw new Exception($"The book with ID {returnBookId} is not currently borrowed.");
                        }
                    }
                    else
                    {
                        // Throw an exception if no book is found with the specified ID
                        throw new Exception($"No book is found with ID {returnBookId}.");
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
