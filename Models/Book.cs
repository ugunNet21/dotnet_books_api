public class Book
{
    public int BookId { get; set; }
    public string Title { get; set; }
    public int CategoryId { get; set; }
    public decimal Price { get; set; }
}

public class Category
{
    public int CategoryId { get; set; }
    public string Name { get; set; }
}
