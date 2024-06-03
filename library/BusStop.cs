using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.library
{
    public class BusStop
    {
        public string Name { get; private set; }
        public List<IPassenger> Passengers { get; private set; }

        public BusStop(string name)
        {
            Name = name;
            Passengers = new List<IPassenger>();
        }

        public void AddPassenger(IPassenger passenger)
        {
            Passengers.Add(passenger);
        }

        public void ClearPassengers()
        {
            Passengers.Clear();
        }
    }
}
