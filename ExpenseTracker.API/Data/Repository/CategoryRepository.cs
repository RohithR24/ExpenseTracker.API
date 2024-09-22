using System;
using Data;
using Data.Models;
using Microsoft.Extensions.Logging;

namespace Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ExpenseTrackerContext _dbContext;
        private readonly ILogger<CategoryRepository> _logger;

        public CategoryRepository(ExpenseTrackerContext dbContext, ILogger<CategoryRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public bool AddCategory(Category category)
        {
            try
            {
                _logger.LogInformation("Attempting to add category: {CategoryName}", category.Name);

                var result = _dbContext.Categories.Add(category);
                _dbContext.SaveChanges();

                _logger.LogInformation("Category added successfully: {CategoryName}", category.Name);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding category: {CategoryName}", category.Name);
                return false;
            }
        }

        public bool DeleteCategory(int categoryId)
        {
            try
            {
                _logger.LogInformation("Attempting to delete category with ID: {CategoryId}", categoryId);

                var result = _dbContext.Categories.FirstOrDefault(record => record.Id == categoryId);
                if (result == null)
                {
                    _logger.LogWarning("Category with ID: {CategoryId} not found", categoryId);
                    return false;
                }

                _dbContext.Categories.Remove(result);
                _dbContext.SaveChanges();

                _logger.LogInformation("Category with ID: {CategoryId} deleted successfully", categoryId);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting category with ID: {CategoryId}", categoryId);
                return false;
            }
        }
    }
}
