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

    public class BorrowingRecordsController : Controller
    {
        private readonly LIBRARYMANAGEMENTSYSTEM_MITRASOContext _context;

        public BorrowingRecordsController(LIBRARYMANAGEMENTSYSTEM_MITRASOContext context)
        {
            _context = context;
        }

        // GET: BorrowingRecords
        public async Task<IActionResult> Index()
        {
            var lIBRARYMANAGEMENTSYSTEM_MITRASOContext = _context.BorrowingRecords.Include(b => b.Borrower).Include(b => b.User).Include(b => b.Books);
            /*var borrowingRecords = await _context.BorrowingRecords.Include(b => b.Borrower).Include(b => b.User).Include(b => b.Books);
            borrowingRecords.HasPenalty = true;
            await _context.SaveChangesAsync();*/ //This is the idea for setting all records that have a penalty assigned to it as true

            
            //List<Books> borrowedBooks = await _context.Books.Include(b => b.BookCategory).Where(books => books.IsBorrowed == true).ToListAsync();
            //List<Penalty> recordswithPenalties = await _context.Penalty
            //    .Include(b => b.BorrowingRecords)
            //    .ToListAsync();
            //var recordsinpenalty = _context.Penalty.Include(b => b.BorrowingRecords);
            //foreach (var penalty in recordswithPenalties)
            //{
            //    var b = await _context.Penalty.Include(b => b.BorrowingRecords);
            //    var a = recordsinpenalty.BorrowingRecordId;
            //};
            ///*return View(borrowedBooks);*/

            return View(await lIBRARYMANAGEMENTSYSTEM_MITRASOContext.ToListAsync());
        }

        // GET: BorrowingRecords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BorrowingRecords == null)
            {
                return NotFound();
            }

            var borrowingRecords = await _context.BorrowingRecords
                .Include(b => b.Borrower)
                .Include(b => b.User)
                .Include(b => b.Books)
                .FirstOrDefaultAsync(m => m.BorrowingRecordsId == id);
            if (borrowingRecords == null)
            {
                return NotFound();
            }

            return View(borrowingRecords);
        }

        // GET: BorrowingRecords/Create
        public IActionResult Create()
        {
            ViewData["BorrowerId"] = new SelectList(_context.Borrower, "BorrowerId", "StudentIdNo");
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "Username");
            ViewData["BookId"] = new SelectList(_context.Books.Where(b => b.IsBorrowed == false), "BookId", "Title");
            return View();
        }

        // POST: BorrowingRecords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BorrowingRecordsId,DateBorrowed,DueDate,BorrowerId,UserId,BookId,ReturnDate")] BorrowingRecords borrowingRecords)
        {
            if (ModelState.IsValid)
            {
                _context.Add(borrowingRecords);
                var book = await _context.Books.FindAsync(borrowingRecords.BookId);
                book.IsBorrowed = true;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BorrowerId"] = new SelectList(_context.Borrower, "BorrowerId", "StudentIdNo", borrowingRecords.BorrowerId);
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "Username", borrowingRecords.UserId);
            ViewData["BookId"] = new SelectList(_context.Books.Where(b => b.IsBorrowed == false), "BookId", "Title", borrowingRecords.BookId);
            return View(borrowingRecords);
        }

        // GET: BorrowingRecords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BorrowingRecords == null)
            {
                return NotFound();
            }

            var borrowingRecords = await _context.BorrowingRecords.FindAsync(id);
            if (borrowingRecords == null)
            {
                return NotFound();
            }
            ViewData["BorrowerId"] = new SelectList(_context.Borrower, "BorrowerId", "StudentIdNo", borrowingRecords.BorrowerId);
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "Username", borrowingRecords.UserId);
            ViewData["BookId"] = new SelectList(_context.Books.Where(b => b.IsBorrowed == false), "BookId", "Title", borrowingRecords.BookId);
            return View(borrowingRecords);
        }

        // POST: BorrowingRecords/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BorrowingRecordsId,DateBorrowed,DueDate,BorrowerId,UserId,BookId,ReturnDate")] BorrowingRecords borrowingRecords)
        {
            if (id != borrowingRecords.BorrowingRecordsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(borrowingRecords);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BorrowingRecordsExists(borrowingRecords.BorrowingRecordsId))
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
            ViewData["BorrowerId"] = new SelectList(_context.Borrower, "BorrowerId", "StudentIdNo", borrowingRecords.BorrowerId);
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "Username", borrowingRecords.UserId);
            ViewData["BookId"] = new SelectList(_context.Books.Where(b => b.IsBorrowed == false), "BookId", "Title", borrowingRecords.BookId);
            return View(borrowingRecords);
        }

        // GET: BorrowingRecords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BorrowingRecords == null)
            {
                return NotFound();
            }

            var borrowingRecords = await _context.BorrowingRecords
                .Include(b => b.Borrower)
                .Include(b => b.User)
                .Include(b => b.Books)
                .FirstOrDefaultAsync(m => m.BorrowingRecordsId == id);
            if (borrowingRecords == null)
            {
                return NotFound();
            }

            return View(borrowingRecords);
        }

        // POST: BorrowingRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BorrowingRecords == null)
            {
                return Problem("Entity set 'LIBRARYMANAGEMENTSYSTEM_MITRASOContext.BorrowingRecords'  is null.");
            }
            var borrowingRecords = await _context.BorrowingRecords.FindAsync(id);
            if (borrowingRecords != null)
            {
                _context.BorrowingRecords.Remove(borrowingRecords);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BorrowingRecordsExists(int id)
        {
          return (_context.BorrowingRecords?.Any(e => e.BorrowingRecordsId == id)).GetValueOrDefault();
        }


        // GET: Books/Edit/5
        public async Task<IActionResult> Return(int? id)
        {
            if (id == null || _context.BorrowingRecords == null)
            {
                return NotFound();
            }

            var borrowingRecords = await _context.BorrowingRecords.FindAsync(id);
            if (borrowingRecords == null)
            {
                return NotFound();
            }
            ViewData["BorrowerId"] = new SelectList(_context.Borrower, "BorrowerId", "StudentIdNo", borrowingRecords.BorrowerId);
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "Username", borrowingRecords.UserId);
            ViewData["BookId"] = new SelectList(_context.Books.Where(b => b.IsBorrowed == false), "BookId", "Title", borrowingRecords.BookId);
            return View(borrowingRecords);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Return(int id, [Bind("BorrowingRecordsId,DateBorrowed,DueDate,BorrowerId,UserId,BookId,ReturnDate")] BorrowingRecords borrowingRecords)
        {
            if (id != borrowingRecords.BorrowingRecordsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var book = await _context.Books.FindAsync(borrowingRecords.BookId);
                    borrowingRecords.ReturnDate = DateTime.Now;
                    book.IsBorrowed = false;
                    _context.Update(book);
                    _context.Update(borrowingRecords);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BorrowingRecordsExists(borrowingRecords.BorrowingRecordsId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                // return RedirectToAction(nameof(Index));
            }

            // return View(books);
            return RedirectToAction(nameof(Index));
            /*var bookToReturn = await _context.Books
                .Include(b => b.BookCategory)
                .FirstOrDefaultAsync(m => m.BookId == id);
            var returnDateData = await _context.BorrowingRecordsDetails
                .Include(a => a.BookId)
                .FirstOrDefaultAsync(m => m.BookId == id);

             if (bookToReturn != null && bookToReturn.IsBorrowed == true)
             {
                 bookToReturn.IsBorrowed = false;
                

                 _context.Update(bookToReturn);
                 await _context.SaveChangesAsync();
                 return RedirectToAction(nameof(Borrowed));
             }
             else if(bookToReturn == null)
             {
                 return NotFound();
             }
             return RedirectToAction(nameof(Index)); ;*/
        }
    }
}
