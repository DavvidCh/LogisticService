namespace LogisticService.Dtos
{
    public class CarBodyTypeDto
    {
        public int Id { get; set; }
        public string BodyType { get; set; }
        public decimal Coefficient { get; set; }

        public CarBodyTypeDto(int id, string bodyType, decimal coefficient)
        {
            Id = id;
            BodyType = bodyType;
            Coefficient = coefficient;
        }

        public CarBodyTypeDto()
        {
        }
    }
}
