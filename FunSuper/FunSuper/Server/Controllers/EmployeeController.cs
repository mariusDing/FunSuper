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

        /// <summary>
        /// Get employee's quarterly total super for each year
        /// </summary>
        [HttpGet("{employeeId:int}/year-quarter-total-super")]
        public async Task<IEnumerable<GetYearQuarterTotalSuperResult>> GetYearQuarterTotalSuper([FromRoute]int employeeId)
        {
            var results = await _superCalculationService.CalculateEmployeeYearQuarterTotalSuper(employeeId);

            return results.Select(r => new GetYearQuarterTotalSuperResult
            {
                Year = r.Year,
                Quarter = r.Quarter,
                TotalOte = r.TotalOte,
                TotalSuperPayable = r.TotalSuperPayable,
                TotalDisbursement = r.TotalDisbursement
            });
        }
    }
}