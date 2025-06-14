namespace LogisticService.Modules
{
    public class Transit
	{
		public int Id { get; set; }
		public int DayCount { get; set; }
		public decimal Coefficient { get; set; }

		public Transit(int dayCount, decimal coefficient)
		{
			DayCount = dayCount;
			Coefficient = coefficient;
		}

		public Transit()
		{
		}

		public override string ToString()
		{
			return $"Days: {DayCount}  |  Coefficient: {Coefficient}";
		}
	}
}
