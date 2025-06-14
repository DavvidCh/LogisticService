using LogisticService.Utility;

namespace LogisticService.Modules
{
    public class Container
    {
        public int Id { get; set; }
        public bool IsClosed { get; set; }
        public decimal Coefficient { get; set; }

        public Container(bool isClosed, decimal coefficient)
        {
            IsClosed = isClosed;
            Coefficient = coefficient;
        }

        public Container()
        {
        }

        public override string ToString()
        {
            return $"Is Closed?: {IsClosed}  |  Coefficient: {Coefficient}";
        }
    }
}
