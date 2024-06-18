using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning5.Vehicle
{
    public class Airplane : Vehicle
    {
        private int _numOfEngines;

        public int NumOfEngines { get { return _numOfEngines; } }

        public Airplane(string numPlate, string color, int numOfWheels, int numOfEngines) : base(numPlate, color, numOfWheels)
        {
            _numOfEngines = numOfEngines;
        }
    }
}
