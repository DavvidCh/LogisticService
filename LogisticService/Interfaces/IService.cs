namespace LogisticService.Interfaces
{
    internal interface IService<T>
    {
        void Add(T instance);

        void Remove(int id);

        void Update(T updatedInstance);

        void ShowById(int id);

        void ShowAll();
    }
}
