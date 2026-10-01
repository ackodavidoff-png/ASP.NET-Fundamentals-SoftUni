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
            Car? car = context.Cars.Include(c => c.Seller).ThenInclude(au => au.Town).FirstOrDefault(c => c.Id == id);
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
            if (!ModelState.IsValid)
            {
                IEnumerable<SelectListItem> users = context.ApplicationUsers.Select(au => new SelectListItem()
                {
                    Value = au.Id.ToString(),
                    Text = au.Username
                }).ToList();
                ViewBag.Users = users;
                return View(carModel);
            }
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
            IEnumerable<SelectListItem> users = context.ApplicationUsers.Select(au => new SelectListItem()
            {
                Value = au.Id.ToString(),
                Text = au.Username
            }).ToList();
            ViewBag.Users = users;
            Car? car = context.Cars.Include(c => c.Seller).FirstOrDefault(c => c.Id == id);
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
        public IActionResult Edit(int id, EditCarViewModel carModel)
        {
            //validating the car
            if (id != carModel.Id)
            {
                return BadRequest();
            }
            Car? car = context.Cars.Include(c => c.Seller).FirstOrDefault(c => c.Id == id);
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
            //checking if the model state is valid
            if (!ModelState.IsValid)
            {
                ViewBag.Users = context.ApplicationUsers.Select(au => new SelectListItem()
                {
                    Value = au.Id.ToString(),
                    Text = au.Username
                });
                return View(car);
            }
            if (car.Seller == null)
            {
                return BadRequest();
            }
            //setting the car new properties
            car.Brand = carModel.Brand;
            car.Model = carModel.Model;
            car.Year = carModel.Year;
            car.Price = carModel.Price;
            car.Mileage = carModel.Mileage;
            car.EngineType = carModel.EngineType;
            car.TransmissionType = carModel.TransmissionType;
            car.HorsePower = carModel.HorsePower;
            car.ImageUrl = carModel.ImageUrl;
            car.State = carModel.State;
            car.Description = carModel.Description;
            car.SellerId = carModel.SellerId;
            car.Seller = context.ApplicationUsers.FirstOrDefault(au => au.Id == carModel.SellerId);
            //saving the changes in the context
            context.SaveChanges();
            return RedirectToAction(nameof(Details), new Car() { Id = car.Id });
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Car? carToDelete = context.Cars.FirstOrDefault(c => c.Id == id);
            if (carToDelete == null)
            {
                return NotFound();
            }
            return View(carToDelete);
        }
        [HttpPost]
        public IActionResult DeleteConfirmation(int id)
        {
            Car? carToDelete = context.Cars.FirstOrDefault(c => c.Id == id);
            if (carToDelete == null)
            {
                return NotFound();
            }
            context.Cars.Remove(carToDelete);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
