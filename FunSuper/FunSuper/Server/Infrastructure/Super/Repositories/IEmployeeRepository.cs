using FunSuper.Server.Entities;
using FunSuper.Server.Infrastructure.Super.Repositories.Base;

namespace FunSuper.Server.Infrastructure.Super.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<Employee> GetByIdAsync(int id);

        Task<List<int>> GetIds();
    }
}
