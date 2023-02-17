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
    public class BrandsController : Controller
    {
        private readonly LaptopContext _context;

        public BrandsController(LaptopContext context)
        {
            _context = context;
        }

        // GET: Brands
        public async Task<IActionResult> Index()
        {
              return View(await _context.Brand.ToListAsync());
        }

        // GET: Brands/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Brand == null)
            {
                return NotFound();
            }

            var brand = await _context.Brand
                .FirstOrDefaultAsync(m => m.Id == id);
            if (brand == null)
            {
                return NotFound();
            }

            return View(brand);
        }

        // GET: Brands/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Brands/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Brand brand)
        {
            if (ModelState.IsValid)
            {
                _context.Add(brand);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(brand);
        }

        // GET: Brands/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Brand == null)
            {
                return NotFound();
            }

            var brand = await _context.Brand.FindAsync(id);
            if (brand == null)
            {
                return NotFound();
            }
            return View(brand);
        }

        // POST: Brands/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Brand brand)
        {
            if (id != brand.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(brand);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BrandExists(brand.Id))
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
            return View(brand);
        }

        // GET: Brands/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Brand == null)
            {
                return NotFound();
            }

            var brand = await _context.Brand
                .FirstOrDefaultAsync(m => m.Id == id);
            if (brand == null)
            {
                return NotFound();
            }

            return View(brand);
        }

        // POST: Brands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Brand == null)
            {
                return Problem("Entity set 'LaptopContext.Brand'  is null.");
            }
            var brand = await _context.Brand.FindAsync(id);
            if (brand != null)
            {
                _context.Brand.Remove(brand);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BrandExists(int id)
        {
          return _context.Brand.Any(e => e.Id == id);
        }

        public IActionResult LaptopsByBrand()
        {
            IEnumerable<IGrouping<int, LaptopObject>> result = _context.Laptop.GroupBy(x => x.BrandId, x => x);
            return View(result);
        }
        public IActionResult LaptopByBrandOrdering()
        {
            LaptopByBrandOrderingViewModel vm = new LaptopByBrandOrderingViewModel();
            vm.Brands = _context.Brand.ToList();
            return View(vm);
        }

        [HttpPost]
        public IActionResult LaptopByBrandOrdering(LaptopByBrandOrderingViewModel vm)
        {
            vm.Brands = _context.Brand.ToList();
            List<LaptopObject> result = new List<LaptopObject>();
            result = _context.Laptop.Where(x => x.BrandId == vm.BrandChoice).ToList();
            /*
             *             
            "Order By Price Ascending",
            "Order By Price Descending",
            "Order By Year Ascending",
            "Order By Year Descending"
             */
            if (vm.OrderChoice == "Order By Price Ascending")
            {
                result = result.OrderBy(x => x.Price).ToList();
            }
            else if (vm.OrderChoice == "Order By Price Descending")
            {
                result = result.OrderByDescending(x => x.Price).ToList();
            }
            else if (vm.OrderChoice == "Order By Year Ascending")
            {
                result = result.OrderBy(x => x.Year).ToList();
            }
            else if (vm.OrderChoice == "Order By Year Descending")
            {
                result = result.OrderByDescending(x => x.Year).ToList();
            }
            else
            {
                result = result;
            }
            vm.ResultLaptops = result;
            return View(vm);
        }
    }
}
