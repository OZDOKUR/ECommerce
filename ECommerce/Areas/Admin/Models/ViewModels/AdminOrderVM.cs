using Entities.Concrete;

namespace ECommerce.Areas.Admin.Models.ViewModels
{
    public class AdminOrderVM
    {
        public int OrderId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public decimal Total { get; set; }
        public string Country { get; set; }
        public string States { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderItemVM> OrderItems { get; set; }
    }
}
