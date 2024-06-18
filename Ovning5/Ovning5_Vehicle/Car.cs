using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning5.Vehicle
{
    internal class Car : Vehicle
    {
        private bool _hardTop = true;

        public bool HardTop { get { return _hardTop; } }

        public Car(string numPlate, string color, int numOfWheels, bool isHardTop) : base(numPlate, color, numOfWheels)
        {
            _hardTop = isHardTop;
        }
    }
}
