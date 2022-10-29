using Microsoft.AspNetCore.Mvc;

namespace Helendo_Back.Controllers;

public class WishlistController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
