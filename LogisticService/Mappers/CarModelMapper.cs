using LogisticService.Dtos;
using LogisticService.Modules;

namespace LogisticService.Mappers
{
    public static class CarModelMapper
    {
        public static CarModelDto ToDto(this CarModel entity)
        {
           return new CarModelDto(
                entity.Id,
                entity.Model,
                entity.Year,
                entity.CarId,
                entity.CarBodyTypeId,
                entity.CarBodyType.ToDto()
                );
        }

        public static CarModel FromDto(this CarModelDto dto)
        {
            return new CarModel
            {
                Id = dto.Id,
                Model = dto.Model,
                Year = dto.Year,
                CarId = dto.CarId,
                CarBodyTypeId = dto.CarBodyTypeId,
                CarBodyType = dto.CarBodyType.FromDto()
            };
        }
    }
}
