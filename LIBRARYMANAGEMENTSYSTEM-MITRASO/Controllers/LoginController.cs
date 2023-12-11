using LIBRARYMANAGEMENTSYSTEM_MITRASO.Data;
using LIBRARYMANAGEMENTSYSTEM_MITRASO.Models;
using LIBRARYMANAGEMENTSYSTEM_MITRASO.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LIBRARYMANAGEMENTSYSTEM_MITRASO.Controllers
{
    public class LoginController : Controller
    {
        private readonly LIBRARYMANAGEMENTSYSTEM_MITRASOContext _context;

        public LoginController(LIBRARYMANAGEMENTSYSTEM_MITRASOContext context)
        {
            _context = context;
        }

        public IActionResult LoginView()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Username, Password")] User user)
        {
            User loginUser = await _context.User.FirstOrDefaultAsync(u=>u.Username== user.Username);

            if (loginUser == null || !VerifyPassword(user.Password, loginUser.Password))
            {
                ModelState.AddModelError("", "Incorrect username or password");
                return View("Login", user);
            }
            else
            {
                //HttpContext.Session.SetString("Username", loginUser.Username);
                return RedirectToAction("Index", "User");
            }
        }
        private bool VerifyPassword(string enteredPassword, string hashedPassword)
        {
            string hasshedEnteredPassword = HashingService.HashData(enteredPassword);
            return hasshedEnteredPassword == hashedPassword;
        }
        
    }
}
