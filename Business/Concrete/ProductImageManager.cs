using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductImageManager : IProductImageService
    {
    
        private readonly IProductImageDal _productImageDal;

        public ProductImageManager(IProductImageDal productImageDal)
        {
            _productImageDal = productImageDal;
        }

        public void Add(ProductImage entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(ProductImage entity)
        {
            throw new NotImplementedException();
        }

        public List<ProductImage> GetAll()
        {
            throw new NotImplementedException();
        }
        public List<string> GetAllImageUrls(int productId)
        {
            return _productImageDal.List(i => i.ProductId == productId)
                            .Select(i => i.ImageUrl)
                            .ToList();
        }

        public ProductImage GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(ProductImage entity)
        {
            throw new NotImplementedException();
        }
    }
}
