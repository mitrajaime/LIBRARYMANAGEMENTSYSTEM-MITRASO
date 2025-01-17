﻿ using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LIBRARYMANAGEMENTSYSTEM_MITRASO.Data;
using LIBRARYMANAGEMENTSYSTEM_MITRASO.Models;
using Microsoft.AspNetCore.Authorization;
using static System.Reflection.Metadata.BlobBuilder;

namespace LIBRARYMANAGEMENTSYSTEM_MITRASO.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        private readonly LIBRARYMANAGEMENTSYSTEM_MITRASOContext _context;

        public BooksController(LIBRARYMANAGEMENTSYSTEM_MITRASOContext context)
        {
            _context = context;
        }
       

        // GET: Books
        public async Task<IActionResult> Index()
        {
            var lIBRARYMANAGEMENTSYSTEM_MITRASOContext = _context.Books.Include(b => b.BookCategory);
            return View(await lIBRARYMANAGEMENTSYSTEM_MITRASOContext.ToListAsync());
        }

        public async Task<IActionResult> Borrowed()
        {
            var lIBRARYMANAGEMENTSYSTEM_MITRASOContext = _context.Books;
            List<Books> borrowedBooks = await _context.Books.Include(b => b.BookCategory).Where(books => books.IsBorrowed == true).ToListAsync();


            return View(borrowedBooks);
            //return View(await lIBRARYMANAGEMENTSYSTEM_MITRASOContext.ToListAsync());
        }
        // GET: Books/Edit/5
        public async Task<IActionResult> Return(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var books = await _context.Books.FindAsync(id);
            if (books == null)
            {
                return NotFound();
            }
            ViewData["BookCategoryId"] = new SelectList(_context.Set<BookCategory>(), "BookCategoryId", "BookCategoryName", books.BookCategoryId);
            return View(books);
        }

        [HttpPost]  
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Return(int id, [Bind("BookId,Title,Author,DatePublished,BookCategoryId,IsBorrowed")] Books books)
        {
            if (id != books.BookId)
            {
                return NotFound();
            }
            
            if (ModelState.IsValid)
            {
                try
                {
                    books.IsBorrowed = false;
                    _context.Update(books);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BooksExists(books.BookId))
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
            
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var books = await _context.Books
                .Include(b => b.BookCategory)
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (books == null)
            {
                return NotFound();
            }

            return View(books);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            ViewData["BookCategoryId"] = new SelectList(_context.Set<BookCategory>(), "BookCategoryId", "BookCategoryName");

            

            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookId,Title,Author,DatePublished,BookCategoryId")] Books books)
        {
            if (ModelState.IsValid)
            {
                _context.Add(books);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookCategoryId"] = new SelectList(_context.Set<BookCategory>(), "BookCategoryId", "BookCategoryName", books.BookCategoryId);
            return View(books);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var books = await _context.Books.FindAsync(id);
            if (books == null)
            {
                return NotFound();
            }
            ViewData["BookCategoryId"] = new SelectList(_context.Set<BookCategory>(), "BookCategoryId", "BookCategoryName", books.BookCategoryId);
            return View(books);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookId,Title,Author,DatePublished,BookCategoryId,IsBorrowed")] Books books)
        {
            if (id != books.BookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(books);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BooksExists(books.BookId))
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
            ViewData["BookCategoryId"] = new SelectList(_context.Set<BookCategory>(), "BookCategoryId", "BookCategoryName", books.BookCategoryId);
            return View(books);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var books = await _context.Books
                .Include(b => b.BookCategory)
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (books == null)
            {
                return NotFound();
            }

            return View(books);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Books == null)
            {
                return Problem("Entity set 'LIBRARYMANAGEMENTSYSTEM_MITRASOContext.Books'  is null.");
            }
            var books = await _context.Books.FindAsync(id);
            if (books != null)
            {
                _context.Books.Remove(books);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BooksExists(int id)
        {
          return (_context.Books?.Any(e => e.BookId == id)).GetValueOrDefault();
        }
    }
}
