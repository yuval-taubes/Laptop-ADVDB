using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Laptop.Data;
using Laptop.Models;
using Laptop.Models.ViewModels;

namespace Laptop.Controllers
{
    public class LaptopsController : Controller
    {
        private readonly LaptopContext _context;

        public LaptopsController(LaptopContext context)
        {
            _context = context;

            
        }

        // GET: Laptops
        public async Task<IActionResult> Index()
        {
            return View(await _context.Laptop.ToListAsync());
        }

        // GET: Laptops/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Laptop == null)
            {
                return NotFound();
            }

            var laptop = await _context.Laptop
                .FirstOrDefaultAsync(m => m.Id == id);

            if (laptop == null)
            {
                return NotFound();
            }

            return View(laptop);
        }

        // GET: Laptops/Create
        public IActionResult Create()
        {
            LaptopCRUD vm = new LaptopCRUD();
            vm.Brands = _context.Brand.ToList();
            return View(vm);
        }

        // POST: Laptops/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LaptopCRUD vm)
        {
            vm.Brands = _context.Brand.ToList();

            LaptopObject laptop = new LaptopObject();
            laptop.Model = vm.Model;
            laptop.Price = vm.Price;
            laptop.Year = vm.Year;
            laptop.BrandId = vm.BrandId;
            laptop.BrandName = _context.Brand.First(x => x.Id == laptop.BrandId).Name;

            _context.Laptop.Add(laptop);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

            return View(vm);
        }

        // GET: Laptops/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Laptop == null)
            {
                return NotFound();
            }

            var laptop = await _context.Laptop.FindAsync(id);
            if (laptop == null)
            {
                return NotFound();
            }
            LaptopCRUD vm = new LaptopCRUD();
            vm.Brands = _context.Brand.ToList();
            return View(vm);
        }

        // POST: Laptops/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LaptopCRUD vm)
        {
            LaptopObject laptop = new LaptopObject();
            laptop.Model = vm.Model;
            laptop.Price = vm.Price;
            laptop.Year = vm.Year;
            laptop.BrandId = vm.BrandId;

            if (id != laptop.Id)
            {
                return NotFound();
            }
            try
            {
                _context.Update(laptop);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LaptopExists(laptop.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
             return RedirectToAction(nameof(Index));
        }

        // GET: Laptops/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Laptop == null)
            {
                return NotFound();
            }

            var laptop = await _context.Laptop
                .FirstOrDefaultAsync(m => m.Id == id);
            if (laptop == null)
            {
                return NotFound();
            }

            return View(laptop);
        }

        // POST: Laptops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Laptop == null)
            {
                return Problem("Entity set 'LaptopContext.Laptop'  is null.");
            }
            var laptop = await _context.Laptop.FindAsync(id);
            if (laptop != null)
            {
                _context.Laptop.Remove(laptop);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LaptopExists(int id)
        {
            return _context.Laptop.Any(e => e.Id == id);
        }

        public IActionResult ExpensiveLaptop()
        {
            List<LaptopObject> sortedByPrice = _context.Laptop.OrderByDescending(x => x.Price).Take(2).ToList();
            return View(sortedByPrice);
        }
        public IActionResult CheapestLaptop()
        {
            List<LaptopObject> sortedByPrice = _context.Laptop.OrderBy(x => x.Price).Take(3).ToList();
            return View(sortedByPrice);
        }

        public IActionResult LaptopInBudget()
        {
            BudgetLaptopViewModel vm = new BudgetLaptopViewModel();
            return View(vm);
        }
        [HttpPost]
        public IActionResult LaptopInBudget(BudgetLaptopViewModel vm)
        {
            List<LaptopObject> result = _context.Laptop.Where(x => x.Price <= vm.Budget).ToList();
            vm.Result = result;
            return View(vm);
        }


        //public IActionResult CompareLaptops()
        //{
        //    CompareLaptopViewModel vm = new CompareLaptopViewModel();
        //    vm.Laptops = Database.Laptops;
        //    return View(vm);
        //}

        //[HttpPost]
        //public IActionResult CompareLaptops(CompareLaptopViewModel vm)
        //{
        //    vm.Laptops = Database.Laptops;
        //    //it says it might be null, but it wont be as its a dropdown list, meaning only allowed values will be selected
        //    vm.Laptop1 = Database.Laptops.FirstOrDefault(x => x.Id == vm.Laptop1Id);
        //    vm.Laptop2 = Database.Laptops.FirstOrDefault(x => x.Id == vm.Laptop2Id);

        //    return View(vm);
        //}
    }
}
