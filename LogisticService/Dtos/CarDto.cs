namespace LogisticService.Dtos
{
    public class CarDto
    {
        public int Id { get; set; }
        public string Mark { get; set; }
        public List<CarModelDto> CarModels { get; set; }

        public CarDto(int id, string mark, List<CarModelDto> models)
        {
            Id = id;
            Mark = mark;
            CarModels = models;
        }

        public CarDto()
        {
        }
    }
}
