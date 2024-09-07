using Entities.Concrete;

namespace ECommerce.Models.ViewModels
{
    public class CategoryViewModel
    {
        public List<Category> CategoryList { get; set; }
        public List<ProductDetailViewModel> ProductDetails { get; set; }
    }
}
