using Ovning5.Garage;
using Ovning5.Vehicle;
using V = Ovning5.Vehicle;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace GarageTests
{
    public class UnitTest1
    {
        public Garage<Vehicle> garage;
        public V.Airplane vehicle;

        public UnitTest1()
        {
            garage = new Garage<Vehicle>(10);
            vehicle = new V.Airplane("ABC123", "RED", 3, 2);
            garage.AddVehicle(vehicle);
        }
        [Fact]
        public void TestGarageSize()
        {
            int expected = 10;

            int actual = garage.GarageSize();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestVehicleAdd()
        {
            int expected = 1;

            int actual = garage.AddVehicle(vehicle);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestFindVehicle()
        {
            int expected = 0;

            int actual = garage.FindVehicle(vehicle);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestRemoveVehicle()
        {
            garage.RemoveVehicle(0);

            Assert.Empty(garage);
        }
    }
}