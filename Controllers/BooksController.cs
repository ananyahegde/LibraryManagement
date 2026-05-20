using LibraryManagement.Models;
using Microsoft.AspNetCore.Mvc;
using LibraryManagement.Services;

namespace LibraryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost]
        public ActionResult<Book> Post(Book book)
        {
            try
            {
                var result = _bookService.CreateBook(book);
                return Created("", result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<Book> Get()
        {
            try
            {
                var books = _bookService.ReadAllBooks();
                if (books == null)
                    return NotFound("No books yet.");
                return Ok(books);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Book> GetById(int id)
        {
            var book = _bookService.ReadBook(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }
    }
}
