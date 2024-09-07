namespace Entities.Concrete
{
    public class CartItem
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public ShoppingCart Cart { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int VariantId { get; set; }
        public ProductVariant Variant { get; set; }
        public int Quantity { get; set; }
    }
}
