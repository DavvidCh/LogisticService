namespace LogisticService.Dtos
{
    public class DirectionDto
    {
        public int Id { get; set; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public decimal Distance { get; set; }
        public decimal Price { get; set; }

        public DirectionDto(int id, string from, string to, decimal distance, decimal price)
        {
            Id = id;
            FromLocation = from;
            ToLocation = to;
            Distance = distance;
            Price = price;
        }

        public DirectionDto()
        {
        }
    }
}
