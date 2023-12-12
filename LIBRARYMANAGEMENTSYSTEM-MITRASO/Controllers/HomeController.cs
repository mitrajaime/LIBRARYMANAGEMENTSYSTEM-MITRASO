
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using LIBRARYMANAGEMENTSYSTEM_MITRASO.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using LIBRARYMANAGEMENTSYSTEM_MITRASO.ViewModels;


namespace LIBRARYMANAGEMENTSYSTEM_MITRASO.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            //PracticeVM pvm = new()
            //{
            //    /*Books = new()
            //    {
            //        BookId = 20,
            //        Title = "Test",
            //        Author = "Test",
            //        DatePublished = DateTime.Now,
            //        BookCategoryId = 10,
            //        IsBorrowed = false
            //    },*/

            //    //BookCategory = new()
            //    //{
            //    //    new BookCategory  
            //    //    { BookCategoryId = 10, BookCategoryName = "Skibidi"}
            //    //}
            //};

            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("LoginView", "Login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}