using LogisticService.Interfaces;
using LogisticService.Modules;
using Microsoft.EntityFrameworkCore;

namespace LogisticService.Services.EntityServices
{
    public class CarService : IServiceAsync<Car>
    {
        private readonly IEntityRepository<Car> _cars;

        public CarService(IEntityRepository<Car> cars)
        {
            _cars = cars;
        }

        public async Task AddAsync(Car instance)
        {
            await _cars.AddAsync(instance);
        }

        public async Task RemoveAsync(int id)
        {
            var car = await _cars.GetByPredicateAsync(c => c.Id == id);

            if (car != null)
            {
                await _cars.DeleteAsync(car);
                return;
            }
        }

        public async Task UpdateAsync(Car updatedInstance)
        {
            await _cars.UpdateAsync(updatedInstance);
        }

        public async Task<Car> GetByPredicateAsync(Func<Car, bool> predicate)
        {
            return await _cars.GetByPredicateAsync(x => predicate(x));
        }

        public async Task<IEnumerable<Car>> GetAllAsync()
        {
            var cars = _cars.GetAll();

            if (!cars.Any())
            {
                throw new ArgumentNullException();
            }
            return await cars.ToListAsync();
        }
    }
}
