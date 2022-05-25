using FunSuper.Server.Infrastructure.Super.Repositories;
using FunSuper.Server.Models;

namespace FunSuper.Server.Services;

public class SuperCalculationService : ISuperCalculationService
{
    private readonly IEmployeeRepository _employeeRepository;

    public SuperCalculationService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<IEnumerable<YearQuarterTotalSuperResult>> CalculateEmployeeYearQuarterTotalSuper(int employeeId)
    {
        var employee = await _employeeRepository.GetByIdAsync(employeeId);

        // Calculate total Ote and Super
        var results = employee.Payslips.Where(p => p.PayCode.IsOteTreament)
                                      .GroupBy(p => new { p.EndDate.ToUniversalTime().Year, 
                                                          Quarter = (p.EndDate.ToUniversalTime().Month + 2) / 3 },
                                              (gk, gv) => new YearQuarterTotalSuperResult
                                              {
                                                Year = gk.Year,
                                                Quarter = gk.Quarter,
                                                TotalOte = gv.Sum(p => p.Amount),
                                              }).ToList();
        // Calculate disbursement
        var disbursementResults = employee.Disbursements.GroupBy(p => new { p.PayMadeDate.ToUniversalTime().Year, 
                                                                     Quarter = (p.PayMadeDate.ToUniversalTime().Month + 2) / 3 }, 
                                                         (gk, gv) => new YearQuarterTotalSuperResult
                                                         {
                                                            Year = gk.Year,
                                                            Quarter = gk.Quarter,
                                                            TotalDisbursement = gv.Sum(d => d.SgcAmount),
                                                         }).ToList();

        // Merge disbursement to result
        disbursementResults.ForEach(d =>
        {
            var matched = results.FirstOrDefault(r => r.Year == d.Year && r.Quarter == d.Quarter);

            if (matched != null)
            {
                matched.TotalDisbursement = d.TotalDisbursement;
            } else
            {
                results.Add(d);
            }
        });

        return results;
    }
}