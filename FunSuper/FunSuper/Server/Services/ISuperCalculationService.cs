namespace FunSuper.Server.Services;

public interface ISuperCalculationService
{
    Task CalculateEmployeeTotalQuarterlySuper(int employeeId);
}