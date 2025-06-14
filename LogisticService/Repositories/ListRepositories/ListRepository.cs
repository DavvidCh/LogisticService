using LogisticService.Interfaces;

namespace LogisticService.Repositories.ListRepositories
{
    internal class ListRepository<T> : IListRepository<T> where T : class
    {
        public ListRepository(Action<List<T>> initializeData)
        {
            initializeData.Invoke(_repository);
        }

        public ListRepository()
        {
        }

        private readonly List<T> _repository = new List<T>();

        public void Add(T instance)
        {
            _repository.Add(instance);
        }

        public void Remove(T instance)
        {
            _repository.Remove(instance);
        }

        public T? Get(Func<T, bool> predicate)
        {
            foreach (var item in _repository)
            {
                if (predicate(item))
                {
                    return item;
                }
            }
            return null;
        }

        public bool Update(Func<T, bool> predicate, T updatedInstance)
        {
            bool result = false;
            _repository.ForEach(x =>
            {
                if (predicate(x))
                {
                    int index = _repository.IndexOf(x);
                    _repository[index] = updatedInstance;
                    result = true;
                }
            });
            return result;
        }

        public IEnumerable<T> GetAll()
        {
            return _repository;
        }

        public bool Contain(Func<T, bool> predicate)
        {
            bool result = false;
            _repository.ForEach(item =>
            {
                if (predicate(item))
                {
                    result = true;
                }
            });
            return result;
        }
    }
}
