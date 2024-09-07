using Entities.Concrete;

namespace ECommerce.Models.ViewModels
{
    public class HomePageViewModel
    {
        public List<Category> Categories { get; set; }
        public Dictionary<int, int> ProductCounts { get; set; }
        public List<Brand> Brands { get; set; }
        public List<ProductDetailViewModel> ProductDetails { get; set; }

    }
}
