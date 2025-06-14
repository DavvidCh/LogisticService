namespace LogisticService.Interfaces
{
    internal interface IListRepository<T>
    {
        void Add(T instance);

        bool Update(Func<T, bool> predicate, T updatedInstance);

        bool Contain(Func<T, bool> predicate);

        T? Get(Func<T, bool> predicate);

        IEnumerable<T> GetAll();

        void Remove(T item);
    }
}
