using Business.Conccrete;
using DataAccess.Concrete.EntityFramework;
using ECommerce.Models.ViewModels;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

public class OrderController : Controller
{
    private readonly OrderManager _orderManager = new OrderManager(new EfOrderDal());
    private readonly OrderItemManager _orderItemManager = new OrderItemManager(new EfOrderItemDal());
    private readonly CartItemManager _cartItemManager = new CartItemManager(new EfCartItemDal());
    private readonly ShoppingCartManager _shoppingCartManager = new ShoppingCartManager(new EfShoppingCartDal());
    private readonly UserManager<ApplicationUser> _userManager;

    public OrderController(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    [Authorize]
    [HttpPost]
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateOrder(OrderViewModel model)
    {
        var user = await _userManager.GetUserAsync(User);
        var userId = user.Id;

        // Yeni siparişi oluşturun
        var order = new Order
        {
            UserId = userId,
            TotalAmount = model.TotalAmount,
            ShippingAddressId = model.SelectedAddressId,
            BillingAddressId = model.SelectedAddressId, // Fatura adresi aynı
            OrderDate = DateTime.Now,
            OrderItems = new List<OrderItem>() // OrderItems listesi başlatılıyor
        };

        // Siparişi veritabanına ekleyin
        _orderManager.Add(order);

        // Sipariş ID'sini alın
        var orderId = order.Id;

        // OrderItems'ı oluşturun
        foreach (var orderItemViewModel in model.OrderItems)
        {
            var orderItem = new OrderItem
            {
                OrderId = orderId, // Yeni siparişin ID'sini burada atayın
                ProductId = orderItemViewModel.ProductId,
                VariantId = orderItemViewModel.VariantId,
                Quantity = orderItemViewModel.Quantity,
                Price = orderItemViewModel.Price
            };

            // OrderItems tablosuna ekleyin
            _orderItemManager.Add(orderItem);
        }
        
        // Sepeti temizleyin (eğer gerekiyorsa)
         _shoppingCartManager.ClearCart(userId);

        var emptySCart = new ShoppingCart
        {
            UserId = userId,
            CreatedAt = DateTime.Now,
        };

        _shoppingCartManager.Add(emptySCart);

        return RedirectToAction("Index", "Home");
    }




}
