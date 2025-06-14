using LogisticService.Interfaces;
using LogisticService.Modules;
using LogisticService.Repositories.AdoNetRepositories;

namespace LogisticService.Services.AdoNetServices
{
    internal class CarBodyTypeService : IService<CarBodyType>
    {
        public DbCarBodyTypeRepository _carBodyTypeRepository;

        public event Action<string> ServiceEvent;

        public CarBodyTypeService(DbCarBodyTypeRepository carBodyTypeRepository)
        {
            _carBodyTypeRepository = carBodyTypeRepository;
            ServiceEvent += message => Console.WriteLine(message);
        }

        public void Add(CarBodyType instance)
        {
            try
            {
                _carBodyTypeRepository.Add(instance);
                ServiceEvent("Car Body Type added successfully");
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
                if (!_carBodyTypeRepository.ExistsById(id))
                {
                    ServiceEvent("Car Body Type not found");
                    return;
                }
                _carBodyTypeRepository.Remove(id);
                ServiceEvent("Car Body Type removed successfully");
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
                var carBodyTypes = _carBodyTypeRepository.GetAll();

                foreach (var item in carBodyTypes)
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
                var carBodyType = _carBodyTypeRepository.GetById(id);
                Console.WriteLine(carBodyType);
            }
            catch (Exception ex)
            {
                ServiceEvent.Invoke(ex.Message);
            }
        }

        public void Update(CarBodyType updatedInstance)
        {
            try
            {
                if (_carBodyTypeRepository.Update(updatedInstance))
                {
                    ServiceEvent("Car Body Type updated successfully!");
                    return;
                }
                ServiceEvent("Car Body Type has not been updated!");
            }
            catch (Exception ex)
            {
                ServiceEvent.Invoke(ex.Message);
            }
        }
    }
}
