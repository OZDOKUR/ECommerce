using Business.Conccrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Areas.Admin.Controllers
{
    public class AdminBrandsController : Controller
    {
        private BrandManager _brandManager = new BrandManager(new EfBrandDal());

        public IActionResult Index()
        {
            var categories = _brandManager.GetAll();
            return View(categories);
        }

        [HttpPost]
        public IActionResult Add(Brand brand)
        {
            //Sonra Yapılacak
            return View("Index");
        }

        [HttpPost]
        public IActionResult Edit(Brand brand)
        {
            //Sonra Yapılacak
            return View("Index");
        }

        [HttpPost]
        public IActionResult SoftDelete(int id)
        {
            //Sonra Yapılacak

            return RedirectToAction("AdminBrands", "Admin");
        }
    }
}
