using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LIBRARYMANAGEMENTSYSTEM_MITRASO.Data;
using LIBRARYMANAGEMENTSYSTEM_MITRASO.Models;

namespace LIBRARYMANAGEMENTSYSTEM_MITRASO.Controllers
{
    public class PenaltyController : Controller
    {
        private readonly LIBRARYMANAGEMENTSYSTEM_MITRASOContext _context;

        public PenaltyController(LIBRARYMANAGEMENTSYSTEM_MITRASOContext context)
        {
            _context = context;
        }

        // GET: Penalty
        public async Task<IActionResult> Index()
        {
              return _context.Penalty != null ? 
                          View(await _context.Penalty.ToListAsync()) :
                          Problem("Entity set 'LIBRARYMANAGEMENTSYSTEM_MITRASOContext.Penalty'  is null.");
        }

        // GET: Penalty/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Penalty == null)
            {
                return NotFound();
            }

            var penalty = await _context.Penalty
                .FirstOrDefaultAsync(m => m.PenaltyId == id);
            if (penalty == null)
            {
                return NotFound();
            }

            return View(penalty);
        }

        // GET: Penalty/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Penalty/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PenaltyId,PenaltyName,Amount,PenaltyDate,IsSettled,BorrowingRecordsId,HasPenalty")] Penalty penalty)
        {
            if (ModelState.IsValid)
            {
                _context.Add(penalty);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(penalty);
        }

        // GET: Penalty/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Penalty == null)
            {
                return NotFound();
            }

            var penalty = await _context.Penalty.FindAsync(id);
            if (penalty == null)
            {
                return NotFound();
            }
            return View(penalty);
        }

        // POST: Penalty/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PenaltyId,PenaltyName,Amount,PenaltyDate,IsSettled,BorrowingRecordsId,HasPenalty")] Penalty penalty)
        {
            if (id != penalty.PenaltyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(penalty);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PenaltyExists(penalty.PenaltyId))
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
            return View(penalty);
        }

        // GET: Penalty/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Penalty == null)
            {
                return NotFound();
            }

            var penalty = await _context.Penalty
                .FirstOrDefaultAsync(m => m.PenaltyId == id);
            if (penalty == null)
            {
                return NotFound();
            }

            return View(penalty);
        }

        // POST: Penalty/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Penalty == null)
            {
                return Problem("Entity set 'LIBRARYMANAGEMENTSYSTEM_MITRASOContext.Penalty'  is null.");
            }
            var penalty = await _context.Penalty.FindAsync(id);
            if (penalty != null)
            {
                _context.Penalty.Remove(penalty);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PenaltyExists(int id)
        {
          return (_context.Penalty?.Any(e => e.PenaltyId == id)).GetValueOrDefault();
        }
    }
}
