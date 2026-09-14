using Microsoft.AspNetCore.Mvc;
using mvc.Models;
using System.Linq;

namespace mvc.Controllers;

public class ProductController : Controller
{
    private readonly ShopDbContext _context;

    public ProductController(ShopDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var products = _context.Products.ToList();
        return View(products);
    }
}
