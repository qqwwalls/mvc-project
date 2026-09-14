using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mvc.Models;

namespace mvc.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Contacts()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult SolveQuadratic(double a, double b, double c)
    {
        if (a == 0)
        {
            return Content("Коефіцієнт 'a' не може бути рівним 0 для квадратного рівняння.");
        }

        double discriminant = b * b - 4 * a * c;

        if (discriminant > 0)
        {
            double x1 = (-b + System.Math.Sqrt(discriminant)) / (2 * a);
            double x2 = (-b - System.Math.Sqrt(discriminant)) / (2 * a);
            return Content($"Корені дійсні та різні: x1 = {x1}, x2 = {x2}");
        }
        else if (discriminant == 0)
        {
            double x = -b / (2 * a);
            return Content($"Корені дійсні та однакові: x1 = x2 = {x}");
        }
        else
        {
            return Content("Корені комплексні (дійсних коренів немає).");
        }
    }
}
