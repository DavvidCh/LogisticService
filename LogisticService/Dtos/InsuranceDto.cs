namespace LogisticService.Dtos
{
    public class InsuranceDto
    {
        public int Id { get; set; }
        public bool IsIncluded { get; set; }
        public decimal Coefficient { get; set; }

        public InsuranceDto(int id, bool isIncluded, decimal coefficient)
        {
            Id = id;
            IsIncluded = isIncluded;
            Coefficient = coefficient;
        }

        public InsuranceDto()
        {
        }
    }
}
