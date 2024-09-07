using Business.Abstract;
using Business.Conccrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using ECommerce.Models.ViewModels;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class WishlistController : Controller
    {
        private readonly IWishlistItemDal _wishlistItemDal;
        private WishlistItemManager _wItemManager = new WishlistItemManager(new EfWishlistItemDal());
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly CategoryManager _categoryManager;
        private readonly BrandManager _brandManager;
        private readonly ProductManager _productManager;


        public WishlistController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        

        public WishlistController()
        {
            var categoryDal = new EfCategoryDal();
            var productDal = new EfProductDal();
            var brandDal = new EfBrandDal();
            var productImageDal = new EfProductImageDal();
            var productVariantDal = new EfProductVariantDal();

            _categoryManager = new CategoryManager(categoryDal, productDal);
            _brandManager = new BrandManager(brandDal);
            _productManager = new ProductManager(productDal, productImageDal, productVariantDal);
        }

       


        [Authorize]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var userId = user.Id;
            var categories = _categoryManager.GetAll();
            var productCounts = new Dictionary<int, int>();
            var brands = _brandManager.GetAll();
            var products = _productManager.GetAll();

            foreach (var category in categories)
            {
                int count = _categoryManager.GetProductCountByCategory(category.Id);
                productCounts.Add(category.Id, count);
            }

            var productDetails = products.Select(p => new ProductDetailViewModel
            {
                Product = p,
                Variants = _productManager.GetVariantsByProductId(p.Id),
                Images = _productManager.GetImagesByProductId(p.Id)
            }).ToList();

            var model = new HomePageViewModel
            {
                Categories = categories,
                ProductCounts = productCounts,
                Brands = brands,
                ProductDetails = productDetails,
            };

            return View(model);
        }
    }
}
