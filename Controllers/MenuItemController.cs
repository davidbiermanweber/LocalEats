using Microsoft.AspNetCore.Mvc;
using UserAuthApp.Models;

namespace UserAuthApp.Controllers
{
    public class MenuItemController : Controller
    {
        // database context field goes here
        private readonly AppDbContext _context;

        public MenuItemController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(MenuItem menuItem)
        {
            _context.MenuItem.Add(menuItem);
            _context.SaveChanges();
            return RedirectToAction("Create");
        }
    }
}