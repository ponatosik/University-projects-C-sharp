using lab8.Task1;
using lab8.Task2;

namespace lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("----------------- TASK 1 DEMO ----------------");
            Task1Demo();

            System.Console.WriteLine("----------------- TASK 2 DEMO ----------------");
            Task2Demo();
        }

        public static void Task1Demo()
        {
            Garage cheikeGarage = new Garage();
            cheikeGarage.ParkCar(new Car("BMW VISION NEXT 100", "copper", 432, 2023));
            cheikeGarage.ParkCar(new Car("BMW VISION NEXT 100", "silver", 432, 2023));
            cheikeGarage.ParkCar(new Car("Alfa Romeo Spider", "red", 123, 1994));
            cheikeGarage.ParkCar(new Car("Ferrari 288 GTO", "red", 345, 1987));
            cheikeGarage.ParkCar(new Car("Ferrari 296 GTB", "red", 321, 2022));
            cheikeGarage.ParkCar(new Car("Hyundai Ioniq 6", "black", 210, 1987));

            Console.WriteLine("_____Red cars:________________________");
            var redCars = cheikeGarage.FindCars(color: "red");
            foreach (var car in redCars)
                Console.WriteLine(car.ToString());

            Console.WriteLine("_____Futuristic cars:_________________");
            var futuristicCard = cheikeGarage.FindCars(releaseYear: 2023);
            foreach (var car in futuristicCard)
                Console.WriteLine(car.ToString());

            Console.WriteLine("_____Red cars of past year(2022):_____");
            var newRedCars = cheikeGarage.FindCars(color: "red", releaseYear: 2022);
            foreach (var car in newRedCars)
                Console.WriteLine(car.ToString());

            Console.WriteLine("_____All cars:________________________");
            var allCars = cheikeGarage.FindCars();
            foreach (var car in allCars)
                Console.WriteLine(car.ToString());

            Console.WriteLine("\nCheike took all his red cars to ride...");
            List<Car> takenCars = redCars.ToList();
            foreach (var car in redCars)
                cheikeGarage.TakeCar(car);

            Console.WriteLine("_____All cars now:____________________");
            var allCarsAfterRide = cheikeGarage.FindCars();
            foreach (var car in allCarsAfterRide)
                Console.WriteLine(car.ToString());

            Console.WriteLine("\nCheike came back with his cars and more");
            foreach (var car in takenCars)
                cheikeGarage.ParkCar(car);
            cheikeGarage.ParkCar(new Car("BMW VISION NEXT 100", "gold", 432, 2023));

            Console.WriteLine("_____All cars now:____________________");
            var allCarsAfterRetuning = cheikeGarage.FindCars();
            foreach (var car in allCarsAfterRetuning)
                Console.WriteLine(car.ToString());
        }

        public static void Task2Demo()
        {
            DialPhone DP = new DialPhone(380676184117);
            KeypadPhone KP = new KeypadPhone(380264762363);
            GreyscalePhone GP = new GreyscalePhone(380973303502);
            CellPhone CP = new CellPhone(38043357284, 380226682552);
            Smartphone SP = new Smartphone(38065186155, 380856455142);

            DP.MakeCall(SP.PhoneNumber);
            GP.MakeCall(DP.PhoneNumber);
            SP.MakeCall(KP.PhoneNumber);
            SP.MakeCall(DP.PhoneNumber, 2);
            CP.SendSMS(SP.PhoneNumber, "Hello. How are you?");
            SP.SendMMS(CP.PhoneNumber, SP.TakePhoto());
            SP.SendMMS(CP.PhoneNumber, SP.TakeVideo(1));
        }
    }
}