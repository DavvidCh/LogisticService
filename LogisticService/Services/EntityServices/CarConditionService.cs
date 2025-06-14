using LogisticService.Interfaces;
using LogisticService.Modules;
using Microsoft.EntityFrameworkCore;

namespace LogisticService.Services.EntityServices
{
    public class CarConditionService : IServiceAsync<CarCondition>
    {
        private readonly IEntityRepository<CarCondition> _carCondition;

        public CarConditionService(IEntityRepository<CarCondition> carCondition)
        {
            _carCondition = carCondition;
        }

        public async Task AddAsync(CarCondition instance)
        {
            await _carCondition.AddAsync(instance);
        }

        public async Task RemoveAsync(int id)
        {
            var carCondition = await _carCondition.GetByPredicateAsync(c => c.Id == id);

            if (carCondition != null)
            {
                await _carCondition.DeleteAsync(carCondition);
                return;
            }
        }

        public async Task UpdateAsync(CarCondition updatedInstance)
        {
            await _carCondition.UpdateAsync(updatedInstance);
        }

        public async Task<CarCondition> GetByPredicateAsync(Func<CarCondition, bool> predicate)
        {
            return await _carCondition.GetByPredicateAsync(x => predicate(x));
        }

        public async Task<IEnumerable<CarCondition>> GetAllAsync()
        {
            var carConditions = _carCondition.GetAll();

            if (!carConditions.Any())
            {
                throw new ArgumentNullException();
            }
            return await carConditions.ToListAsync();
        }
    }
}
