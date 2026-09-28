using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Data.Models;
using WebApplication1.ViewModels;
using static WebApplication1.Common.ApplicationConstraints;

namespace WebApplication1.Controllers
{
    public class CarController : Controller
    {
        private readonly ApplicationDbContext context;
        public CarController(ApplicationDbContext applicationDbContext)
        {
            this.context = applicationDbContext;
        }
        public IActionResult Index()
        {
            IEnumerable<Car> cars = context.Cars.Take(MaxEntitiesPerPage).ToArray();
            return View(cars);
        }
        public IActionResult NoCars()
        {
            return View();
        }
        public IActionResult Details(int id)
        {
            Car? car = context.Cars.Include(c => c.Seller).FirstOrDefault(c => c.Id == id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }
        [HttpGet]
        public IActionResult Create()
        {
            IEnumerable<SelectListItem> users = context.ApplicationUsers.Select(au => new SelectListItem()
            {
                Value = au.Id.ToString(),
                Text = au.Username
            }).ToList();
            ViewBag.Users = users;
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateCarViewModel carModel)
        {
            Car car = new Car()
            {
                Brand = carModel.Brand,
                Model = carModel.Model,
                Year = carModel.Year,
                Price = carModel.Price,
                Mileage = carModel.Mileage,
                EngineType = carModel.EngineType,
                TransmissionType = carModel.TransmissionType,
                HorsePower = carModel.HorsePower,
                ImageUrl = carModel.ImageUrl,
                State = carModel.State,
                Description = carModel.Description,
                SellerId = carModel.SellerId,
                CreatedOn = DateTime.Now
            };
            context.Cars.Add(car);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Search(string? searchText)
        {
            if(searchText == null || searchText == "")
            {
                return RedirectToAction(nameof(Index));
            }
            IEnumerable<Car> carsFound = context.Cars.Include(c => c.Seller).Where(c => c.Brand.ToLower().Contains(searchText.ToLower())).Take(MaxEntitiesPerPage).ToArray();
            return View(carsFound);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Car? car = context.Cars.FirstOrDefault(c => c.Id == id);
            if (car == null)
            {
                return NotFound();
            }
            //var userId = userManager.GetUserId(User);
            //if (car.SellerId.ToString() != userId)
            //{
            //    return Unauthorized();
            //}
            return View(car);
        }
        [HttpPost]
        public IActionResult Edit(int id, Car c)
        {
            //validating the car
            if (id != c.Id)
            {
                return BadRequest();
            }
            Car? car = context.Cars.FirstOrDefault(c => c.Id == id);
            //checking if the car exists
            if (car == null)
            {
                return NotFound();
            }
            //var userId = userManager.GetUserId(User);
            //if (car.SellerId.ToString() != userId)
            //{
            //    return Unauthorized();
            //}
            //setting the car new properties
            car.Brand = c.Brand;
            car.Model = c.Model;
            car.Year = c.Year;
            car.Price = c.Price;
            car.Mileage = c.Mileage;
            car.EngineType = c.EngineType;
            car.TransmissionType = c.TransmissionType;
            car.HorsePower = c.HorsePower;
            car.ImageUrl = c.ImageUrl;
            car.State = c.State;
            car.Description = c.Description;
            context.SaveChanges();
            return RedirectToAction(nameof(Details), new Car() { Id = car.Id });
        }
    }
}
