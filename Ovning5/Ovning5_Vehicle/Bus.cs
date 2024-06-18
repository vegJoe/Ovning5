using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning5.Vehicle
{
    internal class Bus : Vehicle
    {
        private int _numOfPassangers;

        public int NumberOfPassangers {  get { return _numOfPassangers; } }

        public Bus(string numPlate, string color, int numOfWheels, int numOfPassangers) : base(numPlate, color, numOfWheels)
        {
            _numOfPassangers = numOfPassangers;
        }
    }
}
