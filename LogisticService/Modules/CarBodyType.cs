using LogisticService.Enums;

namespace LogisticService.Modules
{
    public class CarBodyType
    {
        public int Id { get; set; }
        public BodyType BodyType { get; set; }
        public decimal Coefficient { get; set; }
        public List<CarModel> CarModels { get; set; }

        public CarBodyType(BodyType bodyTypeName, decimal coefficient)
        {
            BodyType = bodyTypeName;
            Coefficient = coefficient;
        }

        public CarBodyType()
        {
        }

        public override string ToString()
        {
            return $"Body: {BodyType}  |  Coefficient: {Coefficient}";
        }
    }
}
