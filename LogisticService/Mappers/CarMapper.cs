using LogisticService.Dtos;
using LogisticService.Modules;

namespace LogisticService.Mappers
{
    public static class CarMapper
    {
        public static CarDto ToDto(this Car car)
        {
            return new CarDto(

                car.Id,
                car.Mark,
                car.CarModels.Select(CarModelMapper.ToDto).ToList()
            );
        }

        public static Car FromDto(this CarDto carDto)
        {
            return new Car
            {
                Id = carDto.Id,
                Mark = carDto.Mark,
                CarModels = carDto.CarModels.Select(CarModelMapper.FromDto).ToList()
            };
        }
    }
}
