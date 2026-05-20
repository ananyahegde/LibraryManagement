using LibraryManagement.Models;
using LibraryManagement.Contexts;

namespace LibraryManagement.Repositories
{
    public class BookRepository : IRepository<Book, int>
    {
        private readonly LibraryDbContext _context;
        public BookRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public Book Create(Book book)
        {
            _context.Add(book);
            _context.SaveChanges();
            return book;
        }

        public List<Book>? ReadAll()
        {
            return _context.Set<Book>().ToList();
        }

        public Book? Read(int key)
        {
            return _context.Books.Find(key);
        }

        public Book? Update(Book book, int key)
        {
            var existing = Read(key);
            if (existing == null)
                throw new Exception("Book not found.");
            _context.Update(book);
            _context.SaveChanges();
            return existing;
        }

        public Book? Delete(int key)
        {
            var existing = Read(key);
            if (existing == null)
                throw new Exception("Book not found.");
            _context.Remove(existing);
            _context.SaveChanges();
            return existing;
        }
    }
}
