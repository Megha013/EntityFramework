using EntityFramework.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntityFramework.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext configuration;
        UsersCrud db;
        public UsersController(ApplicationDbContext configuration)
        {
            this.configuration = configuration;
            db = new UsersCrud(this.configuration);
        }
        // GET: /Users/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Users user)
        {
            int userId = db.ValidateUsers(user);

            if (userId > 0)
            {
                TempData["SuccessMessage"] = "Login successful!";
                return RedirectToAction("Dashboard");
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid email or password.";
                return View();
            }
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(Users user)
        {
            if (ModelState.IsValid)
            {
                int result = db.AddUsers(user);

                if (result > 0)
                {
                    TempData["SuccessMessage"] = "Registration successful! Please log in.";
                    return RedirectToAction("Login");
                }
                else
                {
                    ViewBag.ErrorMessage = "Email is already registered.";
                    return View();
                }
            }
            return View(user);
        }
        public IActionResult Dashboard()
        {
            return View(); 
        }
    }
}
