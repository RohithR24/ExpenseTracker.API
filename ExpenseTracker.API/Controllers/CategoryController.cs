using Data;
using Data.Models;
using DTO.Enumerators;
using Microsoft.AspNetCore.Mvc;
using Service.Impl;

namespace Controllers{

    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly ICategoryService _categoryRepository;
        public CategoryController(ILogger<UserController> logger, ICategoryService categoryRepository){
            _logger = logger;
            _categoryRepository = categoryRepository;
        }
        
        
        [HttpPost("")]
        public IResult AddNewCategory([FromBody] NewCategory newCategory, CategoryType categoryType)
        {
            _logger.LogInformation("Starting AddNewCategory method with UserID: {Email}", newCategory.UserId);

            try
            {
                var result = _categoryRepository.AddNewCategory(newCategory, categoryType);

                if (result)
                { 
                    return Results.Created();
                }
                else
                { 
                    return Results.BadRequest();
                }
            }
            catch (Exception ex)
            {
                
                return Results.StatusCode(500); // Internal Server Error
            }
            finally
            {
                _logger.LogInformation("Ending AddNewCategory method.");
            }
        }

    }
}