using Microsoft.AspNetCore.Mvc;

namespace Helendo_Back.Controllers;

public class CartController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
