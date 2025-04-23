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
    public class FishingVesselsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FishingVesselsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FishingVessels
        public async Task<IActionResult> Index()
        {
            return View(await _context.FishingVessel.ToListAsync());
        }

        // GET: FishingVessels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fishingVessel = await _context.FishingVessel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fishingVessel == null)
            {
                return NotFound();
            }

            return View(fishingVessel);
        }

        // GET: FishingVessels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FishingVessels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Type,Capacity,RegistrationNumber,FullCapasity")] FishingVessel fishingVessel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fishingVessel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fishingVessel);
        }

        // GET: FishingVessels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fishingVessel = await _context.FishingVessel.FindAsync(id);
            if (fishingVessel == null)
            {
                return NotFound();
            }
            return View(fishingVessel);
        }

        // POST: FishingVessels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Type,Capacity,RegistrationNumber,FullCapasity")] FishingVessel fishingVessel)
        {
            if (id != fishingVessel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fishingVessel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FishingVesselExists(fishingVessel.Id))
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
            return View(fishingVessel);
        }

        // GET: FishingVessels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fishingVessel = await _context.FishingVessel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fishingVessel == null)
            {
                return NotFound();
            }

            return View(fishingVessel);
        }

        // POST: FishingVessels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fishingVessel = await _context.FishingVessel.FindAsync(id);
            if (fishingVessel != null)
            {
                _context.FishingVessel.Remove(fishingVessel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FishingVesselExists(int id)
        {
            return _context.FishingVessel.Any(e => e.Id == id);
        }
    }
}
