using Ovning5.Garage;
using Ovning5.Vehicle;
using V = Ovning5.Vehicle;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace GarageTests
{
    public class UnitTest1
    {
        public Garage<TestClass> garage;
        //public V.Airplane vehicle;
        public TestClass testClass;
        public UnitTest1()
        {
            //garage = new Garage<Vehicle>(10);
            garage = new Garage<TestClass>(10);
            //vehicle = new V.Airplane("ABC123", "RED", 3, 2);
            testClass = new TestClass();
            garage.AddVehicle(testClass);
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

            int actual = garage.AddVehicle(testClass);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestFindVehicle()
        {
            int expected = 0;

            int actual = garage.FindVehicle(testClass);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestRemoveVehicle()
        {
            garage.RemoveVehicle(0);

            Assert.Empty(garage);
        }
    }

    public class TestClass
    {

    }
}