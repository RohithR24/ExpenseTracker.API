using Data.Models;

namespace Repository{
    public interface ICategoryRepository{
        public bool AddCategory(Category category);
        public bool DeleteCategory(int categoryId);
    }
}