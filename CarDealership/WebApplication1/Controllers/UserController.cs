using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Data.Models;

namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext context;
        public UserController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<ApplicationUser> users = this.context.ApplicationUsers.Include(au => au.Cars).OrderBy(au => au.FirstName).ThenBy(au => au.LastName).ToArray();
            return View(users);
        }
        public IActionResult Details(int id)
        {
            ApplicationUser? user = context.ApplicationUsers.Include(au => au.Cars).FirstOrDefault(au => au.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }
    }
}
