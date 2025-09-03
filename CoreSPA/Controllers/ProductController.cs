using CoreSPA.Data;
using CoreSPA.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreSPA.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ProductController (ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
            return View();
        }

        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    var products = await _context.Products
        //        .Include(p => p.Category)
        //        .Include(p => p.Features)
        //        .Select(p => new ProductVM
        //        {
        //            ProductId = p.Id
        //        })
        //        .ToListAsync();
        //}
    }
}
