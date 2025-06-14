using LogisticService.Utility;

namespace LogisticService.Modules
{
    public class Direction
    {
        public int Id { get; set; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public decimal Distance { get; set; }
        public decimal Price { get; set; }

        public Direction(string from, string to, decimal distance, decimal price)
        {
            FromLocation = from;
            ToLocation = to;
            Distance = distance;
            Price = price;
        }

        public Direction()
        {
        }

        public override string ToString()
        {
            return $"From: {FromLocation}  |  To: {ToLocation}  |  Distance: {Distance}  |  Price: {Price}";
        }
    }
}