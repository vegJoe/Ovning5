using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning5.Vehicle
{
    public abstract class Vehicle
    {
        private string _numPlate;
        private string _color;
        private int _numOfwheels;

        internal Vehicle(string numPlate, string color, int numOfWheels)
        {
            _numPlate = numPlate;
            _color = color;
            _numOfwheels = numOfWheels;
        }

        public string? NumPlate { get; private set; }
        public string? Color { get; private set; }
        public int NumOfWheels {  get; private set; }
    }
}
