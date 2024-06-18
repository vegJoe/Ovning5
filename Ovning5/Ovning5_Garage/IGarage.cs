
namespace Ovning5.Garage
{
    public interface IGarage<T>
    {
        int Add(T vehicle);
        int FindVehicle(T? vehicle);
        int GarageSize();
        IEnumerator<T> GetEnumerator();
        void Remove(int vehicleIndex);
    }
}