using Data;
using Data.Models;

namespace Repository{
    public class CategoryRepository : ICategoryRepository
    {

        public readonly ExpenseTrackerContext _dbContext;
        public CategoryRepository(ExpenseTrackerContext dbContext){
            _dbContext = dbContext;
        }
        public bool AddCategory(Category category)
        {
            try{
                var result = _dbContext.Categories.Add(category);
               _dbContext.SaveChanges();

               return true;
            }
            catch(Exception ex){
                return false;
            }
        }

        public bool DeleteCategory(int categoryId)
        {
            try{
                var result = _dbContext.Categories.FirstOrDefault(record => record.Id == categoryId );
                _dbContext.Categories.Remove(result);
                _dbContext.SaveChanges();

                return true;
            }
            catch(Exception ex){
                return false;
            }
        }
    }
}