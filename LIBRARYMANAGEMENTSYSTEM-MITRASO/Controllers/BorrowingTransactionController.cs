using LIBRARYMANAGEMENTSYSTEM_MITRASO.Data;
using LIBRARYMANAGEMENTSYSTEM_MITRASO.Models;
using LIBRARYMANAGEMENTSYSTEM_MITRASO.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LIBRARYMANAGEMENTSYSTEM_MITRASO.Controllers
{
    public class BorrowingTransactionController : Controller
    {
        private readonly LIBRARYMANAGEMENTSYSTEM_MITRASOContext _context;

        public BorrowingTransactionController(LIBRARYMANAGEMENTSYSTEM_MITRASOContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var item1 = _context.BorrowingRecords.ToList();
            var item2 = _context.BorrowingRecordsDetails.ToList();

            var vm = new BorrowingTransactionVM
            {
                BorrowingRecordsData = item1,
                BorrowingRecordsDetailsData = item2
            };


            return View(vm);
        }
        public IActionResult Create()
        {
            var viewModel = new BorrowingTransactionVM
            {
                BorrowingRecordsData = new List<BorrowingRecords>(),
                BorrowingRecordsDetailsData = new List<BorrowingRecordsDetails>(),
                BorrowerData = new List<Borrower>(),
                BooksData = new List<Books>()
            };

            return View(viewModel);
            //}

            //[HttpPost]
            //[ValidateAntiForgeryToken]
            //public async Task<IActionResult> Create([Bind("BookId,Title,Author,DatePublished,BookCategoryId")] BorrowingTransactionVM books)
            //{
            //    if (ModelState.IsValid)
            //    {
            //        _context.Add(books);
            //        await _context.SaveChangesAsync();
            //        return RedirectToAction(nameof(Index));
            //    }
            //    ViewData["BookCategoryId"] = new SelectList(_context.Set<BookCategory>(), "BookCategoryId", "BookCategoryName", books.BookCategoryId);
            //    return View(books);
            //}

            /////////what i made
            //[HttpPost]
            //public ActionResult Create(BorrowingTransactionVM viewModel)
            //{
            //    if (ModelState.IsValid)
            //    {
            //        using (var transaction = _context.Database.BeginTransaction())
            //        {
            //            try
            //            {
            //                // Add records to BorrowingRecords
            //                foreach (var record in viewModel.BorrowingRecordsData)
            //                {
            //                    _context.BorrowingRecords.Add(record);
            //                }

            //                // Add records to BorrowingRecordsDetails
            //                foreach (var details in viewModel.BorrowingRecordsDetailsData)
            //                {
            //                    _context.BorrowingRecordsDetails.Add(details);
            //                }

            //                // Add records to Borrowers
            //                foreach (var borrower in viewModel.BorrowerData)
            //                {
            //                    _context.Borrower.Add(borrower);
            //                }

            //                // Add records to Books
            //                foreach (var book in viewModel.BooksData)
            //                {
            //                    _context.Books.Add(book);
            //                }

            //                _context.SaveChanges();
            //                transaction.Commit();

            //                return RedirectToAction("Index"); // Redirect to the appropriate action
            //            }
            //            catch (Exception)
            //            {
            //                // Handle any exceptions, rollback the transaction if needed
            //                transaction.Rollback();
            //                throw;
            //            }
            //        }
            //    }

            //    // If ModelState is not valid, return to the view with errors
            //    return View(viewModel);
            //}
        }
    }
}
