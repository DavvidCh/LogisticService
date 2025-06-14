using LogisticService.Interfaces;
using LogisticService.Modules;
using LogisticService.Repositories.AdoNetRepositories;

namespace LogisticService.Services.AdoNetServices
{
    internal class ContainerService : IService<Container>
    {
        public readonly DbContainerRepository _carContainerRepository;

        public event Action<string> ServiceEvent;

        public ContainerService(DbContainerRepository carContainerRepository)
        {
            _carContainerRepository = carContainerRepository;
            ServiceEvent += message => Console.WriteLine(message);
        }

        public void Add(Container instance)
        {
            try
            {
                _carContainerRepository.Add(instance);
                ServiceEvent("Container added successfully");
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
                if (_carContainerRepository.ExistsById(id))
                {
                    _carContainerRepository.Remove(id);
                    ServiceEvent("Container removed successfully");
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
                var carContainer = _carContainerRepository.GetAll();

                foreach (var item in carContainer)
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
                var carContainer = _carContainerRepository.GetById(id);
                Console.WriteLine(carContainer);
            }
            catch (Exception ex)
            {
                ServiceEvent.Invoke(ex.Message);
            }
        }

        public void Update(Container updatedInstance)
        {
            try
            {
                if (_carContainerRepository.Update(updatedInstance))
                {
                    ServiceEvent("Container updated successfully!");
                    return;
                }
                ServiceEvent("Container has not been updated!");
            }
            catch (Exception ex)
            {
                ServiceEvent.Invoke(ex.Message);
            }
        }
    }
}
