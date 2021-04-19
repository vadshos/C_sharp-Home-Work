using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_racing
{
    delegate void Race();
    abstract class Vehicle
    {
        public event Race FinishEvents;
        public void Finish()
        {
            Console.WriteLine($"{this.GetType().Name} win race");
        }
        virtual public void Race()
        {
            RandCurrentSpeed();
        }

        public Vehicle(ushort maxSpeed,ushort currentSpeed)
        {
            MaxSpeed = maxSpeed;
            CurrentSpeed = currentSpeed;
        }
        public ushort _currentSpeed;
        public readonly ushort MaxSpeed;
        public ushort CurrentSpeed { get =>_currentSpeed; set => _currentSpeed = MaxSpeed > value  ? value : MaxSpeed; }
        public void RandCurrentSpeed()
        {
            CurrentSpeed = (ushort)new Random().Next(0,MaxSpeed);
        }
    }
}
