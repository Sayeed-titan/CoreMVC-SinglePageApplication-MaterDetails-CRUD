using System.ComponentModel.DataAnnotations;

namespace CoreSPA.ViewModels
{
    public class FeatureVM
    {
        public int FeatureId { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "Feature name cannot exceed 150 characters")]
        public string Name { get; set; } = null!;

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        public string Description { get; set; } = null!;
    }
}
