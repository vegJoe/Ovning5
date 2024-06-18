using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using V = Ovning5.Vehicle;
using Ovning5.Garage;

namespace Ovning5.Ovning5_Manager
{
    internal class Manager : IManager
    {
        private int _command;

        private GarageHandler? handler;
        UI.UI UI = new UI.UI();
        private V.Vehicle? _vehicle;
        private int _vehicleIndex;
        private bool _softwareRunning = true;

        public bool RunManager()
        {
            if (handler == null)
            {
                handler = new GarageHandler();
                handler.RunGarageHandler();
            }

            DisplayUI();
            ExecuteCommand();

            return _softwareRunning;
        }

        private void DisplayUI()
        {
            _command = UI.GetCommandUI();
        }

        private void ExecuteCommand()
        {
            switch (_command)
            {
                case 1:
                    RegisterVehicle();
                    break;
                case 2:
                    RemoveVehicle();
                    break;
                case 3:
                    FindVehicle();
                    break;
                case 4:
                    ListAllVehicles();
                    break;
                case 5:
                    ListVehiclesWithAttributes();
                    break;
                case 6:
                    ListGroupedInformation();
                    break;
                case 7:
                    {
                        Console.WriteLine("Pretty sure this place have no support!");
                        Thread.Sleep(5000);
                    }
                    break;
                case 8:
                    _softwareRunning = false;
                    break;
                case 9:
                    //In "Choose service from Menu:" enter 9 and press enter to load garage with vehicles
                    PreloadGarage();
                    break;
            }
        }

        private void PreloadGarage()
        {
            V.Car car1 = new V.Car("AAA111", "RED", 4, true);
            V.Car car2 = new V.Car("BBB000", "BLUE", 4, false);
            V.Car car3 = new V.Car("CCC222", "RED", 3, true);
            V.Airplane airplane1 = new V.Airplane("ABAERASD", "WHITE", 3, 2);
            V.Motorcycle motorcycle1 = new V.Motorcycle("EEE123", "BLACK", 2, 8);
            V.Motorcycle motorcycle2 = new V.Motorcycle("BCE321", "YELLOW", 2, 3);
            V.Boat boat1 = new V.Boat("PIRATE", "BLACK", 0, true);
            V.Bus bus1 = new V.Bus("KUL999", "RED", 4, 14);

            List<V.Vehicle> vehicles = new List<V.Vehicle>();
            vehicles.Add(car1);
            vehicles.Add(car2);
            vehicles.Add(car3);
            vehicles.Add(airplane1);
            vehicles.Add(motorcycle1);
            vehicles.Add(motorcycle2);
            vehicles.Add(boat1);
            vehicles.Add(bus1);

            foreach (var vehicle in vehicles)
            {
                handler!.GetCommand(1, vehicle);
            }
        }

        private void ListGroupedInformation()
        {
            _vehicleIndex = handler!.GetCommand(_command);

            UI.DisplayAllVehicles(_vehicleIndex);
        }

        private void RegisterVehicle()
        {

            UI.SubMenuChoice(_command);

            int.TryParse(Console.ReadLine(), out int vType);

            if ((Enum.IsDefined(typeof(OkVehicles), vType)))
            {
                VehicleType(vType);
                _vehicleIndex = handler!.GetCommand(_command, _vehicle!);

                if (_vehicleIndex == handler.GarageSize())
                    _vehicleIndex = -2;
            }
            

            UI.ParkedVehicle(_vehicleIndex);
        }

        private void RemoveVehicle()
        {
            UI.SubMenuChoice(_command);

            string numberPlate = Console.ReadLine()!.ToUpper();

            _vehicleIndex = handler!.GetCommand(_command, numberPlate);

            UI.DisplayRemovedVehicle(numberPlate, _vehicleIndex);
        }

        private void FindVehicle()
        {
            UI.SubMenuChoice(_command);

            string numberPlate = Console.ReadLine()!.ToUpper();

            _vehicleIndex = handler!.GetCommand(_command, numberPlate);

            UI.DisplayVehicleInfo(_vehicleIndex);
        }

        private void ListAllVehicles()
        {
            _vehicleIndex = handler!.GetCommand(_command);

            UI.DisplayAllVehicles(_vehicleIndex);
        }

        private void ListVehiclesWithAttributes()
        {
            int numOfWheels;
            UI.SubMenuChoice(_command);

            string colour = Console.ReadLine()!.ToUpper();
            if (!int.TryParse(Console.ReadLine(), out numOfWheels))
                numOfWheels = -1;
            string vehicleType = Console.ReadLine()!;
            vehicleType = vehicleType.ToLower();
            if (vehicleType != "")
                vehicleType = vehicleType.Remove(0, 1).Insert(0, vehicleType[0].ToString().ToUpper());

            _vehicleIndex = handler!.GetCommand(_command, colour, numOfWheels, vehicleType);

            UI.DisplayAllVehicles(_vehicleIndex);
        }

        private void VehicleType(int type)
        {
            if (type == 1)
            {
                VehicleBase car = EnterVehicleInfo();
                UI.SubMenuVehicleTyp(type);
                string? hardTopCheck = Console.ReadLine()!.ToUpper();
                bool isHardTop = (hardTopCheck == "Y") ? true : false;

                _vehicle = new V.Car(car.numberPlate!, car.vehicleColour!, car.numberOfWheels, isHardTop);
            }
            else if (type == 2)
            {
                VehicleBase motorcycle = EnterVehicleInfo();
                UI.SubMenuVehicleTyp(type);
                int stealableScale = Convert.ToInt32(Console.ReadLine());

                _vehicle = new V.Motorcycle(motorcycle.numberPlate!, motorcycle.vehicleColour!, motorcycle.numberOfWheels, stealableScale);
            }
            else if (type == 3)
            {
                VehicleBase bus = EnterVehicleInfo();
                UI.SubMenuVehicleTyp(type);
                int passangerSize = Convert.ToInt32(Console.ReadLine());

                _vehicle = new V.Bus(bus.numberPlate!, bus.vehicleColour!, bus.numberOfWheels, passangerSize);
            }
            else if (type == 4)
            {
                VehicleBase boat = EnterVehicleInfo();
                UI.SubMenuVehicleTyp(type);
                string? boatFloats = Console.ReadLine()!.ToUpper();
                bool doesItFloat = (boatFloats == "Y") ? true : false;

                _vehicle = new V.Boat(boat.numberPlate!, boat.vehicleColour!, boat.numberOfWheels, doesItFloat);
            }
            else if (type == 5)
            {
                VehicleBase plane = EnterVehicleInfo();
                UI.SubMenuVehicleTyp(type);
                int numberOfWings = Convert.ToInt32(Console.ReadLine());

                _vehicle = new V.Airplane(plane.numberPlate!, plane.vehicleColour!, plane.numberOfWheels, numberOfWings);
            }
        }

        private VehicleBase EnterVehicleInfo()
        {
            VehicleBase vehicleBase;

            vehicleBase.numberPlate = Console.ReadLine()!.ToUpper();
            vehicleBase.vehicleColour = Console.ReadLine()!.ToUpper();
            int.TryParse(Console.ReadLine(), out vehicleBase.numberOfWheels);

            return vehicleBase;
        }

        private enum OkVehicles
        {
            Car = 1,
            Motorcycle = 2,
            Bus = 3,
            Boat = 4,
            Airplane = 5
        }

        struct VehicleBase
        {
            public string? numberPlate;
            public string? vehicleColour;
            public int numberOfWheels;
        }
    }
}