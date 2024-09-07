

namespace Entities.Concrete
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int Gender { get; set; } // 'men', 'women', 'unisex'
        public int BrandId { get; set; } 
        public Brand Brand { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ICollection<ProductVariant> Variants { get; set; }
        public ICollection<ProductImage> Images { get; set; }
    }
}
