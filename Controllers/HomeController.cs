using Microsoft.AspNetCore.Mvc;

namespace SistemaAcademico.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
