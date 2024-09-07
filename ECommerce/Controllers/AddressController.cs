using Business.Conccrete;
using DataAccess.Concrete.EntityFramework;
using ECommerce.Models.ViewModels;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class AddressController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private AddressManager _addressManager = new AddressManager(new EfAddressDal());
        private CityManager _cityManager = new CityManager(new EfCityDal());
        private CountryManager _countryManager = new CountryManager(new EfCountryDal());
        private StateManager _stateManager = new StateManager(new EfStateDal());
        public AddressController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var userId = user.Id;
            var addresses = _addressManager.GetUserAddress(userId);

            var addressDetail = addresses.Select(a => new AddressViewModel
            {

                Title = a.Title,
                Name = a.Name,
                LastName = a.LastName,
                AddressLine1 = a.AddressLine1,
                AddressLine2 = a.AddressLine2,
                PhoneNumber = a.PhoneNumber,
                PostalCode = a.PostalCode,
                City = _cityManager.GetName(a.CityId),
                Country = _countryManager.GetName(a.CountryId),
                State = _stateManager.GetName(a.StateId)

            }).ToList();


            var model = new AddresPageViewModel
            {
                AddressDetail = addressDetail
            };
            return View(model);
        }
    }
}
