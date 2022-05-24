using EFCore.BulkExtensions;
using FunSuper.Server.Entities.Base;

namespace FunSuper.Server.Infrastructure.Super.Repositories.Base
{
    public abstract class SuperContextBaseRepository<TEntity> where TEntity : Entity 
    {
        private readonly SuperContext _context;

        protected SuperContextBaseRepository(SuperContext context)
        {
            _context = context;
        }

        public virtual async Task BulkUpsert(List<TEntity> entities)
        {
            await _context.BulkInsertOrUpdateAsync(entities);
        }

        public virtual async Task Insert(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<TEntity> FindByIdAsync(object id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }
    }
}
