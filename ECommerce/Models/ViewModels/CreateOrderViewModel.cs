namespace ECommerce.Models.ViewModels
{
    public class CreateOrderViewModel
    {
        public int SelectedAddressId { get; set; }  
        public decimal TotalAmount { get; set; }
        public string Note { get; set; }
    }
}
