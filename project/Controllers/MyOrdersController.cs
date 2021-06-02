using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using project.Data;
using project.Models;

namespace project.Controllers
{
    public class MyOrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MyOrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MyOrders
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.MyOrder.Include(m => m.Product);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: MyOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myOrder = await _context.MyOrder
                .Include(m => m.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (myOrder == null)
            {
                return NotFound();
            }

            return View(myOrder);
        }

        // GET: MyOrders/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Id");
            return View();
        }

        // POST: MyOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductId,DateTime,Count,Total")] MyOrder myOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(myOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Id", myOrder.ProductId);
            return View(myOrder);
        }

        // GET: MyOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myOrder = await _context.MyOrder.FindAsync(id);
            if (myOrder == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Id", myOrder.ProductId);
            return View(myOrder);
        }

        // POST: MyOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductId,DateTime,Count,Total")] MyOrder myOrder)
        {
            if (id != myOrder.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(myOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MyOrderExists(myOrder.Id))
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
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Id", myOrder.ProductId);
            return View(myOrder);
        }

        // GET: MyOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myOrder = await _context.MyOrder
                .Include(m => m.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (myOrder == null)
            {
                return NotFound();
            }

            return View(myOrder);
        }

        // POST: MyOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var myOrder = await _context.MyOrder.FindAsync(id);
            _context.MyOrder.Remove(myOrder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MyOrderExists(int id)
        {
            return _context.MyOrder.Any(e => e.Id == id);
        }
    }
}
