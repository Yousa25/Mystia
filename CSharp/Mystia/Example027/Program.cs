using System;

namespace Example027
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vehicle vehicle = new Car();
            vehicle.Run();
        }

       abstract class Vehicle
        {
            public void Stop()
            {
                Console.WriteLine("Stopped!");
            }

            public abstract void Run();
     
        }
        class Car:Vehicle
        {
            public override void Run()
            {
                Console.WriteLine("Car is Running");
            }
        }

        class Truck:Vehicle
        {
            public override void Run()
            {
                Console.WriteLine("Car is Running");
            }
        }
    }
}
