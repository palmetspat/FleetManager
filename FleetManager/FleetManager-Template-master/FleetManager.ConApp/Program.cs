using FleetManager.Logic;

namespace FleetManager.ConApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Der Flottenmanager");
            Console.WriteLine();

            Fleet fleet = new Fleet(100_000);
            fleet.AddVehicle(new PassengerVehicle("123456789X", 2000, 30, 10.0));
            fleet.AddVehicle(new CargoVehicle("349913599X", 5000, 10, 50.0));
            fleet.AddVehicle(new PassengerVehicle("0747551006", 2500, 32, 10.0));
            fleet.AddVehicle(new CargoVehicle("1572314222", 3000, 10, 50.0));

            Console.WriteLine("Fleet.ToString()");
            Console.WriteLine($"{fleet}");

            Console.WriteLine();
            Console.WriteLine("Fleet.GetByRevenue()");
            foreach (var vehicle in fleet.GetByRevenue())
            {
                Console.WriteLine($"{vehicle}");
            }
        }
    }
}
