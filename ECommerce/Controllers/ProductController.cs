using Business.Conccrete;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using ECommerce.Models.ViewModels;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class ProductController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private CartItemManager _cartItemManager = new CartItemManager(new EfCartItemDal());
        private readonly CategoryManager _categoryManager;
        private readonly BrandManager _brandManager;
        private readonly ProductManager _productManager;
        private readonly ProductManager _productCategoryManager;
        private readonly ProductVariantManager _productVariantManager;
        private readonly ShoppingCartManager _shoppingCartManager;

        public ProductController(UserManager<ApplicationUser> userManager)
        {
            var categoryDal = new EfCategoryDal();
            var productDal = new EfProductDal();
            var brandDal = new EfBrandDal();
            var productImageDal = new EfProductImageDal();
            var productVariantDal = new EfProductVariantDal();
            var shoppingCartDal = new EfShoppingCartDal();

            _categoryManager = new CategoryManager(categoryDal, productDal);
            _brandManager = new BrandManager(brandDal, productDal);
            _productManager = new ProductManager(productDal, productImageDal, productVariantDal);
            _productCategoryManager = new ProductManager(productDal, categoryDal);
            _productVariantManager = new ProductVariantManager(productVariantDal, productDal);
            _shoppingCartManager = new ShoppingCartManager(shoppingCartDal);
        }

        public IActionResult Index(string name, string color, string SKU)
        {
            var product = _productManager.GetByName(name);
            if (product == null)
            {
                return NotFound();
            }

            var variants = _productVariantManager.GetVariantsByProductName(name);
            var allImages = _productManager.GetImagesByName(name);
            var colorImages = string.IsNullOrEmpty(color) ? allImages : _productManager.GetImagesByColor(name, color);

            var model = new ProductMainPageViewModel
            {
                Name = name,
                CategoryName = _productCategoryManager.GetByProductCategory(name),
                Price = _productManager.CalculatePrice(SKU),
                BrandName = _brandManager.BrandByName(name),
                Stock = _productManager.GetByName(name).StockQuantity,
                ProductDetails = new List<ProductDetailViewModel>
        {
                new ProductDetailViewModel
             {
                Product = product,
                Variants = variants,
                Images = colorImages
                }
        },
                Sizes = _productVariantManager.GetSizesByProductName(name),
                Colors = _productVariantManager.GetColorsByProductName(name),
                SelectedColor = color,
                SelectedSKU = SKU

            };

            return View(model);
        }

    }


}
