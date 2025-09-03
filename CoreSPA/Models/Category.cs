using System.ComponentModel.DataAnnotations;
namespace CoreSPA.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required(ErrorMessage ="Category name is required")]
        [StringLength(100, ErrorMessage ="Category name cannot exceed 100 character")]
        public string Name { get; set; } = null!;
                
        public List<Product> Products { get; set; } = new();

    }
}
