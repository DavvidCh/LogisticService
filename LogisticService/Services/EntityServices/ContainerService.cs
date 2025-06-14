using LogisticService.Interfaces;
using LogisticService.Modules;
using Microsoft.EntityFrameworkCore;

namespace LogisticService.Services.EntityServices
{
    public class ContainerService : IServiceAsync<Container>
    {
        private readonly IEntityRepository<Container> _container;

        public ContainerService(IEntityRepository<Container> container)
        {
            _container = container;
        }

        public async Task AddAsync(Container instance)
        {
            await _container.AddAsync(instance);
        }

        public async Task RemoveAsync(int id)
        {
            var container = await _container.GetByPredicateAsync(c => c.Id == id);

            if (container != null)
            {
                await _container.DeleteAsync(container);
                return;
            }
        }

        public async Task UpdateAsync(Container updatedInstance)
        {
            await _container.UpdateAsync(updatedInstance);
        }

        public async Task<Container> GetByPredicateAsync(Func<Container, bool> predicate)
        {
            return await _container.GetByPredicateAsync(x => predicate(x));
        }

        public async Task<IEnumerable<Container>> GetAllAsync()
        {
            var containers = _container.GetAll();

            if (!containers.Any())
            {
                throw new ArgumentNullException();
            }
            return await containers.ToListAsync();
        }
    }
}
