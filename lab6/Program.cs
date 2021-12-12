using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab06
{
    sealed class Device
    {

        public string name { get; set; }
        public int price { get; set; }

        public Device(string name, int price) { this.price = price; this.name = name; }

        public Device(string name) { this.name = name; }

        public static implicit operator Device(string name) { return new Device(name); }
        public static explicit operator Int32(Device d)
        {
            return d.price;
        }

        public static Device operator -(Device d1, Device d2)
        {
            return new Device(d1.name, d1.price - d2.price);
        }

        public static Device operator --(Device d3)
        {
            return new Device(d3.name, d3.price--);
        }

        public static Device operator +(Device d4, int value)
        {
            return new Device(d4.name, d4.price + value);
        }

        public override string ToString()
        {
            return "Name = " + name + "| price = " + price;
        }
    }

    static class DeviceExpansion
    {
        public static void SayName(this Device dev)
        {
            Console.WriteLine("My name is - " + dev.name);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Device dev1 = new Device("test", 1000);
            dev1.SayName();

            Device dev2 = new Device("phone", 3000);
            Device dev3 = new Device("keyboard", 500);
            Console.WriteLine(dev2);
            Console.WriteLine(dev3);
            Device dev4 = new Device("phone on sale", 0);
            dev4 = dev2 - dev3;
            Console.WriteLine(dev4);

            Device dev5 = new Device("phone on fake sale", 0);
            dev5 = dev2--;
            Console.WriteLine(dev5);

            Device dev6 = new Device("not phone on not sale", 0);
            dev6 = dev1 + 300;
            Console.WriteLine(dev6);

            Console.Read();
        }
    }
}
