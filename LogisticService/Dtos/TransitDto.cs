namespace LogisticService.Dtos
{
    public class TransitDto
    {
        public int Id { get; set; }
        public int DayCount { get; set; }
        public decimal Coefficient { get; set; }

        public TransitDto(int id, int dayCount, decimal coefficient)
        {
            Id = id;
            DayCount = dayCount;
            Coefficient = coefficient;
        }

        public TransitDto()
        {
        }
    }
}
