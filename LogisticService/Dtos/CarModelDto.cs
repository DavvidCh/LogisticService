using LogisticService.Modules;
using System.ComponentModel.DataAnnotations;

namespace LogisticService.Dtos
{
    public class CarModelDto
    {
        public int Id { get; set; }

        public string Model { get; set; }

        [Range(1900, 2100)]
        public int Year { get; set; }

        public int CarId { get; set; }

        public int CarBodyTypeId { get; set; }

        public CarBodyTypeDto CarBodyType { get; set; }

        public CarModelDto()
        {
        }

        public CarModelDto(int id, string model, int year, int carId, int carBodyTypeId, CarBodyTypeDto carBodyType)
        {
            Id = id;
            Model = model;
            Year = year;
            CarId = carId;
            CarBodyTypeId = carBodyTypeId;
            CarBodyType = carBodyType;
        }
    }
}
