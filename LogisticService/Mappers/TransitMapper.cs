using LogisticService.Dtos;
using LogisticService.Modules;

namespace LogisticService.Mappers
{
    public static class TransitMapper
    {
        public static TransitDto ToDto(this Transit entity)
        {
            return new TransitDto(entity.Id, entity.DayCount, entity.Coefficient);
        }

        public static Transit FromDto(this TransitDto dto)
        {
            return new Transit
            {
                Id = dto.Id,
                DayCount = dto.DayCount,
                Coefficient = dto.Coefficient
            };
        }
    }
}
