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
    public class NeededStocksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NeededStocksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NeededStocks
        public async Task<IActionResult> Index()
        {
            return View(await _context.NeededStock.ToListAsync());
        }

        // GET: NeededStocks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var neededStock = await _context.NeededStock
                .FirstOrDefaultAsync(m => m.Id == id);
            if (neededStock == null)
            {
                return NotFound();
            }

            return View(neededStock);
        }

        // GET: NeededStocks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NeededStocks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SellerName,StockQuantity")] NeededStock neededStock)
        {
            if (ModelState.IsValid)
            {
                _context.Add(neededStock);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(neededStock);
        }

        // GET: NeededStocks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var neededStock = await _context.NeededStock.FindAsync(id);
            if (neededStock == null)
            {
                return NotFound();
            }
            return View(neededStock);
        }

        // POST: NeededStocks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SellerName,StockQuantity")] NeededStock neededStock)
        {
            if (id != neededStock.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(neededStock);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NeededStockExists(neededStock.Id))
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
            return View(neededStock);
        }

        // GET: NeededStocks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var neededStock = await _context.NeededStock
                .FirstOrDefaultAsync(m => m.Id == id);
            if (neededStock == null)
            {
                return NotFound();
            }

            return View(neededStock);
        }

        // POST: NeededStocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var neededStock = await _context.NeededStock.FindAsync(id);
            _context.NeededStock.Remove(neededStock);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NeededStockExists(int id)
        {
            return _context.NeededStock.Any(e => e.Id == id);
        }
    }
}
