using System;

namespace Car_racing
{
    class Program
    {
        static void Main(string[] args)
        {
            CarRace carRace = new CarRace();
            carRace.AddVehicle(new Lorry(120,12));
            carRace.AddVehicle(new SportCar(110, 12));
            carRace.AddVehicle(new Bus(140, 12));
            carRace.AddVehicle(new Car(130, 12));
            carRace.Race();


        }
    }
}
