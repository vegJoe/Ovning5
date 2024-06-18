
namespace Ovning5.Garage
{
    public interface IGarage<T>
    {
        int Add(T vehicle);
        int FindVehicle(T? vehicle);
        int GarageSize();
        //Type GarageTyp();
        IEnumerator<T> GetEnumerator();
        void Remove(int vehicleIndex);
        void Size(int size);
    }
}