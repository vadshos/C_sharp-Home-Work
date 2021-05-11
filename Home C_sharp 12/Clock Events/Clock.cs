using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clock_Events
{
    class ClockEventArgs
    {
        public ClockEventArgs(byte h ,byte m)
        {
            this.Hours = h;
            this.Minutes = m;
        }
       public byte Hours { get;  set; }
       public byte Minutes { get; protected set; }
    }
    class Clock
    {
        public Clock(byte h,byte m)
        {
            Hours = h;
            Minutes = m;
        }
        public event EventHandler<ClockEventArgs> Alarm;
        byte hoursA;
        byte minutesA;
        byte _hours;
        byte _minutes;
        public byte Hours { get=> _hours; 
            set { 
                if(value > 23)
                {
                    _hours = 0;
                }
                else
                {
                    _hours = value;
                }
            } }
        public byte Minutes { get => _minutes; set { if ( value > 59) { Hours ++;_minutes = 0; } else { _minutes = value; } } }
        public void Tick()
        {
            Minutes++;
            if(minutesA == Minutes && hoursA == Hours)
                Alarm?.Invoke(this, new ClockEventArgs(hoursA, minutesA));
        }
        public void SetAlarm(byte hours,byte minutes)
        {
            hoursA = hours;
            minutesA = minutes;
            Alarm += Alarm_GoOn;
        }
        public void Alarm_GoOn(object sender,ClockEventArgs e)
        {
            Console.WriteLine($"Alarm work {e.Hours} : {e.Minutes}");
        }
    }
}
