using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;


namespace Business.Conccrete
{
    public class BrandManager : IBrandService
    {
        private readonly IBrandDal _brandDal;
        private readonly IProductDal _productDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }public BrandManager(IBrandDal brandDal, IProductDal productDal)
        {
            _brandDal = brandDal;
            _productDal = productDal;
        }

        public void Add(Brand entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Brand entity)
        {
            throw new NotImplementedException();
        }

        public List<Brand> GetAll()
        {
            return _brandDal.List();
        }

        public Brand GetById(int id)
        {
            return _brandDal.GetById(p => p.Id == id);
        }

        public void Update(Brand entity)
        {
            throw new NotImplementedException();
        }

        public string BrandByName(string name)
        {
            var product = _productDal.Get(a=> a.ProductName == name).BrandId;
            var brandName = _brandDal.Get(b => b.Id == product).Name;
            return brandName;
        }
    }
}
