using Microsoft.AspNetCore.Mvc;

namespace Helendo_Back.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
