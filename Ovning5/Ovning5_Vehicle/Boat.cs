using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning5.Vehicle
{
    internal class Boat : Vehicle
    {
        private bool _floats = false;

        public bool Floats { get { return _floats; } }

        public Boat(string numPlate, string color, int numOfWheels, bool floats) : base(numPlate, color, numOfWheels)
        {
            _floats = floats;
        }
    }
}
