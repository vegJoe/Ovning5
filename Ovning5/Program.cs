using Ovning5.Ovning5_Manager;
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
