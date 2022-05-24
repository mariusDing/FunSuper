using FunSuper.Server.Entities;
using FunSuper.Server.Infrastructure.Super.Repositories.Base;

namespace FunSuper.Server.Infrastructure.Super.Repositories
{
    public class PayCodeRepository : SuperContextBaseRepository<PayCode>, IPayCodeRepository
    {
        public PayCodeRepository(SuperContext context) : base(context)
        {
        }
    }
}
