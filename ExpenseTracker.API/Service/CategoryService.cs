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
        public bool AddNewCategory(NewCategory newCategory, CategoryType categoryType)
        {
            Category category = new Category(){
                UserId = newCategory.UserId,
                Name = newCategory.Name,
                Type = (CategoryType.Income == categoryType) ? CategoryType.Income.ToString() : CategoryType.Expense.ToString()
            };
            return _categoryRepository.AddCategory(category);
        }
    }
}