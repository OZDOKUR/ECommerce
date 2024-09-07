namespace ECommerce.Models.ViewModels
{
    public class AddItemToCartViewModel
    {
        public int ProductId { get; set; }
        public int VariantId { get; set; }
        public int ShoppingCartId { get; set; }
        public int Quantity { get; set; }
    }
}
