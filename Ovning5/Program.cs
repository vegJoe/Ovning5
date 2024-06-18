using Ovning5.Ovning5_Manager;
using Ovning5.Garage;
using V = Ovning5.Vehicle;
using UI = Ovning5.UI;
using System.Runtime.CompilerServices;

namespace Ovning5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager();
            bool softwareRunning = true;

            while(softwareRunning)
            {
                softwareRunning = manager.RunManager();
            }
        }
    }
}
