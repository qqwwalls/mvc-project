using System.Collections.Generic;
using System.Linq;
using mvc.Models;

namespace mvc.Services;

public class CategoryService : ICategoryService
{
    private readonly ShopDbContext _context;

    public CategoryService(ShopDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Category> GetAll()
    {
        return _context.Categories.ToList();
    }
}
