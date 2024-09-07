using Entities.Concrete;

namespace ECommerce.Models.ViewModels
{
    public class AddresPageViewModel
    {
        public List<AddressViewModel> AddressDetail { get; set; }
        public string? Baslik { get; set; }
        public int Adet { get; set; }
        public Product? Product { get; set; }
    }
}
