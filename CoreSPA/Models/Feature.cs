using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreSPA.Models
{
    public class Feature
    {
        [Key]
        public int FeatureId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = null!;

        [Required(ErrorMessage = "Feature name is required")]
        [StringLength(150, ErrorMessage = "Feature name cannot exceed 150 characters")]
        public string Name { get; set; } = null!;

        [StringLength(2000, ErrorMessage = "Feature description cannot exceed 2000 characters")]
        public string Description { get; set; } = null!;

    }
}
