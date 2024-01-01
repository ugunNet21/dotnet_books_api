using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly BookService _bookService;

    public BookController(BookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public IActionResult GetAllBooks()
    {
        var books = _bookService.GetAllBooks();
        return Ok(books);
    }

    [HttpGet("{id}")]
    public IActionResult GetBookById(int id)
    {
        var book = _bookService.GetBookById(id);
        if (book == null)
        {
            return NotFound();
        }
        return Ok(book);
    }

    [HttpPost]
    public IActionResult AddBook([FromBody] Book book)
    {
        _bookService.AddBook(book);
        return CreatedAtAction(nameof(GetBookById), new { id = book.BookId }, book);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateBook(int id, [FromBody] Book book)
    {
        var existingBook = _bookService.GetBookById(id);
        if (existingBook == null)
        {
            return NotFound();
        }
        book.BookId = id;
        _bookService.UpdateBook(book);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteBook(int id)
    {
        var existingBook = _bookService.GetBookById(id);
        if (existingBook == null)
        {
            return NotFound();
        }
        _bookService.DeleteBook(id);
        return NoContent();
    }
}
