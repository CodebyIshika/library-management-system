# Library Management System

## Overview
This is a simple Library Management System console application written in C#. It allows users to add books to 
the library, view the catalog, search for books, borrow, and return books.

## Features
### 1. Add the book
- Add the new book to the library catalog by collecting details about the title, author, publication year and genre of the book.

### 2. View Books
- First ask the user to choose an option between view all books and view books filter by genre.
- **View All Books:**
   - When user select view all the books option, it displays the details of all the books that are present in the library catalog.
- **View by Genre:**
    - When user select view by genre options, then it ask the genre of the book and display details of the books of that specific genre.

### 3. Search Books
- It allows the user to search for books based on title, author and ID of the book.
- **Search by Title:**
    - When user choose the option of search by title then it displays the details of the book of that particular title.
- **Search by Author:**
    - When user choose the option of search by author then it displays the details of all the books by that specific author.
- **Search by ID:**
    - When user choose the option of search by id then it displays the details of the book of that particular id.

### 4. Borrow Book
- When user choose the option of borrowing the book then it asks the ID of the book.
- Checks if the book with the specified ID is available and not already borrowed.
- If the book is available then it displays the message of boorowing that book.

### 5. Return Book
- When user choose the option of returning the book then it asks the ID of the book.
- Checks if the book with the specified ID is currently borrowed.
- Then displays the message if book  is returned successfully.

## Design Decision
The application follows a simple console-based design to ensure user-friendly interaction.
I have used Dictionary<int, Dictionary<string, string>> as the main data structure to store book details and each book is uniquely identified by an ID.

## Challenges Faced
### Book Availability
I challenge was to control the borrowing and returning of books to avoid any problems like multiple borrowing. To address this, I have used 'IsBookAvailable' 
in my codes to keep track of whether a book is available for borrowing by storing the status as "Yes" or "No" in the book details. When a user attempts 
to borrow a book, the application checks this status to ensure the book is currently available. Similarly, when a user returns a book, the application 
verifies that the book is marked as borrowed. This straightforward mechanism helps prevent scenarios where a book might be borrowed by multiple users 
simultaneously or returned when not borrowed at all. 

### Selecting an appropriate Data Structure
The challenge here was to find a data structure that would allow for efficient storage, retrieval, and modification of book details. To address this, I have used
nested dictionary within a dictionary. This allows each book  to be uniquely identified by a book ID, and the nested dictionary stores details like title, author, 
publication year, genre, and book availability. This dictionary makes book information easy to access and update.

## Algorithm Implemented
This application uses a linear search for searching books by title, author or ID. I had decided to use linear search as it doesn't require the dataset to be sorted.
- **Search by Title:**
     - Iterates through the library catalog to find books with a matching title.
- **Search by Author:**
     - Checks each book in the catalog to identify those written by the specified author.
- **Search by ID:**
     - Checks through the library to locate a book with the given ID.

