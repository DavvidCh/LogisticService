using LogisticService.Data;
using LogisticService.Interfaces;
using LogisticService.Requests;
using Microsoft.EntityFrameworkCore;

namespace LogisticService.Calculations
{
    internal class CalculationService : ICalculationService, ICalculationModelConstructor
    {
        private readonly DataContext _dataContext;

        public CalculationService()
        {
        }

        public CalculationService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public decimal? Calculate(CalculationModel calculationModel)
        {
            var totalCoefficient =
                calculationModel.CarBodyType?.Coefficient *
                calculationModel.Container?.Coefficient *
                calculationModel.Transit?.Coefficient *
                calculationModel.Insurance?.Coefficient *
                calculationModel.Condition?.Coefficient;

            return calculationModel.Direction?.Price != default ?
                    calculationModel.Direction?.Price * totalCoefficient :
                     calculationModel.Direction?.Distance * 100 * totalCoefficient ?? 0;
        }

        public async Task<CalculationModel> GetCalculationModelAsync(UserRequest userRequest)
        {
            var car = await _dataContext.Cars.FirstOrDefaultAsync(car => car.Mark.ToLower() == userRequest.Mark.ToLower());

            var carModel = car?.CarModels.FirstOrDefault(
                model => model.Model.ToLower() == userRequest.Model.ToLower() &&
                    model.Year == userRequest.Year);

            var carBodyType = carModel?.CarBodyType;

            var condition = await _dataContext.CarConditions.FirstOrDefaultAsync(condition => condition.IsRunning == userRequest.IsRunning);

            var container = await _dataContext.Containers.FirstOrDefaultAsync(container => container.IsClosed == userRequest.IsClosed);

            var direction = await _dataContext.Directions.FirstOrDefaultAsync(direction =>
                (direction.FromLocation.ToLower() == userRequest.FromLocation.ToLower() &&
                    direction.ToLocation.ToLower() == userRequest.ToLocation.ToLower()) ||
                (direction.FromLocation.ToLower() == userRequest.ToLocation.ToLower() &&
                    direction.ToLocation.ToLower() == userRequest.FromLocation.ToLower()));

            var insurance = await _dataContext.Insurances.FirstOrDefaultAsync(insurance => insurance.IsIncluded == userRequest.IsIncluded);

            var transit = await _dataContext.Transits.FirstOrDefaultAsync(transit => transit.DayCount == userRequest.DayCount);

            return new CalculationModel(carBodyType, condition, container, direction, insurance, transit);
        }
    }
}
