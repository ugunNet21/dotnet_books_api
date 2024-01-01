using System.Collections.Generic;
using System.Linq;

public class BookService
{
    private readonly OracleDbContext _dbContext;

    public BookService(OracleDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Book> GetAllBooks()
    {
        return _dbContext.Books.ToList();
    }

    public Book GetBookById(int bookId)
    {
        return _dbContext.Books.FirstOrDefault(b => b.BookId == bookId);
    }

    public void AddBook(Book book)
    {
        _dbContext.Books.Add(book);
        _dbContext.SaveChanges();
    }

    public void UpdateBook(Book book)
    {
        _dbContext.Books.Update(book);
        _dbContext.SaveChanges();
    }

    public void DeleteBook(int bookId)
    {
        var book = _dbContext.Books.FirstOrDefault(b => b.BookId == bookId);
        if (book != null)
        {
            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
        }
    }
}
