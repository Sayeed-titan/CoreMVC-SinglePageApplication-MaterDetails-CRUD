using System.ComponentModel.DataAnnotations;

namespace CoreSPA.ViewModels
{
    public class CategoryVM
    {
        public int CategoryId { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; } = default!;
    }
}
