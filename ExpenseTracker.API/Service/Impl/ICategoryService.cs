using Data.Models;
using DTO.Enumerators;

namespace Service.Impl{
    
    public interface ICategoryService{
        public bool AddNewCategory(NewCategory newCategory, TransactionCategory categoryType);

        public bool DeleteCategory(int categoryId);
    }
}