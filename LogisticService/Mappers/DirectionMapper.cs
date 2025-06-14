using LogisticService.Dtos;
using LogisticService.Modules;

namespace LogisticService.Mappers
{
    public static class DirectionMapper
    {
        public static DirectionDto ToDto(this Direction entity)
        {
            return new DirectionDto(
                entity.Id,
                entity.FromLocation,
                entity.ToLocation,
                entity.Distance,
                entity.Price
                );
        }

        public static Direction FromDto(this DirectionDto dto)
        {
            return new Direction
            {
                Id = dto.Id,
                FromLocation = dto.FromLocation,
                ToLocation = dto.ToLocation,
                Distance = dto.Distance,
                Price = dto.Price
            };
        }
    }
}
