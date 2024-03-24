using CRUDWebApplication.Data;
using CRUDWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUDWebApplication.Controllers
{
    public class DetailsController : Controller
    {
        private readonly DetailsDbContext _context;

        public DetailsController(DetailsDbContext context)
        {
            _context = context;
        }

        // GET: Details
        public async Task<IActionResult> Index()
        {
            return View(await _context.Details.ToListAsync());
        }

        // GET: Details/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Details/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email")] Details details)
        {
            if (ModelState.IsValid)
            {
                _context.Add(details);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(details);
        }

        // GET: Details/Edit/1
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detail = await _context.Details.FindAsync(id);
            if (detail == null)
            {
                return NotFound();
            }
            return View(detail);
        }

        // POST: Details/Edit/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email")] Details detail)
        {
            if (id != detail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetailsExists(detail.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(detail);
        }

        // GET: Details/Delete/1
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detail = await _context.Details
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detail == null)
            {
                return NotFound();
            }

            return View(detail);
        }

        // POST: Details/Delete/1
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detail = await _context.Details.FindAsync(id);
            _context.Details.Remove(detail);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool DetailsExists(int id)
        {
            return _context.Details.Any(e => e.Id == id);
        }
    }
}

