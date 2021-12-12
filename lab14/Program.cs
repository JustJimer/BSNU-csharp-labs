using System;

namespace lab14
{
    class SingletonExample
    {
        private SingletonExample() { }

        private static SingletonExample instance;

        public static SingletonExample Initialize()
        {
            if (instance == null)
                instance = new SingletonExample();
            return instance;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // error
            // SingletonExample instance = new SingletonExample();

            SingletonExample instance1 = SingletonExample.Initialize();
            Console.WriteLine("GetHashCode of instance1:\t" + instance1.GetHashCode());

            SingletonExample instance2 = SingletonExample.Initialize();
            Console.WriteLine("GetHashCode of instance2:\t" + instance2.GetHashCode());

            //if (instance1.GetHashCode() == instance2.GetHashCode())
            //    Console.WriteLine("GetHashCodes matchs - singleton works!");

            if (object.ReferenceEquals(instance1, instance2))
                Console.WriteLine("ReferenceEquals = true - singleton works!");
            Console.Read();
        }
    }
}
