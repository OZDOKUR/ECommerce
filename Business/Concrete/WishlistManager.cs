using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Conccrete
{
    public class WishlistManager : IWishlistService
    {
        private readonly IWishlistDal _wishlistDal;

        public WishlistManager(IWishlistDal wishlistDal)
        {
            _wishlistDal = wishlistDal;
        }

        public void Add(Wishlist entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Wishlist entity)
        {
            throw new NotImplementedException();
        }

        public List<Wishlist> GetAll()
        {
            throw new NotImplementedException();
        }

        public Wishlist GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Wishlist entity)
        {
            throw new NotImplementedException();
        }

        public Wishlist GetByUserId(int id)
        {
            return _wishlistDal.Get(x=> x.UserId == id);
        }
        
    }
}
