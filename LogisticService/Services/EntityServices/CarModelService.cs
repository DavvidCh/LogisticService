using LogisticService.Interfaces;
using LogisticService.Modules;
using Microsoft.EntityFrameworkCore;

namespace LogisticService.Services.EntityServices
{
    public class CarModelService : IServiceAsync<CarModel>
    {
        private readonly IEntityRepository<CarModel> _carModels;

        public CarModelService(IEntityRepository<CarModel> carModels)
        {
            _carModels = carModels;
        }

        public async Task AddAsync(CarModel instance)
        {
            await _carModels.AddAsync(instance);
        }

        public async Task RemoveAsync(int id)
        {
            var carModel = await _carModels.GetByPredicateAsync(c => c.Id == id);
            await _carModels.DeleteAsync(carModel);
        }

        public async Task UpdateAsync(CarModel updatedInstance)
        {
            await _carModels.UpdateAsync(updatedInstance);
        }

        public async Task<CarModel> GetByPredicateAsync(Func<CarModel, bool> predicate)
        {
            return await _carModels.GetByPredicateAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<CarModel>> GetAllAsync()
        {
            var carModels = _carModels.GetAll();

            if (!carModels.Any())
            {
                throw new ArgumentNullException();
            }
            return await carModels.ToListAsync();
        }
    }
}
