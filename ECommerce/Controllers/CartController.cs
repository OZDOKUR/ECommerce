using Business.Abstract;
using Business.Conccrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using ECommerce.Models.ViewModels;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ECommerce.Controllers
{
    public class CartController : Controller
    {

        private ShoppingCartManager _shoppingCartManager = new ShoppingCartManager(new EfShoppingCartDal());
        private CartItemManager _cartItemManager = new CartItemManager(new EfCartItemDal());
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly CategoryManager _categoryManager;
        private readonly BrandManager _brandManager;
        private readonly ProductManager _productManager;
        private readonly ProductVariantManager _productVariantManager;




        public CartController(UserManager<ApplicationUser> userManager)
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

            var model = new CartViewModel
            {
                CartItems = cartItems,
                ProductDetails = productDetails
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCartItem(int cartItemId, int newQuantity)
        {
            if (cartItemId <= 0 || newQuantity <= 0)
            {
                return BadRequest(new { success = false, message = "Invalid input data." });
            }

            var cartItem = _cartItemManager.GetById(cartItemId);
            if (cartItem == null)
            {
                return NotFound(new { success = false, message = "Cart item not found." });
            }

            cartItem.Quantity = newQuantity;
            _cartItemManager.UpdateQuantity(cartItem);

            return Json(new { success = true });
        }

        public IActionResult DeleteCartItem(int id)
        {
            _cartItemManager.DeleteByProductId(id);
            return RedirectToAction("Index","Cart");
        }

        [HttpPost]
        public async Task<IActionResult> Add(string sku)
        {
            var user = await _userManager.GetUserAsync(User);
            var userId = user.Id.ToString();
            var shoppingCartId = _shoppingCartManager.GetCartByUserId(userId).Id;
            var product = _productVariantManager.GetVariantsBySKU(sku);

            var cartItem = new CartItem
            {
                CartId = shoppingCartId,
                ProductId = product.ProductId,
                VariantId = product.Id,
                Quantity = 1
            };
            _cartItemManager.Add(cartItem);
            return RedirectToAction("Index", "Cart");
        }
    }
}
