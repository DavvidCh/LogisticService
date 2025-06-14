using LogisticService.Interfaces;
using LogisticService.Modules;
using LogisticService.Repositories.AdoNetRepositories;

namespace LogisticService.Services.AdoNetServices
{
    internal class DirectionService : IService<Direction>
    {
        public readonly DbDirectionRepository _directionRepository;

        public event Action<string> ServiceEvent;

        public DirectionService(DbDirectionRepository directionRepository)
        {
            _directionRepository = directionRepository;
            ServiceEvent += message => Console.WriteLine(message);
        }

        public void Add(Direction instance)
        {
            try
            {
                _directionRepository.Add(instance);
                ServiceEvent("Direction added successfully");
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
                if (_directionRepository.ExistsById(id))
                {
                    _directionRepository.Remove(id);
                    ServiceEvent("Direction removed successfully");
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
                var directions = _directionRepository.GetAll();

                foreach (var item in directions)
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
                var direction = _directionRepository.GetById(id);
                Console.WriteLine(direction);
            }
            catch (Exception ex)
            {
                ServiceEvent.Invoke(ex.Message);
            }
        }

        public void Update(Direction updatedInstance)
        {
            try
            {
                if (_directionRepository.Update(updatedInstance))
                {
                    ServiceEvent("Direction updated successfully!");
                    return;
                }
                ServiceEvent("Direction has not been updated!");
            }
            catch (Exception ex)
            {
                ServiceEvent.Invoke(ex.Message);
            }
        }
    }
}
