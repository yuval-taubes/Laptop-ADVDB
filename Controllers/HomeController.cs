using Laptop.Data;
using Laptop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Laptop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly LaptopContext _context;

        public HomeController(ILogger<HomeController> logger, LaptopContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            if (_context.Laptop.Count() < 1)
            {
                _context.Add(new Brand() { Name = "Dell" });
                _context.Add(new Brand() { Name = "HP" });
                _context.Add(new Brand() { Name = "Lenovo" });
                _context.Add(new Brand() { Name = "Asus" });
                _context.Add(new Brand() { Name = "Acer" });
                _context.Add(new Brand() { Name = "Microsoft" });
                _context.Add(new Brand() { Name = "Razer" });
                _context.Add(new Brand() { Name = "Apple" });
                _context.Add(new Brand() { Name = "LG" });
                _context.Add(new Brand() { Name = "Samsung" });
                _context.SaveChanges();

                _context.Add(new LaptopObject() { Model = "Inspiron 15", BrandId = 1, BrandName = "Dell", Price = 699, Year = 2022 });
                _context.Add(new LaptopObject() { Model = "Pavilion x360", BrandId = 2, BrandName = "HP", Price = 899, Year = 2021 });
                _context.Add(new LaptopObject() { Model = "ThinkPad X1 Carbon", BrandId = 3, BrandName = "Lenovo", Price = 1499, Year = 2022 });
                _context.Add(new LaptopObject() { Model = "ZenBook Pro 15", BrandId = 4, BrandName = "Asus", Price = 1299, Year = 2021 });
                _context.Add(new LaptopObject() { Model = "Swift 3", BrandId = 5, BrandName = "Acer", Price = 599, Year = 2022 });
                _context.Add(new LaptopObject() { Model = "Surface Laptop 4", BrandId = 6, BrandName = "Microsoft", Price = 1099, Year = 2021 });
                _context.Add(new LaptopObject() { Model = "Blade 15", BrandId = 7, BrandName = "Razer", Price = 1999, Year = 2022 });
                _context.Add(new LaptopObject() { Model = "MacBook Pro", BrandId = 8, BrandName = "Apple", Price = 1499, Year = 2021 });
                _context.Add(new LaptopObject() { Model = "Gram 14", BrandId = 9, BrandName = "LG", Price = 1199, Year = 2022 });
                _context.Add(new LaptopObject() { Model = "Galaxy Book Pro 360", BrandId = 10, BrandName = "Samsung", Price = 1299, Year = 2021 });

                _context.SaveChanges();

            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}