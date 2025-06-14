using LogisticService.Dtos;
using LogisticService.Enums;
using LogisticService.Modules;

namespace LogisticService.Mappers
{
    public static class CarBodyTypeMapper
    {
        public static CarBodyTypeDto ToDto(this CarBodyType entity)
        {
            return new CarBodyTypeDto(entity.Id, entity.BodyType.ToString(), entity.Coefficient);
        }

        public static CarBodyType FromDto(this CarBodyTypeDto dto)
        {
            var bodyType = BodyType.Other;
            Enum.TryParse(dto.BodyType, out bodyType);

            return new CarBodyType
            {
                Id = dto.Id,
                BodyType = bodyType,
                Coefficient = dto.Coefficient
            };
        }
    }
}
