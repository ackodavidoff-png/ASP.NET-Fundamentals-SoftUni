using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class CarsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
