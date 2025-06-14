using LogisticService.Interfaces;
using LogisticService.Modules;
using LogisticService.Repositories.AdoNetRepositories;

namespace LogisticService.Services.AdoNetServices
{
    internal class CarModelService : IService<CarModel>
    {
        private readonly DbCarModelRepository _carModelRepository;

        private readonly DbCarBodyTypeRepository _carBodyTypeRepository;

        public event Action<string> ServiceEvent;

        public CarModelService(
            DbCarModelRepository dbCarModelRepository,
            DbCarBodyTypeRepository dbCarBodyTypeRepository)
        {
            _carModelRepository = dbCarModelRepository;
            _carBodyTypeRepository = dbCarBodyTypeRepository;
            ServiceEvent += message => Console.WriteLine(message);
        }

        public void Add(CarModel instance)
        {
            try
            {
                if (_carModelRepository.Exists(instance.Model, instance.Year))
                {
                    ServiceEvent($"{instance.Model} is already exists!");
                    return;
                }

                instance.CarBodyTypeId = _carBodyTypeRepository.GetCarBodyTypeIdByName(instance.CarBodyType.BodyType.ToString());
                //instance.CarId = ???????????

                _carModelRepository.Add(instance);
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
                if (!_carModelRepository.ExistsById(id))
                {
                    ServiceEvent("Car Model not found!");
                    return;
                }
                _carModelRepository.Remove(id);
                ServiceEvent("Car Model removed successfully");
            }
            catch (Exception ex)
            {
                ServiceEvent(ex.Message);
            }
        }

        public void Update(CarModel updatedInstance)
        {
            try
            {
                if (_carModelRepository.Update(updatedInstance))
                {
                    ServiceEvent("Car Model updated successfully!");
                    return;
                }
                ServiceEvent("Car Model has not been updated!");
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
                var carModel = _carModelRepository.GetById(id);
                if (carModel != null)
                {
                    carModel.CarBodyType = _carBodyTypeRepository.GetCarBodyTypeById(carModel.CarBodyTypeId);
                    Console.WriteLine(carModel);
                    return;
                }
                Console.WriteLine("Car Model not found");
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
                var carModels = _carModelRepository.GetAll();
                foreach (var carModel in carModels)
                {
                    carModel.CarBodyType = _carBodyTypeRepository.GetCarBodyTypeById(carModel.CarBodyTypeId);
                }

                foreach (var item in carModels)
                {
                    Console.WriteLine(item);
                }
            }
            catch (Exception ex)
            {
                ServiceEvent.Invoke(ex.Message);
            }
        }
    }
}
