using System.ComponentModel.DataAnnotations;

namespace CoreSPA.ViewModels
{
    public class ProductVM
    {
        public int ProductId { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; } = null!;

        [Required]
        public int CategoryId { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime PurchaseDate { get; set; }

        public bool IsAvailable { get; set; } = true;

        [StringLength(100)]
        public string? Brand { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        public string? Photo { get; set; }

        public IFormFile? PhotoFile { get; set; }

        public List<FeatureVM> Features { get; set; } = new();
    }
}
