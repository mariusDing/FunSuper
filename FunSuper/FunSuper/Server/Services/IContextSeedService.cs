using FunSuper.Server.Models;
using System.Data;

namespace FunSuper.Server.Services
{
    public interface IContextSeedService
    {
        Task<SeedSuperContextResult> SeedSuperContext(DataSet dataSet);
    }
}
