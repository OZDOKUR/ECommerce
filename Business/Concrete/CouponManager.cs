using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;


namespace Business.Conccrete
{
    public class CouponManager : ICouponService
    {
        private readonly ICouponDal _couponDal;

        public CouponManager(ICouponDal couponDal)
        {
            _couponDal = couponDal;
        }

        public void Add(Coupon entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Coupon entity)
        {
            throw new NotImplementedException();
        }

        public List<Coupon> GetAll()
        {
            throw new NotImplementedException();
        }

        public Coupon GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Coupon entity)
        {
            throw new NotImplementedException();
        }
    }
}
