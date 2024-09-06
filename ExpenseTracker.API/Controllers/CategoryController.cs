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
        private readonly ICategoryService _categoryService;
        public CategoryController(ILogger<UserController> logger, ICategoryService categoryService){
            _logger = logger;
            _categoryService = categoryService;
        }
        
        
        [HttpPost("")]
        public IResult AddNewCategory([FromBody] NewCategory newCategory,[FromQuery] TransactionCategory categoryType)
        {
            _logger.LogInformation("Starting AddNewCategory method with UserID: {Email}", newCategory.UserId);

            try
            {
                var result = _categoryService.AddNewCategory(newCategory, categoryType);

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

        [HttpDelete("{CategoryId}")]
        public IResult DeleteCategory(int CategoryId){
            if(_categoryService.DeleteCategory(CategoryId)){
                return Results.Ok();
            }
            else{
                return Results.BadRequest();
            }
        }

    }
}