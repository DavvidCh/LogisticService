using LogisticService.Dtos;
using LogisticService.Modules;

namespace LogisticService.Mappers
{
    public static class ContainerMapper
    {
        public static ContainerDto ToDto(this Container entity)
        {
            return new ContainerDto(entity.Id, entity.IsClosed, entity.Coefficient);
        }

        public static Container FromDto(this ContainerDto dto)
        {
            return new Container
            {
                Id = dto.Id,
                IsClosed = dto.IsClosed,
                Coefficient = dto.Coefficient
            };
        }
    }
}
