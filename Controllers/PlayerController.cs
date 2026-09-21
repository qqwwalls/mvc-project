using Microsoft.AspNetCore.Mvc;
using mvc.Models;

namespace mvc.Controllers;

public class PlayerController : Controller
{
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Player player)
    {
        if (!ModelState.IsValid)
        {
            return new HtmlResult("<h2>У тебе є помилки!</h2>");
        }
        
        return Content($"Login: {player.Login} Email: {player.Email} Age: {player.Age}");
    }
}
