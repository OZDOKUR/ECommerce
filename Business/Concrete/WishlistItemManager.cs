using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;


namespace Business.Conccrete
{
    public class WishlistItemManager : IWishlistItemService
    {
        private readonly IWishlistItemDal _wishlistItemDal;
        private readonly IProductDal _productDal;

        public WishlistItemManager(IWishlistItemDal wishlistItemDal)
        {
            _wishlistItemDal = wishlistItemDal;

        }

        public void Add(WishlistItem entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(WishlistItem entity)
        {
            throw new NotImplementedException();
        }

        public List<WishlistItem> GetAll()
        {
            throw new NotImplementedException();
        }

        public WishlistItem GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(WishlistItem entity)
        {
            throw new NotImplementedException();
        }

        public List<WishlistItem> GetItemsByWishlistId(int id)
        {
            return _wishlistItemDal.List(x=> x.WishlistId == id);
        }

        public List<WishlistItem> GetAllByUserId(int userId)
        {
            return _wishlistItemDal.List(x => x.Id == userId);
        }

    }
}
