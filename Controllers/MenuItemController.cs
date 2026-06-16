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

        public IActionResult Index(int? category_id)
        {
            ViewBag.Categories = _context.MenuCategory.ToList();
            ViewBag.SelectedCategory = category_id;

            var items = category_id.HasValue
                ? _context.MenuItem.Where(m => m.category_id == category_id).ToList()
                : _context.MenuItem.ToList();

                return View(items);
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