namespace CoreSPA.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
        public decimal Price { get; set; }
        public DateTime PurchaseDate { get; set; }
        public bool IsAvailable { get; set; }
        public string? Brand { get; set; }
        public string? Photo {  get; set; }
        public string? Description { get; set; }

        public List<Feature> Features { get; set; } = new();
    }
}
