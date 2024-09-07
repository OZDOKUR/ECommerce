using Microsoft.AspNetCore.Mvc;

namespace ECommerce.ViewComponents
{
    public class ShoppingCart:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
