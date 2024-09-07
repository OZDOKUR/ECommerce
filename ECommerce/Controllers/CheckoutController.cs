using Business.Conccrete;
using DataAccess.Concrete.EntityFramework;
using ECommerce.Models.ViewModels;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class CheckoutController : Controller
    {
        private ShoppingCartManager _shoppingCartManager = new ShoppingCartManager(new EfShoppingCartDal());
        private CartItemManager _cartItemManager = new CartItemManager(new EfCartItemDal());
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly CategoryManager _categoryManager;
        private readonly BrandManager _brandManager;
        private readonly ProductManager _productManager;
        private readonly ProductVariantManager _productVariantManager;
        private AddressManager _addressManager = new AddressManager(new EfAddressDal());
        private CityManager _cityManager = new CityManager(new EfCityDal());
        private CountryManager _countryManager = new CountryManager(new EfCountryDal());
        private StateManager _stateManager = new StateManager(new EfStateDal());



        public CheckoutController(UserManager<ApplicationUser> userManager)
        {
            var categoryDal = new EfCategoryDal();
            var productDal = new EfProductDal();
            var brandDal = new EfBrandDal();
            var productImageDal = new EfProductImageDal();
            var productVariantDal = new EfProductVariantDal();

            _categoryManager = new CategoryManager(categoryDal, productDal);
            _brandManager = new BrandManager(brandDal);
            _productManager = new ProductManager(productDal, productImageDal, productVariantDal);
            _userManager = userManager;
            _productVariantManager = new ProductVariantManager(productVariantDal, productDal);
        }
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var userId = user.Id;
            var cartItems = _cartItemManager.GetCartItemsByUserId(userId);
            var productDetails = cartItems.Select(cartItem => new ProductDetailViewModel
            {
                Product = _productManager.GetById(cartItem.ProductId),
                Variants = _productManager.GetVariantsByProductId(cartItem.ProductId),
                Images = _productManager.GetImagesByProductId(cartItem.ProductId)
            }).ToList();

            var cartViewModel = new CartViewModel
            {
                CartItems = cartItems,
                ProductDetails = productDetails
            };

            var addresses = _addressManager.GetUserAddress(userId);

            var addressDetail = addresses.Select(a => new AddressViewModel
            {
                Id = a.Id,
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

            var addressViewModel = new AddresPageViewModel
            {
                AddressDetail = addressDetail
            };

            var model = new PaymentViewModel
            {
                CartViewModel = cartViewModel,
                Addresses = addressViewModel,
            };
            return View(model);
        }
    }
}
