using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KhaKhau.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;

namespace KhaKhau.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class CategoriesController : Controller
    {
        private readonly KhaKhauContext _context;
        public CategoriesController(KhaKhauContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Categories.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Update(category);
                _context.SaveChanges();
                return RedirectToAction("Index", "Categories");
            }
            return View(category);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.Id == id);

<<<<<<< HEAD
<<<<<<< HEAD
=======
=======
>>>>>>> 4d0ce4fb991be6139ebcc89e27fc47f2caf3d4dc
            if (category == null)
            {
                return NotFound();
            }

<<<<<<< HEAD
>>>>>>> 4d0ce4fb991be6139ebcc89e27fc47f2caf3d4dc
=======
>>>>>>> 4d0ce4fb991be6139ebcc89e27fc47f2caf3d4dc
            return View(category);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _context.Categories
<<<<<<< HEAD
<<<<<<< HEAD
                .Include(c => c.Products) 
=======
                .Include(c => c.Products) // Load related products
>>>>>>> 4d0ce4fb991be6139ebcc89e27fc47f2caf3d4dc
=======
                .Include(c => c.Products) // Load related products
>>>>>>> 4d0ce4fb991be6139ebcc89e27fc47f2caf3d4dc
                .FirstOrDefaultAsync(c => c.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            if (category.Products != null && category.Products.Any())
            {
                _context.Products.RemoveRange(category.Products);
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}
