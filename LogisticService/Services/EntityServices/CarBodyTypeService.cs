using LogisticService.Interfaces;
using LogisticService.Modules;
using Microsoft.EntityFrameworkCore;

namespace LogisticService.Services.EntityServices
{
    public class CarBodyTypeService : IServiceAsync<CarBodyType>
    {
        private readonly IEntityRepository<CarBodyType> _carBodyType;

        public CarBodyTypeService(IEntityRepository<CarBodyType> carBodyTypes)
        {
            _carBodyType = carBodyTypes;
        }

        public async Task AddAsync(CarBodyType instance)
        {
            await _carBodyType.AddAsync(instance);
        }

        public async Task RemoveAsync(int id)
        {
            var carBodyType = await _carBodyType.GetByPredicateAsync(c => c.Id == id);

            if (carBodyType != null)
            {
                await _carBodyType.DeleteAsync(carBodyType);
                return;
            }
        }

        public async Task UpdateAsync(CarBodyType updatedInstance)
        {
            await _carBodyType.UpdateAsync(updatedInstance);
        }

        public async Task<CarBodyType> GetByPredicateAsync(Func<CarBodyType, bool> predicate)
        {
            return await _carBodyType.GetByPredicateAsync(x => predicate(x));
        }

        public async Task<IEnumerable<CarBodyType>> GetAllAsync()
        {
            var carBodyTypes = _carBodyType.GetAll();

            if (!carBodyTypes.Any())
            {
                throw new ArgumentNullException();
            }
            return await carBodyTypes.ToListAsync();
        }
    }
}
