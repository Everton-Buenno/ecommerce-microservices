namespace Catalog.API.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public  string Category { get; set; }
        public string Description { get; set; } = default!;
        public string ImageFile { get; set; } = default!;
        public decimal Price { get; set; }
    }
}
