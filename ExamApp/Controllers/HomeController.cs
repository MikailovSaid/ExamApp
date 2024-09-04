using Microsoft.AspNetCore.Mvc;

namespace ExamApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
