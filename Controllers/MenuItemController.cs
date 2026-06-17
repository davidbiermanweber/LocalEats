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
            ViewBag.Categories = _context.MenuCategory.ToList();
            return View();
        }

        public IActionResult Index(int? category_id)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToAction("Login", "Account");

            ViewBag.Categories = _context.MenuCategory.ToList();
            ViewBag.SelectedCategory = category_id;

            var accessibleItemIds = _context.MenuAccess
                .Where(a => a.user_id == userId && a.can_view)
                .Select(a => a.menu_item_id)
                .ToList();

            var items = _context.MenuItem
                .Where(m => accessibleItemIds.Contains(m.id))
                .ToList();

            if (category_id.HasValue)
                items = items.Where(m => m.category_id == category_id).ToList();

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