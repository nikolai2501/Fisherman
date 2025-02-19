using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FishingPlace.Data;
using FishingPlace.Models;

namespace FishingPlace.Controllers
{
    public class FishermenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FishermenController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Fishermen
        public async Task<IActionResult> Index()
        {
            return View(await _context.Fisherman.ToListAsync());
        }

        // GET: Fishermen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fisherman = await _context.Fisherman
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fisherman == null)
            {
                return NotFound();
            }

            return View(fisherman);
        }

        // GET: Fishermen/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fishermen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Age")] Fisherman fisherman)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fisherman);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fisherman);
        }

        // GET: Fishermen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fisherman = await _context.Fisherman.FindAsync(id);
            if (fisherman == null)
            {
                return NotFound();
            }
            return View(fisherman);
        }

        // POST: Fishermen/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Age")] Fisherman fisherman)
        {
            if (id != fisherman.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fisherman);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FishermanExists(fisherman.Id))
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
            return View(fisherman);
        }

        // GET: Fishermen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fisherman = await _context.Fisherman
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fisherman == null)
            {
                return NotFound();
            }

            return View(fisherman);
        }

        // POST: Fishermen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fisherman = await _context.Fisherman.FindAsync(id);
            if (fisherman != null)
            {
                _context.Fisherman.Remove(fisherman);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FishermanExists(int id)
        {
            return _context.Fisherman.Any(e => e.Id == id);
        }
    }
}
