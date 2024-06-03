using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.library
{
    public class Passenger : IPassenger
    {
        public string Name { get; private set; }

        public Passenger(string name)
        {
            Name = name;
        }
    }
}
