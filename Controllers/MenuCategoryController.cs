using Microsoft.AspNetCore.Mvc;
using UserAuthApp.Models;

namespace UserAuthApp.Controllers
{
    public class MenuCategoryController : Controller
    {
        // database context field goes here
        private readonly AppDbContext _context;

        public MenuCategoryController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Index()
        {
            var items = _context.MenuCategory.ToList();
            return View(items);
        }


        [HttpPost]
        public IActionResult Create(MenuCategory menuCategory)
        {
            _context.MenuCategory.Add(menuCategory);
            _context.SaveChanges();
            return RedirectToAction("Create");
        }
    }
}