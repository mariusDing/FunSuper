using FunSuper.Server.Entities;
using FunSuper.Server.Infrastructure.Super.Repositories.Base;

namespace FunSuper.Server.Infrastructure.Super.Repositories
{
    public class PayslipRepository : SuperContextBaseRepository<Payslip>, IPayslipRepository
    {
        public PayslipRepository(SuperContext context) : base(context)
        {
        }
    }
}
