using Entities.Concrete;

namespace ECommerce.Models.ViewModels
{
    public class ProductMainPageViewModel
    {
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public string BrandName { get; set; }
        public decimal Price { get; set; }
        public List<ProductDetailViewModel> ProductDetails { get; set; }
        public List<string> Sizes { get; set; }
        public List<string> Colors { get; set; }
        public int Stock { get; set; }
        public string SelectedColor { get; set; }
        public string SelectedSKU { get; set; }
        public List<string> AllImageUrls { get; set; } 
        public List<string> ColorSpecificImageUrls { get; set; }
    }
}
