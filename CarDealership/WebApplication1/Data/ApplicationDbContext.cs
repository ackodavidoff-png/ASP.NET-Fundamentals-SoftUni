using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.Models;
using WebApplication1.Data.Models.Enums;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : IdentityDbContext//(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; } = null!;
        public virtual DbSet<Car> Cars { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=Cars4U;Trusted_Connection=True;Encrypt=false");  
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser()
            {
                Id = 1,
                FirstName = "Ivan",
                LastName = "Ivanov",
                Username = "Vankata04",
                PhoneNumber = "0888555123",
                IsAdmin = true,
            },
            new ApplicationUser()
            {
                Id = 2,
                FirstName = "Georgi",
                LastName = "Petrov",
                Username = "Go6o.petroff",
                Email = "go6opetroff@something.com",
                PhoneNumber = "0899123456",
                IsAdmin = false
            },
            new ApplicationUser()
            {
                Id = 3,
                FirstName = "Stojan",
                LastName = "Dimitrov",
                Username = "stojandmtrv",
                Email = "st_dimitrov@mail.com",
                PhoneNumber = "0887654321"
            });
            modelBuilder.Entity<Car>().HasData(new Car()
            {
                Id = 1,
                Brand = "Peugeot",
                Model = "308SW",
                Year = 2015,
                Price = 10000,
                Mileage = 150000,
                EngineType = EngineType.Diesel,
                TransmissionType = TransmissionType.Automatic,
                HorsePower = 250,
                State = State.Used,
                Description = "Real kilometres,very well preserved.This car has never been in an accident.",
                ImageUrl = "https://mobistatic4.focus.bg/mobile/photosorg/791/1/big1/11755978379305791_b1.webp",
                CreatedOn = new DateTime(2026, 9, 21),
                SellerId = 1
            },
            new Car()
            {
                Id = 2,
                Brand = "Toyota",
                Model = "Yaris",
                Year = 2018,
                Price = 4000,
                Mileage = 80000,
                EngineType = EngineType.Hybrid,
                TransmissionType = TransmissionType.Automatic,
                HorsePower = 180,
                State = State.Used,
                Description = "Very well preserved.",
                CreatedOn = new DateTime(2026, 9, 21),
                SellerId = 2
            },
            new Car()
            {
                Id = 3,
                Brand = "VW",
                Model = "Golf",
                Year = 2020,
                Price = 7000,
                Mileage = 50000,
                EngineType = EngineType.Gasoline,
                TransmissionType = TransmissionType.Manual,
                HorsePower = 250,
                State = State.Used,
                Description = "Very well preserved.The car is good for in-town and out-of-town driving.",
                CreatedOn = new DateTime(2026, 9, 21),
                SellerId = 3
            });
        }
    }
}
