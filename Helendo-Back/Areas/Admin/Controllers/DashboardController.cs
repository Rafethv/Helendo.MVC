using Microsoft.AspNetCore.Mvc;

namespace Helendo_Back.Areas.Admin.Controllers
{
    [Area("admin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
