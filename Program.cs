using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Books libraryObj = new Books();

            while(true)
            {
                try
                {
                    Console.WriteLine("\n=== Library Management System ===");
                    Console.WriteLine("1. Add Book");
                    Console.WriteLine("2. View Books");
                    Console.WriteLine("3. Search Books");
                    Console.WriteLine("4. Borrow Book");
                    Console.WriteLine("5. Return Book");
                    Console.WriteLine("6. Exit");

                    Console.Write("Enter your choice (1-6) : ");
                    int userChoice = int.Parse(Console.ReadLine());

                    switch(userChoice)
                    {
                        case 1:
                            Console.Clear();
                            libraryObj.AddBooksToLibrary();
                            break;

                        case 2:
                            Console.Clear();
                            libraryObj.DisplayLibraryCatalog();
                            break;

                        case 3:
                            Console.Clear();
                            libraryObj.SearchBooks();
                            break;

                        case 4:
                            Console.Clear();
                            libraryObj.BorrowBookFromLibrary();
                            break;

                        case 5:
                            Console.Clear();
                            libraryObj.ReturnBookToLibrary();
                            break;

                        case 6:
                            Environment.Exit(0);
                            break;

                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Please enter a valid choice.");
                }
            }

            Console.ReadKey();
        }
    }
}
