using LogisticService.Modules;
using LogisticService.Dtos;

namespace LogisticService.Mappers
{
    public static class CarConditionMapper
    {
        public static CarConditionDto ToDto(this CarCondition entity)
        {
            return new CarConditionDto(entity.Id, entity.IsRunning, entity.Coefficient);
        }

        public static CarCondition FromDto(this CarConditionDto dto)
        {
            return new CarCondition
            {
                Id = dto.Id,
                IsRunning = dto.IsRunning,
                Coefficient = dto.Coefficient
            };
        }
    }
}
