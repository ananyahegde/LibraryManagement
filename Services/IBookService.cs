using LibraryManagement.Models;

namespace LibraryManagement.Services
{
    public interface IBookService
    {
        public Book CreateBook(Book book);
        public Book ReadBook(int id);
        public List<Book> ReadAllBooks();
    }
}
