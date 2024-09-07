namespace ECommerce.Models.ViewModels
{
    public class OrderViewModel
    {
        public int UserId { get; set; }
        public decimal TotalAmount { get; set; }
        public int SelectedAddressId { get; set; }
        public string Note { get; set; }
        public List<OrderItemViewModel> OrderItems { get; set; }

    }
}
