using FunSuper.Server.Models;

namespace FunSuper.Server.Services;

public interface ISuperCalculationService
{
    Task<IEnumerable<YearQuarterTotalSuperResult>> CalculateEmployeeYearQuarterTotalSuper(int employeeId);
}