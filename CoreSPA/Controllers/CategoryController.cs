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

            if(vm.CategoryId > 0)
            {
                var category = await _context.Categories.FindAsync(vm.CategoryId);
                if (category == null) return NotFound();

                category.Name = vm.Name;
            }
            else
            {
                var category = new Category
                {
                    Name = vm.Name
                };
                _context.Categories.Add(category);
            }

            await _context.SaveChangesAsync();

            return Json(new { success = true });
        }

        //Delete
        public async Task<IActionResult> Delete (int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null) return NotFound();

            //Check if the category has any associated products

            bool hasProducts = await _context.Products.AnyAsync(p => p.CategoryId == id);

            if (hasProducts)
            {
                return BadRequest("Cannot delete category with associated products.");
            }

            _context.Categories.Remove(category);

            await _context.SaveChangesAsync();

            return Json(new { success = true });
        }

    }
}
