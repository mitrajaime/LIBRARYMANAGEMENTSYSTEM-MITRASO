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
    public class BookCategoryController : Controller
    {
        private readonly LIBRARYMANAGEMENTSYSTEM_MITRASOContext _context;

        public BookCategoryController(LIBRARYMANAGEMENTSYSTEM_MITRASOContext context)
        {
            _context = context;
        }

        // GET: BookCategory
        public async Task<IActionResult> Index()
        {
              return _context.BookCategory != null ? 
                          View(await _context.BookCategory.ToListAsync()) :
                          Problem("Entity set 'LIBRARYMANAGEMENTSYSTEM_MITRASOContext.BookCategory'  is null.");
        }

        // GET: BookCategory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BookCategory == null)
            {
                return NotFound();
            }

            var bookCategory = await _context.BookCategory
                .FirstOrDefaultAsync(m => m.BookCategoryId == id);
            if (bookCategory == null)
            {
                return NotFound();
            }

            return View(bookCategory);
        }

        // GET: BookCategory/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BookCategory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookCategoryId,BookCategoryName")] BookCategory bookCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookCategory);
        }

        // GET: BookCategory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BookCategory == null)
            {
                return NotFound();
            }

            var bookCategory = await _context.BookCategory.FindAsync(id);
            if (bookCategory == null)
            {
                return NotFound();
            }
            return View(bookCategory);
        }

        // POST: BookCategory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookCategoryId,BookCategoryName")] BookCategory bookCategory)
        {
            if (id != bookCategory.BookCategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookCategoryExists(bookCategory.BookCategoryId))
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
            return View(bookCategory);
        }

        // GET: BookCategory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BookCategory == null)
            {
                return NotFound();
            }

            var bookCategory = await _context.BookCategory
                .FirstOrDefaultAsync(m => m.BookCategoryId == id);
            if (bookCategory == null)
            {
                return NotFound();
            }

            return View(bookCategory);
        }

        // POST: BookCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BookCategory == null)
            {
                return Problem("Entity set 'LIBRARYMANAGEMENTSYSTEM_MITRASOContext.BookCategory'  is null.");
            }
            var bookCategory = await _context.BookCategory.FindAsync(id);
            if (bookCategory != null)
            {
                _context.BookCategory.Remove(bookCategory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookCategoryExists(int id)
        {
          return (_context.BookCategory?.Any(e => e.BookCategoryId == id)).GetValueOrDefault();
        }
    }
}
