using Microsoft.AspNetCore.Mvc;
using mvc.Services;

namespace mvc.Controllers;

public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public IActionResult Index()
    {
        var categories = _categoryService.GetAll();
        return View(categories);
    }
}
