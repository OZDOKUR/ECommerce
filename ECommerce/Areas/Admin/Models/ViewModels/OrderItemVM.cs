namespace ECommerce.Areas.Admin.Models.ViewModels
{
    public class OrderItemVM
    {
        public string ProductName { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
