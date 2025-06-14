using LogisticService.Calculations;
using LogisticService.Interfaces;
using LogisticService.Modules;
using LogisticService.Requests;
using LogisticService.Users;

namespace LogisticService.Data
{
    internal class ListData
    {
        private IListRepository<Car> _cars;
        private IListRepository<CarBodyType> _carBodyTypes;
        private IListRepository<CarCondition> _conditions;
        private IListRepository<Container> _containers;
        private IListRepository<Direction> _directions;
        private IListRepository<Insurance> _insurances;
        private IListRepository<Transit> _transits;
        private IListRepository<User> _users;

        public ListData(
            IListRepository<Car> cars,
            IListRepository<CarBodyType> carBodyTypes,
            IListRepository<CarCondition> conditions,
            IListRepository<Container> containers,
            IListRepository<Direction> directions,
            IListRepository<Insurance> insuranceTypes,
            IListRepository<Transit> transits,
            IListRepository<User> users)
        {
            _cars = cars;
            _conditions = conditions;
            _carBodyTypes = carBodyTypes;
            _containers = containers;
            _directions = directions;
            _insurances = insuranceTypes;
            _transits = transits;
            _users = users;
        }
        public ListData()
        {
        }

        public IListRepository<Car> GetCars() => _cars;
        public IListRepository<CarBodyType> GetBodyTypes() => _carBodyTypes;
        public IListRepository<CarCondition> GetCarConditions() => _conditions;
        public IListRepository<Container> GetCarContainers() => _containers;
        public IListRepository<Direction> GetDirections() => _directions;
        public IListRepository<Insurance> GetInsuranceTypes() => _insurances;
        public IListRepository<Transit> GetTransits() => _transits;
        public IListRepository<User> GetUsers() => _users;

        public CalculationModel GetCalculationModel(UserRequest userRequest)
        {
            var car = _cars.Get(car => car.Mark.ToLower() == userRequest.Mark.ToLower());

            var carModel = car.CarModels.FirstOrDefault(
                model => model.Model.ToLower() == userRequest.Model.ToLower() &&
                model.Year == userRequest.Year);

            var carBodyType = carModel.CarBodyType;

            var condition = _conditions.Get(condition => condition.IsRunning == userRequest.IsRunning);
            var container = _containers.Get(container => container.IsClosed == userRequest.IsClosed);

            var direction = _directions.Get(direction =>
                (direction.FromLocation.ToLower() == userRequest.ToLocation.ToLower() &&
                direction.ToLocation.ToLower() == userRequest.ToLocation.ToLower()) ||
                (direction.FromLocation.ToLower() == userRequest.ToLocation.ToLower() &&
                direction.ToLocation.ToLower() == userRequest.FromLocation.ToLower()));

            var insurance = _insurances.Get(insurance => insurance.IsIncluded == userRequest.IsIncluded);
            var transit = _transits.Get(transit => transit.DayCount == userRequest.DayCount);

            return new CalculationModel(carBodyType, condition, container, direction, insurance, transit);
        }
    }
}
