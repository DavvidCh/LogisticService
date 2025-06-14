using LogisticService.Interfaces;
using LogisticService.Modules;
using LogisticService.Repositories.AdoNetRepositories;

namespace LogisticService.Services.AdoNetServices
{
    internal class TransitService : IService<Transit>
    {
        public readonly DbTransitRepository _transitRepository;

        public event Action<string> ServiceEvent;

        public TransitService(DbTransitRepository transitRepository)
        {
            _transitRepository = transitRepository;
            ServiceEvent += message => Console.WriteLine(message);
        }

        public void Add(Transit instance)
        {
            try
            {
                _transitRepository.Add(instance);
                ServiceEvent("Transit added successfully");
            }
            catch (Exception ex)
            {
                ServiceEvent(ex.Message);
            }
        }

        public void Remove(int id)
        {
            try
            {
                if (_transitRepository.ExistsById(id))
                {
                    _transitRepository.Remove(id);
                    ServiceEvent("Transit removed successfully");
                }
            }
            catch (Exception ex)
            {
                ServiceEvent.Invoke(ex.Message);
            }
        }

        public void ShowAll()
        {
            try
            {
                var transits = _transitRepository.GetAll();

                foreach (var item in transits)
                {
                    Console.WriteLine(item);
                }
            }
            catch (Exception ex)
            {
                ServiceEvent.Invoke(ex.Message);
            }
        }

        public void ShowById(int id)
        {
            try
            {
                var transit = _transitRepository.GetById(id);
                Console.WriteLine(transit);
            }
            catch (Exception ex)
            {
                ServiceEvent.Invoke(ex.Message);
            }
        }

        public void Update(Transit updatedInstance)
        {
            try
            {
                if (_transitRepository.Update(updatedInstance))
                {
                    ServiceEvent("Transit updated successfully!");
                    return;
                }
                ServiceEvent("Transit has not been updated!");
            }
            catch (Exception ex)
            {
                ServiceEvent.Invoke(ex.Message);
            }
        }
    }
}
