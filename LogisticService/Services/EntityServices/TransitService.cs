using LogisticService.Interfaces;
using LogisticService.Modules;
using Microsoft.EntityFrameworkCore;

namespace LogisticService.Services.EntityServices
{
    internal class TransitService : IServiceAsync<Transit>
    {
        private readonly IEntityRepository<Transit> _transit;

        public TransitService(IEntityRepository<Transit> transit)
        {
            _transit = transit;
        }

        public async Task AddAsync(Transit instance)
        {
            await _transit.AddAsync(instance);
        }

        public async Task RemoveAsync(int id)
        {
            var transit = await _transit.GetByPredicateAsync(c => c.Id == id);

            if (transit != null)
            {
                await _transit.DeleteAsync(transit);
                return;
            }
        }

        public async Task UpdateAsync(Transit updatedInstance)
        {
            await _transit.UpdateAsync(updatedInstance);
        }

        public async Task<Transit> GetByPredicateAsync(Func<Transit, bool> predicate)
        {
            return await _transit.GetByPredicateAsync(x => predicate(x));
        }

        public async Task<IEnumerable<Transit>> GetAllAsync()
        {
            var transits = _transit.GetAll();

            if (!transits.Any())
            {
                throw new ArgumentNullException();
            }
            return await transits.ToListAsync();
        }
    }
}
