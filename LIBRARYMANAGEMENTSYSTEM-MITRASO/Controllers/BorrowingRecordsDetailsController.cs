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
    public class BorrowingRecordsDetailsController : Controller
    {
        private readonly LIBRARYMANAGEMENTSYSTEM_MITRASOContext _context;

        public BorrowingRecordsDetailsController(LIBRARYMANAGEMENTSYSTEM_MITRASOContext context)
        {
            _context = context;
        }

        // GET: BorrowingRecordsDetails
        public async Task<IActionResult> Index()
        {
            var lIBRARYMANAGEMENTSYSTEM_MITRASOContext = _context.BorrowingRecordsDetails.Include(b => b.Books).Include(b => b.BorrowingRecords);
            return View(await lIBRARYMANAGEMENTSYSTEM_MITRASOContext.ToListAsync());
        }

        // GET: BorrowingRecordsDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BorrowingRecordsDetails == null)
            {
                return NotFound();
            }

            var borrowingRecordsDetails = await _context.BorrowingRecordsDetails
                .Include(b => b.Books)
                .Include(b => b.BorrowingRecords)
                .FirstOrDefaultAsync(m => m.BorrowingRecordsDetailsId == id);
            if (borrowingRecordsDetails == null)
            {
                return NotFound();
            }

            return View(borrowingRecordsDetails);
        }

        // GET: BorrowingRecordsDetails/Create
        public IActionResult Create()
        {
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Author");
            ViewData["BorrowingRecordsId"] = new SelectList(_context.BorrowingRecords, "BorrowingRecordsId", "BorrowingRecordsId");
            return View();
        }

        // POST: BorrowingRecordsDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BorrowingRecordsDetailsId,ReturnDate,BookId,BorrowingRecordsId")] BorrowingRecordsDetails borrowingRecordsDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(borrowingRecordsDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Author", borrowingRecordsDetails.BookId);
            ViewData["BorrowingRecordsId"] = new SelectList(_context.BorrowingRecords, "BorrowingRecordsId", "BorrowingRecordsId", borrowingRecordsDetails.BorrowingRecordsId);
            return View(borrowingRecordsDetails);
        }

        // GET: BorrowingRecordsDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BorrowingRecordsDetails == null)
            {
                return NotFound();
            }

            var borrowingRecordsDetails = await _context.BorrowingRecordsDetails.FindAsync(id);
            if (borrowingRecordsDetails == null)
            {
                return NotFound();
            }
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Author", borrowingRecordsDetails.BookId);
            ViewData["BorrowingRecordsId"] = new SelectList(_context.BorrowingRecords, "BorrowingRecordsId", "BorrowingRecordsId", borrowingRecordsDetails.BorrowingRecordsId);
            return View(borrowingRecordsDetails);
        }

        // POST: BorrowingRecordsDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BorrowingRecordsDetailsId,ReturnDate,BookId,BorrowingRecordsId")] BorrowingRecordsDetails borrowingRecordsDetails)
        {
            if (id != borrowingRecordsDetails.BorrowingRecordsDetailsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(borrowingRecordsDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BorrowingRecordsDetailsExists(borrowingRecordsDetails.BorrowingRecordsDetailsId))
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
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Author", borrowingRecordsDetails.BookId);
            ViewData["BorrowingRecordsId"] = new SelectList(_context.BorrowingRecords, "BorrowingRecordsId", "BorrowingRecordsId", borrowingRecordsDetails.BorrowingRecordsId);
            return View(borrowingRecordsDetails);
        }

        // GET: BorrowingRecordsDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BorrowingRecordsDetails == null)
            {
                return NotFound();
            }

            var borrowingRecordsDetails = await _context.BorrowingRecordsDetails
                .Include(b => b.Books)
                .Include(b => b.BorrowingRecords)
                .FirstOrDefaultAsync(m => m.BorrowingRecordsDetailsId == id);
            if (borrowingRecordsDetails == null)
            {
                return NotFound();
            }

            return View(borrowingRecordsDetails);
        }

        // POST: BorrowingRecordsDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BorrowingRecordsDetails == null)
            {
                return Problem("Entity set 'LIBRARYMANAGEMENTSYSTEM_MITRASOContext.BorrowingRecordsDetails'  is null.");
            }
            var borrowingRecordsDetails = await _context.BorrowingRecordsDetails.FindAsync(id);
            if (borrowingRecordsDetails != null)
            {
                _context.BorrowingRecordsDetails.Remove(borrowingRecordsDetails);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BorrowingRecordsDetailsExists(int id)
        {
          return (_context.BorrowingRecordsDetails?.Any(e => e.BorrowingRecordsDetailsId == id)).GetValueOrDefault();
        }
    }
}
