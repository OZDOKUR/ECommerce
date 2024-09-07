using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Xml.Linq;


namespace Business.Conccrete
{
    public class CategoryManager : ICategoryService
    {
        public readonly ICategoryDal _categoryDal;
        public readonly IProductDal _productDal;

        public CategoryManager(ICategoryDal categoryDal, IProductDal productDal)
        {
            _categoryDal = categoryDal;
            _productDal = productDal;
        }
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void Add(Category entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Category entity)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAll()
        {
            return _categoryDal.List();
        }

        public Category GetById(int id)
        {
            return _categoryDal.GetById(p => p.Id == id);
        }

        public void Update(Category entity)
        {
            throw new NotImplementedException();
        }

        public int GetProductCountByCategory(int categoryId)
        {
                return _productDal.List(p => p.CategoryId == categoryId).Count;  
        }

        public Category GetCategoryByName(string name)
        {
            return _categoryDal.Get(c => c.CategoryName == name);
        }
        
        public List<Category> GetOnlyGender()
        {
            return _categoryDal.List().Where(c => c.Id == 1 || c.Id == 5 || c.Id == 6).ToList();
        }
        public List<Category> GetCategoryByGender(string categoryName)
        {
            var categoryId = _categoryDal.Get(c=>c.CategoryName == categoryName).Id;
            var categories = _categoryDal.List(x => x.ParentCategoryId == categoryId);
            return categories;
        }
    }
}
