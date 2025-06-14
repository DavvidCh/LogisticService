namespace LogisticService.Dtos
{
    public class CarConditionDto
    {
        public int Id { get; set; }
        public bool IsRunning { get; set; }
        public decimal Coefficient { get; set; }

        public CarConditionDto(int id, bool isRunning, decimal coefficient)
        {
            Id = id;
            IsRunning = isRunning;
            Coefficient = coefficient;
        }

        public CarConditionDto()
        {
        }
    }
}
