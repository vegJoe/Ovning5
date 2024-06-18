namespace Ovning5.UI
{
    internal interface IUI
    {
        void DisplayAllVehicles(int error);
        void DisplayRemovedVehicle(string numberPlate, int error);
        void DisplayVehicleInfo(int parkingSpot);
        int GetCommandUI();
        void ParkedVehicle(int parkingSpot);
        void SubMenuChoice(int choice);
        void SubMenuVehicleTyp(int type);
    }
}