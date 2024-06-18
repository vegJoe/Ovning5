using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using V = Ovning5.Vehicle;

namespace Ovning5.Garage
{
    public class Garage<T> : IEnumerable<T>, IGarage<T>
    {
        private T[] _garage;

        public Garage(int garageSize)
        {
            _garage = new T[garageSize];
        }

        public int GarageSize() { return _garage.Length;}

        /*
         * Method that takes vehicle object and adds it to first space in Garage array that is null
         */
        public int Add(T vehicle)
        {
            int i = 0;

            for (i = 0; i < _garage.Length; i++)
            {
                if (_garage[i] == null)
                {
                    _garage[i] = vehicle;
                    break;
                }
            }
            return i;
        }

        /*
         * Takes a vehicle object and checks array and returns the index position of vehicle object
         */
        public int FindVehicle(T? vehicle)
        {
            return Array.IndexOf(_garage, vehicle);
        }

        /*
         * Takes index and clears any object that is on that position in Array
         */
        public void Remove(int vehicleIndex)
        {
            Array.Clear(_garage, vehicleIndex, 1);
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in _garage)
            {
                if (item != null)
                    yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
    }
}
