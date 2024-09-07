using Business.Conccrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using ECommerce.Models.ViewModels;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryManager _categoryManager;
        private readonly ProductManager _productManager;

        public CategoryController()
        {
            var categoryDal = new EfCategoryDal();
            var productDal = new EfProductDal();
            var productImageDal = new EfProductImageDal();
            var productVariantDal = new EfProductVariantDal();

            _categoryManager = new CategoryManager(categoryDal, productDal);
            _productManager = new ProductManager(productDal, productImageDal, productVariantDal);
        }

        public IActionResult Index(string categoryName)
        {
            var categories = _categoryManager.GetAll();
            var products = _productManager.GetByGender(categoryName);

            var productDetails = products.Select(p => new ProductDetailViewModel
            {
                Product = p,
                Variants = _productManager.GetVariantsByProductId(p.Id),
                Images = _productManager.GetImagesByProductId(p.Id)
            }).ToList();

            var model = new CategoryViewModel
            {
                CategoryList = categories,
                ProductDetails = productDetails
            };

            return View(model);
        }
    }
}
