namespace ECommerce.Models.ViewModels
{
    public class OrderItemViewModel
    {
        public int ProductId { get; set; }
        public int VariantId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
