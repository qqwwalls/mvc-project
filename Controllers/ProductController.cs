using Microsoft.AspNetCore.Mvc;
using mvc.Models;
using mvc.Services;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System;

namespace mvc.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _productService;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public ProductController(IProductService productService, IWebHostEnvironment webHostEnvironment)
    {
        _productService = productService;
        _webHostEnvironment = webHostEnvironment;
    }

    public IActionResult Index()
    {
        var products = _productService.GetAll();
        return View(products);
    }

    public IActionResult Details(int id)
    {
        var product = _productService.GetById(id);
        if (product == null) return NotFound();
        return View(product);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Product product)
    {
        if (ModelState.IsValid)
        {
            if (product.ImageFile != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images/products");
                Directory.CreateDirectory(uploadsFolder);
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + product.ImageFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await product.ImageFile.CopyToAsync(fileStream);
                }
                product.ImageUrl = "/images/products/" + uniqueFileName;
            }

            _productService.Create(product);
            return RedirectToAction(nameof(Index));
        }
        return View(product);
    }

    public IActionResult Edit(int id)
    {
        var product = _productService.GetById(id);
        if (product == null) return NotFound();
        return View(product);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Product product)
    {
        if (id != product.Id) return NotFound();

        if (ModelState.IsValid)
        {
            if (product.ImageFile != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images/products");
                Directory.CreateDirectory(uploadsFolder);
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + product.ImageFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await product.ImageFile.CopyToAsync(fileStream);
                }
                product.ImageUrl = "/images/products/" + uniqueFileName;
            }
            else
            {
                var existingProduct = _productService.GetById(id);
                if (existingProduct != null)
                {
                    product.ImageUrl = existingProduct.ImageUrl;
                }
            }

            _productService.Update(product);
            return RedirectToAction(nameof(Index));
        }
        return View(product);
    }

    public IActionResult Delete(int id)
    {
        var product = _productService.GetById(id);
        if (product == null) return NotFound();
        return View(product);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        _productService.Delete(id);
        return RedirectToAction(nameof(Index));
    }
}
