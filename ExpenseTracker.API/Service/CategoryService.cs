using Data.Models;
using DTO.Enumerators;
using Repository;
using Service.Impl;

namespace Service{
    public class CategoryService : ICategoryService
    {
        ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository){
            _categoryRepository = categoryRepository;
        }
        public bool AddNewCategory(NewCategory newCategory, TransactionCategory categoryType)
        {
            Category category = new Category(){
                UserId = newCategory.UserId,
                Name = newCategory.Name,
                Type = (TransactionCategory.Income == categoryType) ? TransactionCategory.Income.ToString() : TransactionCategory.Expense.ToString()
            };
            return _categoryRepository.AddCategory(category);
        }
    }
}