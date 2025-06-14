using LogisticService.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LogisticService.Repositories.EntityRepositories
{
    public class Repository<TDbContext, TEntity> : IEntityRepository<TEntity>
        where TDbContext : DbContext
        where TEntity : class
    {
        private readonly TDbContext _dataContext;

        public Repository(TDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddAsync(TEntity instance)
        {
            await _dataContext.Set<TEntity>().AddAsync(instance);
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity instance)
        {
            _dataContext.Set<TEntity>().Remove(instance);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<TEntity> GetByPredicateAsync(Func<TEntity, bool> predicate)
        {
            return (await _dataContext.Set<TEntity>().FirstOrDefaultAsync(x => predicate(x)))!;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dataContext.Set<TEntity>().AsQueryable();
        }

        public async Task UpdateAsync(TEntity instance)
        {
            _dataContext.Set<TEntity>().Update(instance);
            await _dataContext.SaveChangesAsync();
        }
    }
}
