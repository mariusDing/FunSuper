using FunSuper.Server.Models;

namespace FunSuper.Server.Services;

public interface ISuperCalculationService
{
    Task<List<YearQuarterTotalSuperResult>> CalculateEmployeeYearQuarterTotalSuper(int employeeId);
}