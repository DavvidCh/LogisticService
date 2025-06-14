using LogisticService.Interfaces;
using LogisticService.Modules;
using Microsoft.EntityFrameworkCore;

namespace LogisticService.Services.EntityServices
{
    public class DirectionService : IServiceAsync<Direction>
    {
        private readonly IEntityRepository<Direction> _direction;

        public DirectionService(IEntityRepository<Direction> direction)
        {
            _direction = direction;
        }

        public async Task AddAsync(Direction instance)
        {
            await _direction.AddAsync(instance);
        }

        public async Task RemoveAsync(int id)
        {
            var direction = await _direction.GetByPredicateAsync(c => c.Id == id);

            if (direction != null)
            {
                await _direction.DeleteAsync(direction);
                return;
            }
        }

        public async Task UpdateAsync(Direction updatedInstance)
        {
            await _direction.UpdateAsync(updatedInstance);
        }

        public async Task<Direction> GetByPredicateAsync(Func<Direction, bool> predicate)
        {
            return await _direction.GetByPredicateAsync(x => predicate(x));
        }

        public async Task<IEnumerable<Direction>> GetAllAsync()
        {
            var directions = _direction.GetAll();

            if (!directions.Any())
            {
                throw new ArgumentNullException();
            }
            return await directions.ToListAsync();
        }
    }
}
