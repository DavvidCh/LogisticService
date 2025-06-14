using LogisticService.Enums;
using LogisticService.Modules;
using LogisticService.Users;

namespace LogisticService.Utility
{
    internal static class Initialization
    {
     /* 
        public static void InitializeCarBodyTypes(List<CarBodyType> carBodyTypes)
        {
            carBodyTypes.Add(new CarBodyType(BodyType.Sedan, 1.4f));
            carBodyTypes.Add(new CarBodyType(BodyType.Hatchback, 1.3f));
            carBodyTypes.Add(new CarBodyType(BodyType.Minivan, 1.6f));
            carBodyTypes.Add(new CarBodyType(BodyType.Crossover, 1.7f));
            carBodyTypes.Add(new CarBodyType(BodyType.Van, 1.8f));
            carBodyTypes.Add(new CarBodyType(BodyType.Coupe, 1.5f));
            carBodyTypes.Add(new CarBodyType(BodyType.PickupTruck, 1.9f));
            carBodyTypes.Add(new CarBodyType(BodyType.SportsCar, 2.2f));
            carBodyTypes.Add(new CarBodyType(BodyType.Limousine, 2.5f));
            carBodyTypes.Add(new CarBodyType(BodyType.Luxury, 2.3f));
            carBodyTypes.Add(new CarBodyType(BodyType.SUV, 2.0f));
        }

        public static void InitializeCarMarkAndModels(List<Car> carMarkandModels)
        {
            carMarkandModels.Add(new Car("Mercedes-Benz", new List<CarModel>
            {
                new CarModel("E-Class", 2023, BodyType.Sedan),
                new CarModel("S-Class", 2023, BodyType.Sedan),
                new CarModel("C-Class", 2023, BodyType.Sedan),
                new CarModel("A-Class", 2023, BodyType.Sedan),
                new CarModel("GLC", 2023, BodyType.SUV),
                new CarModel("GLE", 2023, BodyType.SUV),
                new CarModel("CLS", 2023, BodyType.Sedan),
                new CarModel("SLK", 2023, BodyType.Coupe),
                new CarModel("G-Class", 2023, BodyType.SUV),
                new CarModel("B-Class", 2023, BodyType.Sedan),
                new CarModel("AMG GT", 2023, BodyType.SportsCar),
                new CarModel("Maybach S-Class", 2023, BodyType.Luxury),
                new CarModel("CLE Coupe", 2023, BodyType.Coupe),
                new CarModel("EQE SUV", 2023, BodyType.Crossover),
                new CarModel("X-Class", 2023, BodyType.PickupTruck),
            }));

            carMarkandModels.Add(new Car("BMW", new List<CarModel>
            {
                new CarModel("3 Series", 2023, BodyType.Sedan),
                new CarModel("5 Series", 2023, BodyType.Sedan),
                new CarModel("7 Series", 2023, BodyType.Sedan),
                new CarModel("X1", 2023, BodyType.SUV),
                new CarModel("X3", 2023, BodyType.SUV),
                new CarModel("X5", 2023, BodyType.SUV),
                new CarModel("4 Series", 2023, BodyType.Coupe),
                new CarModel("8 Series", 2023, BodyType.Coupe),
                new CarModel("i4", 2023, BodyType.Sedan),
                new CarModel("i8", 2023, BodyType.SportsCar),
                new CarModel("M5 CS", 2023, BodyType.Sedan),
                new CarModel("XM", 2023, BodyType.Luxury),
                new CarModel("Z4", 2023, BodyType.Coupe),
                new CarModel("X7", 2023, BodyType.SUV),
            }));

            carMarkandModels.Add(new Car("Toyota", new List<CarModel>
            {
                new CarModel("Corolla", 2023, BodyType.Sedan),
                new CarModel("Camry", 2023, BodyType.Sedan),
                new CarModel("Avalon", 2023, BodyType.Sedan),
                new CarModel("C-HR", 2023, BodyType.SUV),
                new CarModel("RAV4", 2023, BodyType.SUV),
                new CarModel("Highlander", 2023, BodyType.SUV),
                new CarModel("Supra", 2023, BodyType.Coupe),
                new CarModel("GR86", 2023, BodyType.Coupe),
                new CarModel("Mirai", 2023, BodyType.Sedan),
                new CarModel("Century", 2023, BodyType.Luxury),
                new CarModel("Land Cruiser", 2023, BodyType.SUV),
                new CarModel("Sienna", 2023, BodyType.Minivan),
                new CarModel("Hilux", 2023, BodyType.PickupTruck),
                new CarModel("GT-One", 2023, BodyType.SportsCar),
            }));
        } 
     */

        public static void InitializeConditions(List<CarCondition> conditions)
        {
            conditions.Add(new CarCondition(true, 1.5m));
            conditions.Add(new CarCondition(false, 1.0m));
        }

        public static void InitializeContainers(List<Container> containers)
        {
            containers.Add(new Container(true, 2.5m));
            containers.Add(new Container(false, 1.5m));
        }

        public static void InitializeDirections(List<Direction> directions)
        {
            directions.Add(new Direction("London", "Manchester", 335, 120));
            directions.Add(new Direction("London", "Birmingham", 180, 70));
            directions.Add(new Direction("London", "Liverpool", 350, 125));
            directions.Add(new Direction("London", "Edinburgh", 400, 160));
            directions.Add(new Direction("London", "Glasgow", 550, 200));
            directions.Add(new Direction("London", "Leeds", 290, 100));
            directions.Add(new Direction("London", "Sheffield", 265, 95));
            directions.Add(new Direction("London", "Nottingham", 200, 75));
            directions.Add(new Direction("London", "Newcastle", 400, 150));
            directions.Add(new Direction("London", "Aberdeen", 670, 250));
        }

        public static void InitializeInsuranceTypes(List<Insurance> insuranceTypes)
        {
            insuranceTypes.Add(new Insurance(true, 1.5m));
            insuranceTypes.Add(new Insurance(false, 1.0m));
        }

        public static void InitializeTransits(List<Transit> transits)
        {
            transits.Add(new Transit(2, 2.0m));
            transits.Add(new Transit(7, 1.6m));
            transits.Add(new Transit(15, 1.4m));
            transits.Add(new Transit(30, 1.2m));
        }

        public static void InitializeUsers(List<User> users) 
        {
            users.Add(new SuperAdmin("Davit", "dav.dav0@mail.ru", "123456", "8888"));
        }
    }
}
