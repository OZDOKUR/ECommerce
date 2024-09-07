using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;


namespace Business.Conccrete
{
    public class ShoppingCartManager : IShoppingCartService
    {
        private readonly IShopingCartDal _shopingCartManager;

        public ShoppingCartManager(IShopingCartDal shopingCartManager)
        {
            _shopingCartManager = shopingCartManager;
        }

        public void Add(ShoppingCart entity)
        {
            _shopingCartManager.Add(entity);
        }

        public void Delete(ShoppingCart entity)
        {
            throw new NotImplementedException();
        }

        public List<ShoppingCart> GetAll()
        {
            throw new NotImplementedException();
        }

        public ShoppingCart GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(ShoppingCart entity)
        {
            throw new NotImplementedException();
        }
        public List<ShoppingCart> GetCartItemsByUserId(int userId)
        {
            return _shopingCartManager.List(c => c.UserId == userId);
        }

        public ShoppingCart GetCartByUserId(string userId)
        {
           var userIntId = int.Parse(userId);
            return _shopingCartManager.Get(c => c.UserId == userIntId);
        }

        public void ClearCart(int userId)
        {
            
            var cartItems = _shopingCartManager.List(ci => ci.UserId == userId);


            foreach (var cartItem in cartItems)
            {
                _shopingCartManager.Delete(cartItem);
            }

            // Kullanıcının sepetini temizle
            var shoppingCart = _shopingCartManager.Get(sc => sc.UserId == userId);
            if (shoppingCart != null)
            {
                _shopingCartManager.Delete(shoppingCart);

            }
        }
    }
}
