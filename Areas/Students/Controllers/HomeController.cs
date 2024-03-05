using Microsoft.AspNetCore.Mvc;

namespace COMP_1640.Areas.Students.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
