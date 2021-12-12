using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab03
{
    class Place
    {
        int year;
        int hours;
        int seats;

        //task 1.a
        public void SetYear(int year) { this.year = year; }
        public int GetYear() { return year; }

        //task 1.b
        public void SetHours(int hours) => this.hours = hours;
        public int GetHours() => hours;

        //task 1.c
        public int Hours
        {
            set { hours = value; }
            get { return hours; }
        }

        //task 1.d
        public int Seats { get; set; }

        //task 1.e
        int[] arr = new int[15];
        public int this[int i]
        {
            get => arr[i];
            set => arr[i] = value;
        }

        public Place(int year, int hours, int seats)
        {
            this.year = year;
            this.hours = hours;
            this.seats = seats;
        }
        public override string ToString()
        {
            return $"year = {year} | hours = {hours} | seats = {seats}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //task 1.a
            Console.WriteLine("task 1.a");
            Place pl1 = new Place(2005, 8, 45);
            Console.WriteLine(pl1);
            pl1.SetYear(2010);
            Console.WriteLine($"year = {pl1.GetYear()}");

            //task 1.b
            Console.WriteLine("task 1.b");
            Place pl2 = new Place(2017, 7, 35);
            Console.WriteLine(pl2);
            pl2.SetHours(10);
            Console.WriteLine($"hours = {pl2.GetHours()}");

            //task 1.c
            Console.WriteLine("task 1.c");
            Place pl3 = new Place(2007, 9, 32);
            Console.WriteLine(pl3);
            pl3.Hours = 10;
            Console.WriteLine($"hours = {pl3.Hours}");

            //task 1.d
            Console.WriteLine("task 1.d");
            Place pl4 = new Place(2000, 8, 80);
            Console.WriteLine(pl4);
            pl4.Seats = 77;
            Console.WriteLine($"seats = {pl4.Seats}");

            //task 1.e
            Console.WriteLine("task 1.e");
            Place pl5 = new Place(2000, 8, 80);
            Console.WriteLine($"pl5[5] = {pl5[5]}");
            pl5[5] = 133;
            Console.WriteLine($"pl5[5] = {pl5[5]}");

            Console.Read();
        }
    }
}
