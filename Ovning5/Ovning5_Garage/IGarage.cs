
namespace Ovning5.Garage
{
    public interface IGarage<T>
    {
        int AddVehicle(T vehicle);
        int FindVehicle(T? vehicle);
        int GarageSize();
        IEnumerator<T> GetEnumerator();
        void RemoveVehicle(int vehicleIndex);
    }
}