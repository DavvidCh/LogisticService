using LogisticService.Interfaces;
using LogisticService.Modules;
using Microsoft.EntityFrameworkCore;

namespace LogisticService.Services.EntityServices
{
    internal class InsuranceService : IServiceAsync<Insurance>
    {
        private readonly IEntityRepository<Insurance> _insurance;

        public InsuranceService(IEntityRepository<Insurance> insurance)
        {
            _insurance = insurance;
        }

        public async Task AddAsync(Insurance instance)
        {
            await _insurance.AddAsync(instance);
        }

        public async Task RemoveAsync(int id)
        {
            var insurance = await _insurance.GetByPredicateAsync(c => c.Id == id);

            if (insurance != null)
            {
                await _insurance.DeleteAsync(insurance);
                return;
            }
        }

        public async Task UpdateAsync(Insurance updatedInstance)
        {
            await _insurance.UpdateAsync(updatedInstance);
        }

        public async Task<Insurance> GetByPredicateAsync(Func<Insurance, bool> predicate)
        {
            return await _insurance.GetByPredicateAsync(x => predicate(x));
        }

        public async Task<IEnumerable<Insurance>> GetAllAsync()
        {
            var insurances = _insurance.GetAll();

            if (!insurances.Any())
            {
                throw new ArgumentNullException();
            }
            return await insurances.ToListAsync();
        }
    }
}
