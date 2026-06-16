using Microsoft.AspNetCore.Mvc;
using UserAuthApp.Models;

namespace UserAuthApp.Controllers
{
    public class MenuAccessController : Controller
    {
        // database context field goes here
        private readonly AppDbContext _context;

        public MenuAccessController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Index()
        {
            var items = _context.MenuAccess.ToList();
            return View(items);
        }


        [HttpPost]
        public IActionResult Create(MenuAccess menuAccess)
        {
            _context.MenuAccess.Add(menuAccess);
            _context.SaveChanges();
            return RedirectToAction("Create");
        }
    }
}