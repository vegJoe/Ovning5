
using System.ComponentModel.DataAnnotations;

namespace Ovning5.UI
{
    internal class UI : IUI
    {
        private int _menuChoice;
        private bool _validChoice = false;
        private int _sendBack;

        public int GetCommandUI()
        {
            RunUI();

            return _sendBack;
        }

        private void RunUI()
        {
            DisplayUI();
            MenuChoice();
        }

        public void ParkedVehicle(int parkingSpot)
        {
            if (parkingSpot == -1)
                WL("Could not park the vehicle do to insufficient vehicle information");
            else if (parkingSpot == -2)
                WL("Garage is full, could not park vehicle");
            else
                WL($"Vehicle is parked on spot nr {parkingSpot}");

            Thread.Sleep(3000);
        }

        public void DisplayVehicleInfo(int parkingSpot)
        {
            if (parkingSpot == -1)
                WL("Could not find the vehicle you were looking for");
            else
                WL($"The vehicle you are looking for is parked on {parkingSpot}");

            Thread.Sleep(3000);
        }

        public void DisplayAllVehicles(int error)
        {
            if (error == -1)
                WL("Could not find any vehicles");

            Thread.Sleep(3000);
        }

        public void DisplayRemovedVehicle(string numberPlate, int error)
        {
            if (error == -1)
                WL("Could not find the vehicle you were looking for");
            else
                WL($"Vehicle {numberPlate} has ended parking");

            Thread.Sleep(3000);
        }

        public void SubMenuChoice(int choice)
        {
            switch (choice)
            {
                case 1:
                    SubMenuParkVehicle();
                    break;
                case 2:
                    SubMenuEnterNumberPlate()
                    ; break;
                case 3:
                    SubMenuEnterNumberPlate();
                    break;
                case 5:
                    SubMenuEnterAttributes();
                    break;
            }
        }

        private void SubMenuEnterAttributes()
        {
            WL("Enter attributes colour and or number of wheels \nto see vehicles that match criteria");
        }

        public void SubMenuVehicleTyp(int type)
        {
            switch (type)
            {
                case 1:
                    WL("Is the car a hardtop Y/N?");
                    break;
                case 2:
                    WL("How attractive is the motorcycle to steal on a scale from 1-10?");
                    break;
                case 3:
                    WL("How many passangers does the bus take?");
                    break;
                case 4:
                    WL("Does the boat float Y/N?");
                    break;
                case 5:
                    WL("How many wings does the plane have?");
                    break;
            }
        }

        private void DisplayUI()
        {
            Console.Clear();
            WL("*Welcome to Shady Garage Parking*");
            WL("Choose service from Menu:");
            WL("1. Park vehicle:");
            WL("2. End parking:");
            WL("3. Find vehicle:");
            WL("4. List all vehicles:");
            WL("5. List vehicles with specific attributes:");
            WL("6. Show grouped information about vehicles in parkinglot: ");
            WL("7. Contact support:");
            WL("8. CLOSE PARKING SOFTWARE!");
            Console.Write(": ");
        }

        private void SubMenuParkVehicle()
        {
            Console.Clear();
            WL("Input vehicle type:");
            WL("1 for Car, 2 for Motorcycle, 3 for Bus, 4 for Boat, 5 for Airplane");
            WL("Enter Number Plate");
            WL("Enter Colour");
            WL("Enter number of Wheels");
        }

        private void SubMenuEnterNumberPlate()
        {
            WL("Enter plate number:");
        }

        private void MenuChoice()
        {
            _validChoice = int.TryParse(Console.ReadLine(), out _menuChoice);
            SendBackCommand();
        }

        private void SendBackCommand()
        {
            if (_validChoice)
            {
                _sendBack = _menuChoice;
            }
            else
                GetCommandUI();
        }

        private void WL(string text)
        {
            Console.WriteLine(text);
        }
    }
}