using LibraryManagement.Models;
using LibraryManagement.Repositories;
using LibraryManagement.Exceptions;

namespace LibraryManagement.Services
{
    public class BookService : IBookService
    {
        private readonly IRepository<Book, int> _bookRepo;
        public BookService(IRepository<Book, int> bookRepo)
        {
            _bookRepo = bookRepo;
        }

        public Book CreateBook(Book book)
        {
            if (book == null)
                throw new InvalidEntryExceptions("Book cannot be null.");
            if (book.Title == "")
                throw new InvalidEntryExceptions("Title cannot be empty.");
            if (book.Author == "")
                throw new InvalidEntryExceptions("Author cannot be empty.");
            if (book.ISBN == "")
                throw new InvalidEntryExceptions("ISBN cannot be empty.");
            if (book.PublicationYear < 1000 || book.PublicationYear > 2026)
                throw new InvalidEntryExceptions("Invalid publication year.");
            if (book.AvailableCopies < 0)
                throw new InvalidEntryExceptions("Available copies cannot be negative.");
            return _bookRepo.Create(book);
        }

        public Book ReadBook(int id)
        {
            var book = _bookRepo.Read(id);
            if (book == null)
                throw new InvalidEntryExceptions("Book not found.");
            return book;
        }

        public List<Book> ReadAllBooks()
        {
            var books = _bookRepo.ReadAll();
            if (books == null || books.Count == 0)
                throw new InvalidEntryExceptions("No books found.");
            return books;
        }
    }
}
