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
    public class ShopkeepersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShopkeepersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Shopkeepers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Shopkeeper.ToListAsync());
        }
        
        // GET: Shopkeepers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopkeeper = await _context.Shopkeeper
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shopkeeper == null)
            {
                return NotFound();
            }

            return View(shopkeeper);
        }

        // GET: Shopkeepers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Shopkeepers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ItemName,Quantity,Price,amount,Date")] Shopkeeper shopkeeper)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shopkeeper);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shopkeeper);
        }

        // GET: Shopkeepers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopkeeper = await _context.Shopkeeper.FindAsync(id);
            if (shopkeeper == null)
            {
                return NotFound();
            }
            return View(shopkeeper);
        }

        // POST: Shopkeepers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ItemName,Quantity,Price,amount,Date")] Shopkeeper shopkeeper)
        {
            if (id != shopkeeper.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shopkeeper);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShopkeeperExists(shopkeeper.Id))
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
            return View(shopkeeper);
        }

        // GET: Shopkeepers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopkeeper = await _context.Shopkeeper
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shopkeeper == null)
            {
                return NotFound();
            }

            return View(shopkeeper);
        }

        // POST: Shopkeepers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shopkeeper = await _context.Shopkeeper.FindAsync(id);
            _context.Shopkeeper.Remove(shopkeeper);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShopkeeperExists(int id)
        {
            return _context.Shopkeeper.Any(e => e.Id == id);
        }
    }
}
