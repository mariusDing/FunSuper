using FunSuper.Server.Entities.Base;

namespace FunSuper.Server.Infrastructure.Super.Repositories.Base
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        Task BulkUpsert(List<TEntity> entities);

        Task Insert(TEntity entity);

        Task<TEntity> FindByIdAsync(object id);
    }
}
