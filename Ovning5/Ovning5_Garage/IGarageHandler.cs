

namespace Ovning5.Garage
{
    internal interface IGarageHandler
    {
        int GetCommand(int command);
        int GetCommand(int command, string numberPlate);
        int GetCommand(int command, string colour, int numOfWheels, string vehicleType);
        int GetCommand(int command, Vehicle.Vehicle vehicle);
        void RunGarageHandler();
    }
}