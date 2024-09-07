using Entities.Concrete;

namespace ECommerce.Models.ViewModels
{
    public class CartViewModel
    {
        public List<CartItem> CartItems { get; set; }
        public List<ProductDetailViewModel> ProductDetails { get; set; }
    }
}
