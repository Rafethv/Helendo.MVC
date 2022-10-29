using Microsoft.AspNetCore.Mvc;

namespace Helendo_Back.Controllers;

public class BlogController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Detail()
    {
        return View();
    }
}
