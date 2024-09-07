using Business.Conccrete;
using DataAccess.Concrete.EntityFramework;
using ECommerce.Areas.Admin.Models.ViewModels;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Areas.Admin.Controllers
{
    public class AdminOrdersController : Controller
    {
        private readonly OrderManager _orderManager;
        private readonly UserManager _userManager;
        private readonly AddressManager _adressManager;
        private readonly OrderItemManager _orderItemManager;
        private readonly ProductManager _productManager;
        private readonly ProductVariantManager _productVariantManager;

        public AdminOrdersController()
        {
            _orderManager = new OrderManager(new EfOrderDal());
            _userManager = new UserManager(new EfUserDal());
            _adressManager = new AddressManager(new EfAddressDal(), new EfCityDal(), new EfCountryDal(), new EfStateDal());
            _orderItemManager = new OrderItemManager(new EfOrderItemDal());
            _productManager = new ProductManager(new EfProductDal(), new EfCategoryDal());
            _productVariantManager = new ProductVariantManager(new EfProductVariantDal());
        }

        public IActionResult Index()
        {
            var orders = _orderManager.GetAll();

            var model = orders.Select(a => new AdminOrderVM
            {
                OrderId = a.Id,
                Name = _userManager.GetName(a.UserId),
                LastName = _userManager.GetLastName(a.UserId),
                Country = _adressManager.GetCountryName(a.ShippingAddressId),
                States = _adressManager.GetStatesName(a.ShippingAddressId),
                Total = a.TotalAmount,
                Address1 = _adressManager.GetAddresDesc(a.ShippingAddressId),
                Address2 = _adressManager.GetAddres2Desc(a.ShippingAddressId),
                OrderDate = a.OrderDate,
            }).ToList();

            return View(model);
        }

        public async Task<IActionResult> DetailsPartial(int id)
        {
            var order = _orderManager.GetById(id);
            if (order == null)
                return NotFound();

            var orderItems = _orderItemManager.GetAllByOrderId(id);

            var model = new AdminOrderVM
            {
                OrderId = order.Id,
                Name = _userManager.GetName(order.UserId),
                LastName = _userManager.GetLastName(order.UserId),
                Total = order.TotalAmount,
                Country = _adressManager.GetCountryName(order.ShippingAddressId),
                States = _adressManager.GetStatesName(order.ShippingAddressId),
                Address1 = _adressManager.GetAddresDesc(order.ShippingAddressId),
                Address2 = _adressManager.GetAddres2Desc(order.ShippingAddressId),
                OrderDate = order.OrderDate,
                OrderItems = orderItems.Select(item => new OrderItemVM
                {
                    ProductName = _productManager.GetById(item.ProductId).ProductName,
                    Size = _productVariantManager.GetById(item.VariantId).Size,
                    Color = _productVariantManager.GetById(item.VariantId).Color,
                    Quantity = item.Quantity,
                    Price = item.Price
                }).ToList()
            };

            return PartialView("DetailsPartial", model);
        }

    }
}
