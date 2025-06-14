using LogisticService.Interfaces;
using LogisticService.Modules;
using LogisticService.Repositories.AdoNetRepositories;

namespace LogisticService.Services.AdoNetServices
{
    internal class CarService : IService<Car>
    {
        private readonly DbCarRepository _carRepository;

        private readonly DbCarModelRepository _carModelRepository;

        private readonly DbCarBodyTypeRepository _carBodyTypeRepository;

        public event Action<string> ServiceEvent;

        public CarService(
            DbCarRepository carRepository,
            DbCarModelRepository carModelRepository,
            DbCarBodyTypeRepository carBodyTypeRepository)
        {
            _carRepository = carRepository;
            _carModelRepository = carModelRepository;
            _carBodyTypeRepository = carBodyTypeRepository;
            ServiceEvent += message => Console.WriteLine(message);
        }

        public CarService()
        {
        }

        public void Add(Car instance)
        {
            if (_carRepository.Exists(instance.Mark))
            {
                ServiceEvent($"{instance.Mark} is already exists!");
                return;
            }

            _carRepository.Add(instance);

            foreach (var carModel in instance.CarModels)
            {
                if (_carModelRepository.Exists(carModel.Model, carModel.Year))
                {
                    ServiceEvent($"{carModel.Model} {carModel.Year} is already exists");
                    continue;
                }
                _carModelRepository.Add(carModel);
            }
        }

        public void Remove(int id)
        {
            try
            {
                if (!_carRepository.ExistsById(id))
                {
                    ServiceEvent($"Car not found");
                    return;
                }
                _carRepository.Remove(id);

                var carModels = _carModelRepository.GetCarModelsByCarId(id);
                foreach (var carModel in carModels)
                {
                    _carModelRepository.Remove(carModel.Id);
                }
                ServiceEvent("Car and Models removed successfully!");
            }
            catch (Exception ex)
            {
                ServiceEvent(ex.Message);
            }
        }

        public void Update(Car updatedInstance)
        {
            try
            {
                bool carFlag = _carRepository.Update(updatedInstance);
                bool modelFlag = false;

                if (carFlag)
                {
                    foreach (var carModel in updatedInstance.CarModels)
                    {
                        modelFlag = _carModelRepository.Update(carModel);
                        if (!modelFlag)
                        {
                            ServiceEvent($"{carModel.Model} is not updated!");
                            return;
                        }
                    }
                    ServiceEvent("Car and Models updated successfully!");
                    return;
                }
                ServiceEvent("The Car has not been updated!");
            }
            catch (Exception ex)
            {
                ServiceEvent(ex.Message);
            }
        }

        public void ShowById(int id)
        {
            try
            {
                var car = _carRepository.GetById(id);
                if (car != null)
                {
                    car.CarModels = _carModelRepository.GetCarModelsByCarId(id).ToList();
                }

                Console.WriteLine($"--------------{car.Mark}--------------");
                foreach (var carModel in car.CarModels)
                {
                    Console.WriteLine(carModel);
                }
            }
            catch (Exception ex)
            {
                ServiceEvent(ex.Message);
            }
        }

        public void ShowAll()
        {
            try
            {
                var cars = GetAllCars();

                if (cars != null)
                {

                    foreach (var car in cars)
                    {
                        Console.WriteLine($"--------------{car.Mark}--------------");
                        foreach (var carModel in car.CarModels)
                        {
                            Console.WriteLine(carModel);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ServiceEvent(ex.Message);
            }
        }

        private IEnumerable<Car>? GetAllCars()
        {
            try
            {
                var cars = _carRepository.GetAll();

                foreach (var car in cars)
                {
                    if (car != null)
                    {
                        car.CarModels = _carModelRepository.GetCarModelsByCarId(car.Id).ToList();

                        foreach (var carModel in car.CarModels)
                        {
                            carModel.CarBodyType = _carBodyTypeRepository.GetCarBodyTypeById(carModel.CarBodyTypeId);
                        }
                    }
                }
                return cars;
            }
            catch (Exception ex)
            {
                ServiceEvent(ex.Message);
            }
            return null;
        }
    }
}
