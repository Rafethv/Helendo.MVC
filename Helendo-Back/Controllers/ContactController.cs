using Microsoft.AspNetCore.Mvc;

namespace Helendo_Back.Controllers;

public class ContactController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
