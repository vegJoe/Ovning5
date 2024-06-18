using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning5.Vehicle
{
    internal class Motorcycle : Vehicle
    {
        private int _stealable;

        public int Stealable { get { return _stealable; } }

        public Motorcycle(string numPlate, string color, int numOfWheels, int stealableLevel) : base(numPlate, color, numOfWheels)
        {
            _stealable = stealableLevel;
        }
    }
}
