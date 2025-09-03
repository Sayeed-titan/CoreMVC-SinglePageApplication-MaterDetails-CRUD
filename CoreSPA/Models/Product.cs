using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreSPA.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage ="Product name is required")]
        [StringLength(150, ErrorMessage = "Product name cannot exceed 150 characters")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage ="Category is required")]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        [Required]
        [Range(0, double.MaxValue, ErrorMessage ="Price must be positive")]
        [Precision(18,2)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Stock quantity is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Stock cannot be negative")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "Purchase date is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:{yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PurchaseDate { get; set; } 

        public bool IsAvailable { get; set; }

        [StringLength(100, ErrorMessage = "Brand cannot exceed 100 characters")]
        public string? Brand { get; set; }

        [StringLength(200)]
        public string? Photo {  get; set; }

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        public string? Description { get; set; }

        public List<Feature> Features { get; set; } = new();
    }
}
