namespace CoreSPA.Models
{
    public class Feature
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public Product Product { get; set; } = null!;
    }
}
