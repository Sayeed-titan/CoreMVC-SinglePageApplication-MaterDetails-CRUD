using CoreSPA.Data;
using CoreSPA.Models;
using CoreSPA.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreSPA.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Index view
        public IActionResult Index() => View();

        //Get All Categories
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _context.Categories.Select(c => new CategoryVM
            {
                CategoryId = c.CategoryId,
                Name = c.Name
            })
            .ToListAsync();

            return Json(categories);
        }

        //Get By Id
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _context.Categories
                .Where(c => c.CategoryId == id)
                .Select(c => new CategoryVM
                {
                    CategoryId = c.CategoryId,
                    Name = c.Name
                })
                .FirstOrDefaultAsync();

            if (category == null) return NotFound();

            return Json(category);
        }

        //Save (Create/Update)
        [HttpPost]
        public async Task<IActionResult> Save([FromForm] CategoryVM vm)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            Category? category;

            if (vm.CategoryId > 0)
            {
                 category = await _context.Categories.FindAsync(vm.CategoryId);
                if (category == null)
                    return NotFound(new { success = false, message = "Category not found." });

                category.Name = vm.Name;
            }
            else
            {
                 category = new Category
                {
                    Name = vm.Name
                };
                _context.Categories.Add(category);
            }

            await _context.SaveChangesAsync();

            return Json(new { success = true, categoryId = category.CategoryId, categoryName = category.Name });
        }

        // Delete
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
                return NotFound();

            // Check if any products use this category
            bool inUse = await _context.Products.AnyAsync(p => p.CategoryId == id);
            if (inUse)
            {
                return BadRequest(new { success = false, message = "Cannot delete category. It is being used in Products." });
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return Json(new { success = true });
        }



    }
}
