using Data;
using DTO.Enumerators;

namespace Controllers{

    public static class CategoryController{

        public static RouteGroupBuilder AllCategoryAPIs(this WebApplication webApplication)
        {
            var group = webApplication.MapGroup("category");

            group.MapGet("/", () => "Category");

            group.MapPost("/", (NewCategory newCategory,CategoryType categoryType, ExpenseTrackerContext dbContext) => {

                Category category = new Category(){
                    UserId = newCategory.UserId,
                    Name = newCategory.Name,
                    Type = (CategoryType.Income == categoryType) ? CategoryType.Income.ToString() : CategoryType.Expense.ToString()
                };

                dbContext.Categories.Add(category);
                dbContext.SaveChanges();

            });

            return group;
        }

    }
}