using Microsoft.AspNetCore.Mvc;
using UserAuthApp.Models;

namespace UserAuthApp.Controllers
{
    public class AccountController : Controller
    {
        // database context field goes here
        private readonly AppDbContext _context;
        // constructor goes here
        public AccountController(AppDbContext context)
        {
            _context = context;
        }
        // GET: Register action goes here
        public IActionResult Register()
        {
            return View();
        }

        // GET: Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: Register action goes here
        [HttpPost]
        public IActionResult Register(User user)
        {
            _context.AppUsers.Add(user);
            _context.SaveChanges();
            TempData["FirstName"] = user.first_name;
            TempData["LastName"] = user.last_name;
            return RedirectToAction("RegisterSuccess");
        }

        public IActionResult RegisterSuccess()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _context.AppUsers.FirstOrDefault(u => u.email == email && u.password == password);

            if(user != null)
            {
                HttpContext.Session.SetInt32("UserId", user.id);
                return View("LoginSuccess", user);
            }

            else
            {
                ViewBag.Error = "Invalid email or password.";
                return View();
            }
            
        }
    }
}