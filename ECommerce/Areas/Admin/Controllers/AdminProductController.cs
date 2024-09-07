using Business.Conccrete;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using ECommerce.Areas.Admin.Models.ViewModels;
using ECommerce.Models.ViewModels;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Areas.Admin.Controllers
{
    public class AdminProductController : Controller
    {
        private readonly ProductManager _productManager;
        private readonly CategoryManager _categoryManager;
        private readonly BrandManager _brandManager;
        private readonly ProductImageManager _productImageManager;

        public AdminProductController()
        {
            _productManager = new ProductManager(new EfProductDal(), new EfCategoryDal());
            _categoryManager = new CategoryManager(new EfCategoryDal());
            _brandManager = new BrandManager(new EfBrandDal());
            _productImageManager = new ProductImageManager(new EfProductImageDal());
        }

        public IActionResult Index()
        {
            var products = _productManager.GetAll();
            var model = products.Select(p => new AdminProductDetailVM
            {
                Id = p.Id,
                ProductName = p.ProductName,
                Description = p.Description,
                Price = p.Price,
                StockQuantity = p.StockQuantity,
                CategoryName = _categoryManager.GetById(p.CategoryId).CategoryName,
                BrandName = _brandManager.GetById(p.BrandId).Name,
                ImageUrls = _productImageManager.GetAllImageUrls(p.Id),
            }).ToList();

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            //Sonra Yapılacak
            return View("Index");
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            //Sonra Yapılacak
            return View("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            //Sonra Yapılacak

            return RedirectToAction("AdminBrands", "Admin");
        }
    }
}
