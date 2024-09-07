using Business.Conccrete;
using DataAccess.Concrete.EntityFramework;
using ECommerce.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZstdSharp.Unsafe;


namespace ECommerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly CategoryManager _categoryManager;
        private readonly BrandManager _brandManager;
        private readonly ProductManager _productManager;
        private readonly Context _context;
        public HomeController(Context context)
        {
            var categoryDal = new EfCategoryDal();
            var productDal = new EfProductDal();
            var brandDal = new EfBrandDal();
            var productImageDal = new EfProductImageDal();
            var productVariantDal = new EfProductVariantDal();

            _categoryManager = new CategoryManager(categoryDal, productDal);
            _brandManager = new BrandManager(brandDal);
            _productManager = new ProductManager(productDal, productImageDal, productVariantDal);
            _context = context;
        }

        public IActionResult Index()
        {
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

