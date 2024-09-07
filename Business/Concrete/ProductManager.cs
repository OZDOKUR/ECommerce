using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System.Xml.Linq;

namespace Business.Conccrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        private readonly IProductImageDal _productImageDal;
        private readonly IProductVariantDal _productVariantDal;
        private readonly ICategoryDal _categoryDal;

        public ProductManager(IProductDal productDal, ICategoryDal categoryDal)
        {
            _productDal = productDal;
            _categoryDal = categoryDal;
        }

        public ProductManager(IProductDal productDal, IProductImageDal productImageDal, IProductVariantDal productVariantDal)
        {
            _productDal = productDal;
            _productImageDal = productImageDal;
            _productVariantDal = productVariantDal;
        }

        public void Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _productDal.List();
        }

        public Product GetById(int productId)
        {
            return _productDal.GetById(p => p.Id == productId);
        }

        public Product GetByName(string name)
        {
            return _productDal.Get(p => p.ProductName == name);
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }

        public List<ProductVariant> GetVariantsByProductId(int productId)
        {
            return _productVariantDal.List(v => v.ProductId == productId);
        }

        public List<ProductImage> GetImagesByProductId(int productId)
        {
            return _productImageDal.List(i => i.ProductId == productId);
        }
        public List<ProductImage> GetImagesByName(string name)
        {
            var id = GetByName(name).Id;
            return _productImageDal.List(i => i.ProductId == id);
        }

        public List<ProductImage> GetImagesByVariantId(int variantId)
        {
            return _productImageDal.List(i => i.VariantId == variantId);
        }
        public string GetByProductCategory(string name)
        {
            var product = _productDal.Get(p => p.ProductName == name);
            if (product == null)
            {
                return null;
            }

            var category = _categoryDal.Get(c => c.Id == product.CategoryId);


            return category.CategoryName;
        }

        public decimal CalculatePrice(string SKU)
        {
            var itemBySku = _productVariantDal.Get(v => v.SKU == SKU);
            var Price = _productDal.Get(x => x.Id == itemBySku.ProductId).Price;
            var AdditionalPrice = itemBySku.AdditionalPrice;
            var totalPrice = Price + AdditionalPrice;
            return totalPrice;

        }

        public List<ProductImage> GetImagesByColor(string name, string color)
        {
            var product = _productDal.Get(p => p.ProductName == name);
            if (product == null)
            {
                return new List<ProductImage>();
            }

            return _productImageDal.List(pi => pi.ProductId == product.Id && pi.Variant.Color == color);
        }

        public List<Product> GetByGender(string gender) 
        {
            if (gender == "Erkek")
            {
                return _productDal.List(e=>e.Gender==0);
            }
            else if (gender == "Kadın")
            {
                return _productDal.List(e => e.Gender == 1);
            }
            else if (gender == "Çocuk")
            {
                return _productDal.List(e => e.Gender == 2);
            }
            return new List<Product>();
        }
    }
}
