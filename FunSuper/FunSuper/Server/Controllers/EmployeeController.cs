using FunSuper.Server.Services;
using FunSuper.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FunSuper.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ISuperCalculationService _superCalculationService;

        public EmployeeController(ISuperCalculationService superCalculationService)
        {
            _superCalculationService = superCalculationService;
        }

        [HttpGet("{employeeId:int}/quarterly-total-super")]
        public async Task GetQuarterlySuper([FromRoute]int employeeId)
        {
            await _superCalculationService.CalculateEmployeeTotalQuarterlySuper(employeeId);
        }
    }
}