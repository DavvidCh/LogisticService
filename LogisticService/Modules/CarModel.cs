namespace LogisticService.Modules
{
    public class CarModel
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int CarId { get; set; }
        public int CarBodyTypeId { get; set; }
        public Car Car { get; set; }
        public CarBodyType CarBodyType { get; set; }

        public CarModel(string model, int year, CarBodyType carBodyType)
        {
            Model = model;
            Year = year;
            CarBodyType = carBodyType;
        }

        public CarModel()
        {
        }

        public override string ToString()
        {
            return $"Model: {Model}  |  Year: {Year}";
        }
    }
}
