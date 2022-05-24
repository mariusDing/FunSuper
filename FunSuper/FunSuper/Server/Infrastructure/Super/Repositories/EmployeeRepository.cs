using FunSuper.Server.Entities;
using FunSuper.Server.Infrastructure.Super.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace FunSuper.Server.Infrastructure.Super.Repositories
{
    public class EmployeeRepository : SuperContextBaseRepository<Employee>, IEmployeeRepository
    {
        private readonly DbSet<Employee> _dbSet;
        public EmployeeRepository(SuperContext context) : base(context)
        {
            _dbSet = context.Employees;
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _dbSet.Include(e => e.Disbursements)
                               .Include(e => e.Payslips).ThenInclude(p => p.PayCode)
                               .SingleOrDefaultAsync(e => e.EmployeeID == id);
        }

        public async Task<List<int>> GetIds()
        {
            return await _dbSet.Select(d => d.EmployeeID).ToListAsync();
        }
    }
}
