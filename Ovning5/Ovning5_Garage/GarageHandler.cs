using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Formats.Tar;
using V = Ovning5.Vehicle;

namespace Ovning5.Garage
{
    internal class GarageHandler : IGarageHandler
    {
        private Garage<V.Vehicle>? _garage;
        private V.Vehicle? _vehicle;
        private string? _numberPlate;
        private int _vehicleIndex;
        private string? _colour;
        private int _numOfWheels;
        private string? _vehicleType;

        public void RunGarageHandler()
        {
            if (_garage == null)
            {
                int garageSize;
                bool correctInput = false;

                do
                {
                    Console.Write("Enter size of new garage: ");
                    correctInput = Int32.TryParse(Console.ReadLine(), out garageSize);
                    if (correctInput)
                        _garage = new Garage<V.Vehicle>(garageSize);
                } while (!correctInput);
            }
        }

        public int GarageSize()
        {
            return _garage!.GarageSize();
        }

        public int GetCommand(int command, V.Vehicle vehicle)
        {
            _vehicle = vehicle;
            CheckCommand(command);

            return _vehicleIndex;
        }

        public int GetCommand(int command, string numberPlate)
        {
            _numberPlate = numberPlate;
            CheckCommand(command);

            return _vehicleIndex;
        }

        public int GetCommand(int command)
        {
            CheckCommand(command);

            return _vehicleIndex;
        }

        public int GetCommand(int command, string colour, int numOfWheels, string vehicleType)
        {
            _colour = colour;
            _numOfWheels = numOfWheels;
            _vehicleType = vehicleType;

            CheckCommand(command);

            return _vehicleIndex;
        }
        private void CheckCommand(int command)
        {
            //Resets the _vehicleIndex variable in case previous operation set it to -1 and new operation doesn't set it.
            _vehicleIndex = 0;

            switch (command)
            {
                case 1:
                    AddVehicle(_vehicle!);
                    break;
                case 2:
                    RemoveVehicle(_numberPlate!);
                    break;
                case 3:
                    LookUpREGNUM(_numberPlate!);
                    break;
                case 4:
                    ListAllVehicles();
                    break;
                case 5:
                    ListVehiclesOnAttributes(_colour!, _numOfWheels, _vehicleType!);
                    break;
                case 6:
                    ListGroupedInformation();
                    break;
            }
        }

        private void ListGroupedInformation()
        {
            try
            {
                var iVehicle = _garage!.GroupBy(veh => veh.GetType().Name).Select(group => new { VehicleType = group.Key, NumberOf = group.Count() });

                if (iVehicle.Any())
                {
                    foreach (var vehicle in iVehicle)
                    {
                        Console.WriteLine($"{vehicle.VehicleType}: {vehicle.NumberOf}");
                    }

                    Thread.Sleep(5000);
                }
                else
                    _vehicleIndex = -1;
            }
            catch (Exception)
            {
                _vehicleIndex = -1;
            }
        }

        private void ListVehiclesOnAttributes(string colour, int numOfWheels, string vehicleType)
        {
            IEnumerable<V.Vehicle> iVehicle = _garage!;

            if (colour != "")
            {
                iVehicle = iVehicle.Where(veh => veh.Colour == colour);
            }
            if (numOfWheels >= 0)
            {
                iVehicle = iVehicle.Where(veh => veh.NumOfWheels == numOfWheels);
            }
            if (vehicleType != "")
            {
                iVehicle = iVehicle.Where(veh => veh.GetType().Name == vehicleType);
            }

            if (iVehicle.Any())
            {
                foreach (var vehicle in iVehicle)
                {
                    Console.WriteLine($"Vehicle maching criteria was found on parking spot {_garage!.FindVehicle(vehicle)}");
                }
            }
            else
                _vehicleIndex = -1;
        }

        private void AddVehicle(V.Vehicle vehicle)
        {
            if (vehicle.Colour != null && vehicle.NumPlate != "")
                _vehicleIndex = _garage!.AddVehicle(vehicle);
            else
                _vehicleIndex = -1;
        }

        private void RemoveVehicle(string numPlate)
        {
            try
            {
                if (_garage != null)
                {
                    IEnumerable<V.Vehicle> iVehicle = _garage!.Where(veh => veh.NumPlate == numPlate);

                    if (iVehicle.Any())
                    {
                        foreach (var vehicle in iVehicle)
                        {
                            _vehicleIndex = _garage!.FindVehicle(vehicle);
                            _garage!.RemoveVehicle(_vehicleIndex);
                        }
                    }
                    else
                        _vehicleIndex = -1;
                }
                else
                    _vehicleIndex = -1;
            }
            catch (Exception)
            {
                _vehicleIndex = -1;
            }
        }

        private void LookUpREGNUM(string numPlate)
        {
            try
            {
                if (_garage != null)
                {
                    IEnumerable<V.Vehicle> iVehicle = _garage!.Where(veh => veh.NumPlate == numPlate);

                    if (iVehicle.Any())
                    {
                        foreach (var vehicle in iVehicle)
                        {
                            _vehicleIndex = _garage!.FindVehicle(vehicle);
                        }
                    }
                    else
                        _vehicleIndex = -1;
                }
                else
                    _vehicleIndex = -1;
            }
            catch (Exception)
            {
                _vehicleIndex = -1;
            }
        }

        private void ListAllVehicles()
        {
            IEnumerable<V.Vehicle> iVehicle = _garage!.Where(veh => veh.NumPlate != null);

            if (iVehicle.Any())
            {
                foreach (var vehicle in iVehicle)
                {
                    Console.WriteLine($"{vehicle.GetType().Name}: {vehicle.NumPlate}");
                }
                Thread.Sleep(5000);
            }
            else
                _vehicleIndex = -1;
        }
    }
}
