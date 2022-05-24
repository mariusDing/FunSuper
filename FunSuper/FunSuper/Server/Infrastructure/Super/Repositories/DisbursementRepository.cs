using FunSuper.Server.Entities;
using FunSuper.Server.Infrastructure.Super.Repositories.Base;

namespace FunSuper.Server.Infrastructure.Super.Repositories
{
    public class DisbursementRepository : SuperContextBaseRepository<Disbursement>, IDisbursementRepository
    {
        public DisbursementRepository(SuperContext context) : base(context)
        {
        }
    }
}
