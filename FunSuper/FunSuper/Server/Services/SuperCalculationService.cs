using FunSuper.Server.Infrastructure.Super.Repositories;

namespace FunSuper.Server.Services;

public class SuperCalculationService
{
    private readonly IEmployeeRepository _employeeRepository;

    public SuperCalculationService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task CalculateEmployeeTotalQuarterlySuper(int employeeId)
    {
        var yearlyQuarter = new Dictionary<int, List<double>>();

        var employee = await _employeeRepository.GetByIdAsync(employeeId);

        var groupByYear = employee.Payslips.Where(p => p.PayCode.IsOteTreament)
                                                                  .GroupBy(p => p.EndDate.ToUniversalTime().Year);

        var aasd = employee.Payslips.Where(p => p.PayCode.IsOteTreament)
            .GroupBy(p => new {p.EndDate.ToUniversalTime().Year, Month = (p.EndDate.ToUniversalTime().Month - 1) / 3},
                (k, g) =>new
                {
                    Y = k.Year,
                    J = k.Month,
                    tCharge = g.Sum(pg=> pg.Amount)
                });
        // SelectMany, GroupBy,Select
        foreach (var yearGroup in groupByYear)
        {
            yearlyQuarter.Add(yearGroup.Key, new List<double>());

            var groupByQuarterly = yearGroup.GroupBy(yg => (yg.EndDate.ToUniversalTime().Month - 1) / 3);

            foreach (var quarterlyGroup in groupByQuarterly)
            {
                var sum = quarterlyGroup.Sum(p => p.Amount) * 0.095;

                yearlyQuarter[yearGroup.Key].Add(sum);
            }
        }
        //
        // var aaaa = new Dictionary<int, Dictionary<int, double>>();
        // var asdds = new List<(int, List<(int, double)>)>();
        // // <2017, <1, 29>
        // // <2017, <2, 30>
        // // <2019, <3,32>
        // // <2017, [123,423,423,123]>
    }
}