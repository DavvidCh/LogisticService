namespace LogisticService.Interfaces
{
    internal interface IServiceAsync<T>
    {
        Task AddAsync(T instance);

        Task RemoveAsync(int id);

        Task UpdateAsync(T updatedInstance);

        Task<T> GetByPredicateAsync(Func<T, bool> predicate);

        Task<IEnumerable<T>> GetAllAsync();
    }
}
