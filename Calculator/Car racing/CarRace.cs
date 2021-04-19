using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_racing
{
    delegate void Start();
    class CarRace
    {
        static public byte countFinished = 0; 
        List<Vehicle> vehicles = new List<Vehicle>();
        public event Start StartEvents;
        public void AddVehicle(Vehicle vehicle)
        {
            countFinished++;
            if (vehicle != null)
                vehicles.Add(vehicle);
            else
                throw new NullReferenceException("Vehicles is null");
        }
        public void Race()
        {
            double[] arrDistanation = new double[vehicles.Count];
            Tuple<int,double>[] arrDistanationWiner = new Tuple<int, double>[0];

            while (true)
            {
                bool win = false;
                int index = 0;
                foreach (var vehicle in vehicles)
                {
                    vehicle.Race();

                    arrDistanation[index] = vehicle.CurrentSpeed;
                    if (arrDistanation[index]  >= 100)
                    {
                        win = true;
                        Array.Resize(ref arrDistanationWiner, arrDistanationWiner.Length + 1);
                        arrDistanationWiner[arrDistanationWiner.Length - 1] = new Tuple<int,double>(index, arrDistanation[index]);
                      
                    }
                    ++index;
                }
                if(win == true)
                {
                    if(arrDistanationWiner.Length > 1)
                    {
                       Tuple<int,double> winer =  arrDistanationWiner.Max();
                       vehicles[winer.Item1].Finish();
                       
                       break;
                    }
                }
            }
        }
    }
}
