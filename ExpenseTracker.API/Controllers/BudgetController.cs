using DTO.Create;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Service.Impl;

namespace Controller
{

    [Route("api/[controller]")]
    [ApiController]
    public class BudgetController : ControllerBase
    {
        private readonly ILogger<BudgetRepository> _logger;
        private readonly IBudgetService _budgetService;
        public BudgetController(ILogger<BudgetRepository> logger, IBudgetService budgetService)
        {
            _logger = logger;
            _budgetService = budgetService;
        }

        [HttpPost("")]
        public IResult AddBudget([FromBody] NewBudget newBudget)
        {
                var result = _budgetService.SetBudget(newBudget);
                if(result)
                {
                    return Results.Ok();
                }
                else{
                    return Results.BadRequest();
                }
            
        }
    }
}