using LogisticService.Interfaces;
using LogisticService.Modules;
using LogisticService.Repositories.AdoNetRepositories;

namespace LogisticService.Services.AdoNetServices
{
    internal class InsuranceService : IService<Insurance>
    {
        public readonly DbInsuranceRepository _insuranceRepository;

        public event Action<string> ServiceEvent;

        public InsuranceService(DbInsuranceRepository insuranceRepository)
        {
            _insuranceRepository = insuranceRepository;
            ServiceEvent += message => Console.WriteLine(message);
        }

        public void Add(Insurance instance)
        {
            try
            {
                _insuranceRepository.Add(instance);
                ServiceEvent("Insurance added successfully");
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
                if (_insuranceRepository.ExistsById(id))
                {
                    _insuranceRepository.Remove(id);
                    ServiceEvent("Insurance removed successfully");
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
                var insurances = _insuranceRepository.GetAll();

                foreach (var item in insurances)
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
                var insurance = _insuranceRepository.GetById(id);
                Console.WriteLine(insurance);
            }
            catch (Exception ex)
            {
                ServiceEvent.Invoke(ex.Message);
            }
        }

        public void Update(Insurance updatedInstance)
        {
            try
            {
                if (_insuranceRepository.Update(updatedInstance))
                {
                    ServiceEvent("Insurance updated successfully!");
                    return;
                }
                ServiceEvent("Insurance has not been updated!");
            }
            catch (Exception ex)
            {
                ServiceEvent.Invoke(ex.Message);
            }
        }
    }
}
