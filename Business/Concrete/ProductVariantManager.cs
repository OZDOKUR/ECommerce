using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Conccrete
{
    public class ProductVariantManager : IProductVariantService
    {
        private readonly IProductVariantDal _productVariantDal;
        private readonly IProductDal _productDal;

        public ProductVariantManager(IProductVariantDal productVariantDal)
        {
            _productVariantDal = productVariantDal;
        }

        public ProductVariantManager(IProductVariantDal productVariantDal, IProductDal productDal)
        {
            _productVariantDal = productVariantDal;
            _productDal = productDal;
        }

        public void Add(ProductVariant entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(ProductVariant entity)
        {
            throw new NotImplementedException();
        }

        public List<ProductVariant> GetAll()
        {
            return _productVariantDal.List();
        }

        public ProductVariant GetById(int id)
        {
            return _productVariantDal.Get(p => p.Id == id);
        }

        // Get all variants for a product by product name
        public List<ProductVariant> GetVariantsByProductName(string productName)
        {
            var productId = _productDal.List(p => p.ProductName == productName)
                .Select(p => p.Id)
                .FirstOrDefault();

            return productId == 0 ? new List<ProductVariant>() : _productVariantDal.List(v => v.ProductId == productId).ToList();
        }

        // Get all colors for a product by product name
        public List<string> GetColorsByProductName(string productName)
        {
            return GetVariantsByProductName(productName)
                .Select(v => v.Color)
                .Distinct()
                .ToList();
        }

        // Get all sizes for a product by product name
        public List<string> GetSizesByProductName(string productName)
        {
            return GetVariantsByProductName(productName)
                .Select(v => v.Size)
                .Distinct()
                .ToList();
        }
        
        public void Update(ProductVariant entity)
        {
            throw new NotImplementedException();
        }
        
            public ProductVariant GetVariantsBySKU(string sku)
        {
            return _productVariantDal.Get(p => p.SKU == sku);
        }
    }
}
