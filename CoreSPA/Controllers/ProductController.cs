using CoreSPA.Data;
using CoreSPA.Models;
using CoreSPA.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreSPA.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ProductController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index() => View();

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _context.Products
                .Include(p => p.Features)
                .Include(p => p.Category)
                .Select(p => new ProductVM
                {
                    ProductId = p.ProductId,
                    Name = p.Name,
                    CategoryId = p.CategoryId,
                    Price = p.Price,
                    Stock = p.Stock,
                    PurchaseDate = p.PurchaseDate,
                    IsAvailable = p.IsAvailable,
                    Brand = p.Brand,
                    Description = p.Description,
                    Photo = p.Photo,
                    Features = p.Features.Select(f => new FeatureVM
                    {
                        FeatureId = f.FeatureId,
                        Name = f.Name,
                        Description = f.Description
                    }).ToList()
                }).ToListAsync();

            return Json(products);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _context.Products
                .Include(p => p.Features)
                .FirstOrDefaultAsync(p => p.ProductId == id);

            if (product == null) return NotFound();

            var vm = new ProductVM
            {
                ProductId = product.ProductId,
                Name = product.Name,
                CategoryId = product.CategoryId,
                Price = product.Price,
                Stock = product.Stock,
                PurchaseDate = product.PurchaseDate,
                IsAvailable = product.IsAvailable,
                Brand = product.Brand,
                Description = product.Description,
                Photo = product.Photo,
                Features = product.Features.Select(f => new FeatureVM
                {
                    FeatureId = f.FeatureId,
                    Name = f.Name,
                    Description = f.Description
                }).ToList()
            };

            return Json(vm);
        }

        private async Task<string> SaveImage(IFormFile file, string folder)
        {
            var allowedMimes = new[] { "image/jpeg", "image/png", "image/webp" };
            if (!allowedMimes.Contains(file.ContentType)) throw new Exception("Only JPG/PNG/WEBP allowed.");
            if (file.Length > 2 * 1024 * 1024) throw new Exception("Max 2MB.");

            var uploads = Path.Combine(_env.WebRootPath, folder);
            if (!Directory.Exists(uploads)) Directory.CreateDirectory(uploads);

            var ext = Path.GetExtension(file.FileName);
            var fileName = $"{Guid.NewGuid()}{ext}";
            var filePath = Path.Combine(uploads, fileName);

            using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);

            return $"{folder}/{fileName}";
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromForm] ProductVM vm)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                                              .Select(e => e.ErrorMessage)
                                              .ToList();
                return BadRequest(new { success = false, errors });
            }

            using var trx = await _context.Database.BeginTransactionAsync();
            try
            {
                Product product;

                if (vm.ProductId > 0)
                {
                    // Update
                    product = await _context.Products
                        .Include(p => p.Features)
                        .FirstAsync(p => p.ProductId == vm.ProductId);

                    product.Name = vm.Name;
                    product.CategoryId = vm.CategoryId;
                    product.Price = vm.Price;
                    product.Stock = vm.Stock;
                    product.PurchaseDate = vm.PurchaseDate;
                    product.IsAvailable = vm.IsAvailable;
                    product.Brand = vm.Brand;
                    product.Description = vm.Description;
                }
                else
                {
                    // Create
                    product = new Product
                    {
                        Name = vm.Name,
                        CategoryId = vm.CategoryId,
                        Price = vm.Price,
                        Stock = vm.Stock,
                        PurchaseDate = vm.PurchaseDate,
                        IsAvailable = vm.IsAvailable,
                        Brand = vm.Brand,
                        Description = vm.Description,
                        Features = new List<Feature>()
                    };
                    _context.Products.Add(product);
                }

                // Handle image
                if (vm.PhotoFile != null)
                {
                    string fileName = await SaveImage(vm.PhotoFile, "products");
                    product.Photo = fileName;
                }

                // Features
                product.Features.Clear();
                foreach (var f in vm.Features)
                {
                    product.Features.Add(new Feature
                    {
                        Name = f.Name,
                        Description = f.Description
                    });
                }

                await _context.SaveChangesAsync();
                await trx.CommitAsync();

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                await trx.RollbackAsync();
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _context.Products
                .Include(p => p.Features)
                .FirstOrDefaultAsync(p => p.ProductId == id);

            if (product == null) return NotFound();

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return Json(new { success = true });
        }
    }
}
