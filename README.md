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

