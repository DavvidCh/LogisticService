using LogisticService.Utility;

namespace LogisticService.Modules
{
    public class Insurance
    {
        public int Id { get; set; }
        public bool IsIncluded { get; set; }
        public decimal Coefficient { get; set; }

        public Insurance(bool isIncluded, decimal coefficient)
        {
            IsIncluded = isIncluded;
            Coefficient = coefficient;
        }

        public Insurance()
        {
        }

        public override string ToString()
        {
            return $"Is Included?: {IsIncluded}  |  Coefficient: {Coefficient}";
        }
    }
}
