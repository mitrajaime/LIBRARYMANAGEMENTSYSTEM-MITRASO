using LIBRARYMANAGEMENTSYSTEM_MITRASO.Data;
using LIBRARYMANAGEMENTSYSTEM_MITRASO.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LIBRARYMANAGEMENTSYSTEM_MITRASO.Controllers
{
    public class Practice2Controller : Controller
    {
        private readonly LIBRARYMANAGEMENTSYSTEM_MITRASOContext _context;

        public Practice2Controller(LIBRARYMANAGEMENTSYSTEM_MITRASOContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var item1 = _context.User.ToList();
            var item2 = _context.Books.ToList();

            var vm = new Practice2VM
            {
                UserData = item1,
                BookData = item2
            };


            return View(vm);
        }
    }
}
