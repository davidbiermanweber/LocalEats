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
            return View("RegisterSuccess", user);
        }

        // POST: Login
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _context.AppUsers.FirstOrDefault(u => u.Email == email && u.Password == password);

            if(user != null)
            {
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