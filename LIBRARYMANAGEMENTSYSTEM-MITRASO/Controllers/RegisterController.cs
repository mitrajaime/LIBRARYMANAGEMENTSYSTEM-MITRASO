using LIBRARYMANAGEMENTSYSTEM_MITRASO.Data;
using LIBRARYMANAGEMENTSYSTEM_MITRASO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using LIBRARYMANAGEMENTSYSTEM_MITRASO.Services;

namespace LIBRARYMANAGEMENTSYSTEM_MITRASO.Controllers
{
    public class RegisterController : Controller
    {
        private readonly LIBRARYMANAGEMENTSYSTEM_MITRASOContext _context;

        public RegisterController(LIBRARYMANAGEMENTSYSTEM_MITRASOContext context)
        {
            _context = context;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Username,Password,FirstName,LastName,Email,BirthDate")] User users)
        {
            if (ModelState.IsValid)
            {
                string HashPassword = HashingService.HashData(users.Password);
                users.Password = HashPassword;

                _context.Add(users);
                await _context.SaveChangesAsync();
                return RedirectToAction("LoginView","Login");
            }
            return View(users);
        }
        

    }
}
