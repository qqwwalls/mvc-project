using System.Collections.Generic;
using System.Linq;
using mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace mvc.Services;

public class ProductService : IProductService
{
    private readonly ShopDbContext _context;

    public ProductService(ShopDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Product> GetAll()
    {
        return _context.Products.ToList();
    }

    public Product? GetById(int id)
    {
        return _context.Products.FirstOrDefault(p => p.Id == id);
    }

    public void Create(Product product)
    {
        product.CreatedAt = DateTime.Now;
        product.UpdatedAt = DateTime.Now;
        _context.Products.Add(product);
        _context.SaveChanges();
    }

    public void Update(Product product)
    {
        product.UpdatedAt = DateTime.Now;
        _context.Products.Update(product);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var product = _context.Products.FirstOrDefault(p => p.Id == id);
        if (product != null)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
    }
}
