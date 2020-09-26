using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StockWhole.Data;
using StockWhole.Models;

namespace StockWhole.Controllers
{
    [Authorize(Roles = "Admin")]
    //[Route("AvailableProducts")]
    public class AvailableProductsController : Controller
    {

        private readonly ApplicationDbContext _context;

        public AvailableProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AvailableProducts
        //public async Task<IActionResult> Index()
        //{
        //    //TempData.Add("Alert", "This is the Alert");
        //    return View(await _context.AvailableProduct.ToListAsync());
        //}  

        public async Task<IActionResult> Index()
        {
            var availableProduct = await _context.AvailableProduct.ToListAsync();
            string item = "";
            foreach (var i in availableProduct)
            {             
                if (i.Quantity < 10)
                {
                    item = item + ", " + i.ItemName;
                }
            }
            ViewData["Message"] = "There is a product in the list whose quantity is less than 10 :: " + item;
            return View(await _context.AvailableProduct.ToListAsync());
        }


        // GET: AvailableProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var availableProduct = await _context.AvailableProduct
                .FirstOrDefaultAsync(m => m.Id == id);
            if (availableProduct == null)
            {
                return NotFound();
            }

            return View(availableProduct);
        }

        // GET: AvailableProducts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AvailableProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ItemName,Quantity")] AvailableProduct availableProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(availableProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(availableProduct);
        }

        // GET: AvailableProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var availableProduct = await _context.AvailableProduct.FindAsync(id);
            if (availableProduct == null)
            {
                return NotFound();
            }
            return View(availableProduct);
        }

        // POST: AvailableProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ItemName,Quantity")] AvailableProduct availableProduct)
        {
            if (id != availableProduct.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(availableProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AvailableProductExists(availableProduct.Id))
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
            return View(availableProduct);
        }

        // GET: AvailableProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var availableProduct = await _context.AvailableProduct
                .FirstOrDefaultAsync(m => m.Id == id);
            if (availableProduct == null)
            {
                return NotFound();
            }

            return View(availableProduct);
        }

        // POST: AvailableProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var availableProduct = await _context.AvailableProduct.FindAsync(id);
            _context.AvailableProduct.Remove(availableProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AvailableProductExists(int id)
        {
            return _context.AvailableProduct.Any(e => e.Id == id);
        }

        //[HttpGet("findall")]
        //[Produces("application/json")]
        //public async Task<IActionResult> findAll()
        //{
        //    try
        //    {
        //        var availableproductt = _context.AvailableProduct.ToList();
        //        return Ok(availableproductt);
        //    }
        //    catch
        //    {
        //        return BadRequest();
        //    }


        //}

        //[HttpGet]
        //public async Task<IActionResult> CheckForAlert(int qty)
        //{
        //    var availableProduct = await _context.AvailableProduct
        //                    .FirstOrDefaultAsync(m => m.Quantity == qty);

        //    if (qty < 10)
        //    {
        //        ViewBag.Message = "The Quantity of the Product is less than 10";
        //    }

        //    return View(availableProduct);
        //}
    }
}
