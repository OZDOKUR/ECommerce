using Business.Conccrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

public class AdminCategoriesController : Controller
{
    private CategoryManager _categoryManager = new CategoryManager(new EfCategoryDal());

    public IActionResult Index()
    {
        var categories = _categoryManager.GetAll();
        return View(categories);
    }

    [HttpPost]
    public IActionResult Add(Category category)
    {
        //Sonra Yapılacak
        return View("Index");
    }

    [HttpPost]
    public IActionResult Edit(Category category)
    {
        //Sonra Yapılacak
        return View("Index");
    }

    [HttpPost]
    public IActionResult SoftDelete(int id)
    {
        //Sonra Yapılacak

        return RedirectToAction("Index");
    }
}
