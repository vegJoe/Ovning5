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
        private string? _colour;
        private int _numOfwheels;

        internal Vehicle(string numPlate, string colour, int numOfWheels)
        {
            _numPlate = numPlate;
            if(CheckIfColourOK(colour!)) { _colour = colour!; }
            _numOfwheels = numOfWheels;
        }

        private bool CheckIfColourOK(string colour)
        {
            return Enum.IsDefined(typeof(OkColours), colour);
        }

        private enum OkColours
        {
            RED,
            ORANGE,
            YELLOW,
            GREEN,
            BLUE,
            PURPLE,
            WHITE,
            BLACK,
            GREY,
            SILVER,
            PINK,
            BROWN
        }

        public string? NumPlate {  get => _numPlate; private set { } }
        public string? Colour { get => _colour; private set { } }
        public int NumOfWheels {  get => _numOfwheels; private set { } }
    }
}
