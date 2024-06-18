using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V = Ovning5.Vehicle;

namespace Ovning5.Garage
{
    internal class Garage
    {
        private V.Vehicle[] vehicles;

        public void Size(int size)
        {
            vehicles = new V.Vehicle[size];
        }
    }
}
