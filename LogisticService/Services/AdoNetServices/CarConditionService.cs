using LogisticService.Interfaces;
using LogisticService.Modules;
using LogisticService.Repositories.AdoNetRepositories;

namespace LogisticService.Services.AdoNetServices
{
    internal class CarConditionService : IService<CarCondition>
    {
        public readonly DbCarConditionRepository _carConditionRepository;

        public event Action<string> ServiceEvent;

        public CarConditionService(DbCarConditionRepository carConditionRepository)
        {
            _carConditionRepository = carConditionRepository;
            ServiceEvent += message => Console.WriteLine(message);
        }

        public void Add(CarCondition instance)
        {
            try
            {
                _carConditionRepository.Add(instance);
                ServiceEvent("Car Condition added successfully");
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
                if (_carConditionRepository.ExistsById(id))
                {
                    _carConditionRepository.Remove(id);
                    ServiceEvent("Car Condition removed successfully");
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
                var carConditions = _carConditionRepository.GetAll();

                foreach (var item in carConditions)
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
                var carCondition = _carConditionRepository.GetById(id);
                Console.WriteLine(carCondition);
            }
            catch (Exception ex)
            {
                ServiceEvent.Invoke(ex.Message);
            }
        }

        public void Update(CarCondition updatedInstance)
        {
            try
            {
                if (_carConditionRepository.Update(updatedInstance))
                {
                    ServiceEvent("Car Condition updated successfully!");
                    return;
                }
                ServiceEvent("Car Condition has not been updated!");
            }
            catch (Exception ex)
            {
                ServiceEvent.Invoke(ex.Message);
            }
        }
    }
}
