using System.Collections.Generic;
using System.Linq;

public class CategoryService
{
    private readonly OracleDbContext _dbContext;

    public CategoryService(OracleDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Category> GetAllCategories()
    {
        return _dbContext.Categories.ToList();
    }

    public Category GetCategoryById(int categoryId)
    {
        return _dbContext.Categories.FirstOrDefault(c => c.CategoryId == categoryId);
    }

    public void AddCategory(Category category)
    {
        _dbContext.Categories.Add(category);
        _dbContext.SaveChanges();
    }

    public void UpdateCategory(Category category)
    {
        _dbContext.Categories.Update(category);
        _dbContext.SaveChanges();
    }

    public void DeleteCategory(int categoryId)
    {
        var category = _dbContext.Categories.FirstOrDefault(c => c.CategoryId == categoryId);
        if (category != null)
        {
            _dbContext.Categories.Remove(category);
            _dbContext.SaveChanges();
        }
    }
}
