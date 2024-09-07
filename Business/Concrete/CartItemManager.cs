using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Business.Conccrete
{
    public class CartItemManager : ICartItemService
    {
        private readonly ICartItemDal _cartItemDal;

        public CartItemManager(ICartItemDal cartItemDal)
        {
            _cartItemDal = cartItemDal;
        }

        public void Add(CartItem entity)
        {
            _cartItemDal.Add(entity);
        }
        public void AddVM(CartItem entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(CartItem entity)
        {
            throw new NotImplementedException();
        }

        public List<CartItem> GetAll()
        {
            throw new NotImplementedException();
        }

        public CartItem GetById(int id)
        {
            return _cartItemDal.GetById(id);
        }

        public void Update(CartItem entity)
        {
            var resultCart = _cartItemDal.GetById(entity.Id);
            if (resultCart != null)
            {
                resultCart.Quantity = entity.Quantity;
                
            }
        }
        public void UpdateQuantity(CartItem entity)
        {
            var resultCart = _cartItemDal.GetById(entity.Id);
            if (resultCart != null)
            {
                resultCart.Quantity = entity.Quantity;
                _cartItemDal.Update(resultCart);
            }
        }
        public List<CartItem> GetCartItemsByUserId(int userId)
        {
            return _cartItemDal.List(c => c.Cart.UserId == userId);
        }

        public void DeleteByProductId(int id)
        {
            var productId = _cartItemDal.Get(x=>x.ProductId == id);
            _cartItemDal.Delete(productId);
        }
    }
}
