using LogisticService.Dtos;
using LogisticService.Modules;

namespace LogisticService.Mappers
{
    internal static class Mapper
    {
        //public static CarDto ToDto(this Car car)
        //{
        //    return new CarDto
        //    {
        //        Id = car.Id,
        //        Mark = car.Mark,
        //        CarModels = car.CarModels?
        //            .Select(ToDto)
        //            .ToList()!
        //    };
        //}

        //public static CarModelDto ToDto(this CarModel carModel)
        //{
        //    return new CarModelDto
        //    {
        //        Id = carModel.Id,
        //        Model = carModel.Model,
        //        Year = carModel.Year,
        //        BodyType = carModel.CarBodyType.BodyType.ToString(),
        //        CarMark = carModel.Car.Mark
        //    };
        //}

        //public static CarBodyTypeDto ToDto(this CarBodyType carBodyType)
        //{
        //    return new CarBodyTypeDto
        //    {
        //        Id = carBodyType.Id,
        //        BodyType = carBodyType.BodyType.ToString(),
        //        Coefficient = carBodyType.Coefficient
        //    };
        //}

        //public static CarConditionDto ToDto(this CarCondition carCondition)
        //{
        //    return new CarConditionDto
        //    {
        //        Id = carCondition.Id,
        //        IsRunning = carCondition.IsRunning,
        //        Coefficient = carCondition.Coefficient
        //    };
        //}

        //public static ContainerDto ToDto(Container container)
        //{
        //    return new ContainerDto
        //    {
        //        Id = container.Id,
        //        IsClosed = container.IsClosed,
        //        Coefficient = container.Coefficient
        //    };
        //}

        //public static DirectionDto ToDto(Direction direction)
        //{
        //    return new DirectionDto
        //    {
        //        Id = direction.Id,
        //        FromLocation = direction.FromLocation,
        //        ToLocation = direction.ToLocation,
        //        Price = direction.Price,
        //        Distance = direction.Distance
        //    };
        //}

        //public static InsuranceDto ToDto(Insurance insurance)
        //{
        //    return new InsuranceDto
        //    {
        //        Id= insurance.Id,
        //        IsIncluded = insurance.IsIncluded,
        //        Coefficient = insurance.Coefficient
        //    };
        //}
        //public static TransitDto ToDto(Transit transit)
        //{
        //    return new TransitDto
        //    {
        //        Id = transit.Id,
        //        DayCount = transit.DayCount,
        //        Coefficient = transit.Coefficient
        //    };
        //}
    }
}
