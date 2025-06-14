using LogisticService.Utility;

namespace LogisticService.Modules
{
    public class CarCondition
	{
		public int Id { get; set; }
		public bool IsRunning { get; set; }
		public decimal Coefficient {  get; set; }

		public CarCondition(bool isRunning, decimal coefficient)
		{
            IsRunning = isRunning;
			Coefficient = coefficient;
		}

		public CarCondition()
		{
		}

        public override string ToString()
        {
            return $"Is Running?: {IsRunning}  |  Coefficient: {Coefficient}";
        }
    }
}
