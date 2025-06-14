namespace LogisticService.Modules
{
	public class Car
	{
		public int Id { get; set; }
		public string Mark { get; set; }
        public List<CarModel> CarModels { get; set; }

        public Car(string mark, List<CarModel> models)
		{
			Mark = mark;
			CarModels = models;
        }

		public Car()
		{
		}
    }
}
