namespace ECommerce.Areas.Admin.Models.ViewModels
{
    public class AdminProductDetailVM
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string CategoryName { get; set; }
        public string BrandName { get; set; }
        public List<string> ImageUrls { get; set; }
    }
}
