using LogisticService.Calculations;
using LogisticService.Data;
using LogisticService.Interfaces;
using LogisticService.Modules;
using LogisticService.Repositories;
using LogisticService.Requests;
using LogisticService.Users;
using LogisticService.Utility;
using LogisticService.Utility;

namespace LogisticService.UI
{
    class ListUi
    {
        public void Start()
        {
            //    IListRepository<Car> carsRepo = new ListRepository<Car>(Initialization.InitializeCarMarkAndModels);
            //    IListRepository<CarCondition> conditionsRepo = new ListRepository<CarCondition>(Initialization.InitializeConditions);
            //    IListRepository<Container> containersRepo = new ListRepository<Container>(Initialization.InitializeContainers);
            //    IListRepository<Direction> directionsRepo = new ListRepository<Direction>(Initialization.InitializeDirections);
            //    IListRepository<Insurance> insuranceRepo = new ListRepository<Insurance>(Initialization.InitializeInsuranceTypes);
            //    IListRepository<Transit> transitsRepo = new ListRepository<Transit>(Initialization.InitializeTransits);
            //    IListRepository<User> usersRepo = new ListRepository<User>(Initialization.InitializeUsers);
            //    IListRepository<CarBodyType> carBodyTypesRepo = new ListRepository<CarBodyType>(Initialization.InitializeCarBodyTypes);

            //    ListData database = new ListData(
            //        carsRepo, carBodyTypesRepo, conditionsRepo, containersRepo,
            //        directionsRepo, insuranceRepo, transitsRepo, usersRepo);

            //    AdminHelper adminHelper = new AdminHelper(database);


            //    Console.WriteLine("---------------Logistic Service---------------");
            //    Console.Write("1. Admin  |  2. User  |  0. Exit\n" +
            //        "Press option: ");

            //    ConsoleKey pressedButton;
            //    Utility.GetButtonKeyFromUser(out pressedButton);

            //    while (pressedButton != ConsoleKey.D0)
            //    {
            //        Console.Clear();
            //        switch (pressedButton)
            //        {
            //            case ConsoleKey.D1: // Admin
            //                Console.WriteLine(
            //                    "1. Cars/Models\n" +
            //                    "2. Car Body Types\n" +
            //                    "3. Directions\n" +
            //                    "4. Containers\n" +
            //                    "5. Insurance\n" +
            //                    "6. Transits\n\n" +
            //                    "Press option: ");

            //                Utility.GetButtonKeyFromUser(out pressedButton);

            //                Console.WriteLine(
            //                    "1. Create new\n" +
            //                    "2. Update\n" +
            //                    "3. Show all\n" +
            //                    "3. Remove\n" +
            //                    "4. Get\n" +
            //                    "5. Find\n\n" +
            //                    "Press option: ");

            //                switch (pressedButton)
            //                {
            //                    case ConsoleKey.D1:

            //                        break;
            //                }
            //                break;

            //            case ConsoleKey.D2: // User
            //                Console.WriteLine("------------Transporting Car------------");
            //                Console.WriteLine("\nEnter information about your car and transportation details.\n");

            //                string mark = Utility.InputCorrectableCheck("Mark", true);
            //                Console.WriteLine($"\n{carsRepo.Get(car =>
            //                    car.Mark.ToLower() == mark.ToLower() ||
            //                    car.Mark.ToLower().Contains(mark.ToLower()))?.Mark}");

            //                Utility.ShowAllItems<CarModel>(carsRepo.Get(car => car.Mark.ToLower() == mark.ToLower() || car.Mark.ToLower().Contains(mark.ToLower())).CarModels);
            //                string model = Utility.InputCorrectableCheck("Model");

            //                int year = Utility.InputParsabilityCheck<int>("Year");
            //                bool isRunning = Utility.InputYesNo("Is running?");
            //                bool isClosed = Utility.InputYesNo("Do you want transportation in a closed container?");

            //                Utility.ShowAllItems<Direction>(directionsRepo.GetAll());
            //                string from = Utility.InputCorrectableCheck("Transport from", true);
            //                string to = Utility.InputCorrectableCheck("Transport to", true);
            //                bool isInclouded = Utility.InputYesNo("Do you want insurance?");

            //                Utility.ShowAllItems<Transit>(transitsRepo.GetAll());
            //                int dayCount = Utility.InputParsabilityCheck<int>("First available date (in days)");
            //                string email = Utility.EmailCorrectableCheck("Your Email address");

            //                UserRequest userRequest = new UserRequest(mark, model, year, isRunning, isClosed, from, to, isInclouded, dayCount);
            //                CalculationModel calculationModel = database.GetCalculationModel(userRequest);
            //                var price = CalculationService.Calculate(calculationModel);
            //                Console.WriteLine($"Price: {price}$");
            //                Console.ReadLine();
            //                break;
            //            default:
            //                Console.WriteLine("Incorrect button!");
            //                break;
            //        }
            //    }

        }
    }
}
