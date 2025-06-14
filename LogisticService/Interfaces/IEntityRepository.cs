namespace LogisticService.Interfaces
{
    public interface IEntityRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity instance);

        Task DeleteAsync(TEntity instance);

        Task<TEntity> GetByPredicateAsync(Func<TEntity, bool> predicate);

        Task UpdateAsync(TEntity instance);

        IQueryable<TEntity> GetAll();
    }
}
