
namespace Entities.Concrete
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public int? ParentCategoryId { get; set; }
        public Category ParentCategory { get; set; }
        public string Description { get; set; }
        public string CategoryPicture { get; set; }
        public ICollection<Category> SubCategories { get; set; }
    }
}
