using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.library
{
    public class Bus
    {
        public string LicensePlate { get; private set; }
        public int Capacity { get; private set; }
        private List<IPassenger> passengers;

        public event Action<Bus> BusArrived;
        public event Action<Bus> BusOverloaded;

        public Bus(string licensePlate, int capacity)
        {
            LicensePlate = licensePlate;
            Capacity = capacity;
            passengers = new List<IPassenger>();
        }

        public void ArriveAtBusStop(BusStop busStop)
        {
            BusArrived?.Invoke(this);
            LoadPassengers(busStop);
        }

        private void LoadPassengers(BusStop busStop)
        {
            foreach (var passenger in busStop.Passengers)
            {
                if (passengers.Count < Capacity)
                {
                    passengers.Add(passenger);
                }
                else
                {
                    BusOverloaded?.Invoke(this);
                    break;
                }
            }
            busStop.ClearPassengers();
        }
    }
}
