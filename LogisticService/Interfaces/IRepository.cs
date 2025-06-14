namespace LogisticService.Interfaces
{
	internal interface IRepository<T>
	{
        void Add(T instance);

        void Remove(int id);

        bool Update(T updatedInstance);

        bool ExistsById(int id);

        T? GetById(int id);

        IEnumerable<T> GetAll();
    }
}
