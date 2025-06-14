using LogisticService.Modules;

namespace LogisticService.Calculations
{
    internal class CalculationModel
    {
        public CalculationModel(
            CarBodyType carBodyType,
            CarCondition condition,
            Container container,
            Direction direction,
            Insurance insurance,
            Transit transit)
        {
            CarBodyType = carBodyType;
            Condition = condition;
            Container = container;
            Direction = direction;
            Insurance = insurance;
            Transit = transit;
        }

        public CarBodyType CarBodyType { get; set; }
        public CarCondition Condition { get; set; }
        public Container Container { get; set; }
        public Direction Direction { get; set; }
        public Insurance Insurance { get; set; }
        public Transit Transit { get; set; }
    }
}
