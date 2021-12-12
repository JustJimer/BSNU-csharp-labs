using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab07
{
    public enum DaysOfWeek
    {
        Monday = 1, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
    }

    public static class Extensions
    {
        public static DaysOfWeek minDay = DaysOfWeek.Friday;
        public static void Passing(this DaysOfWeek day)
        {
            //return day >= minDay;
            Console.WriteLine("{0}", day >= minDay ? "YRA!!" : "go to work!");
        }
    }

    //2
    class Place<T>
    {
        T seats = default(T);
        T hours = default(T);
        public static T count;
        public Place(T seats, T hours)
        {
            this.seats = seats; this.hours = hours;
        }
        public Place() { }
        public T Z { set; get; }
        public override string ToString()
        {
            return "seats = " + seats + " hours = " + hours + " Z = " + Z + " count = " + count;
        }

    }



    class Program
    {
        public static void PrintDay(int n)
        {
            DaysOfWeek day = (DaysOfWeek)n;
            Console.WriteLine("Name of the day - " + day);
            Console.WriteLine("Number of the day - " + (int)day);
        }

        //2
        public static void Swap<T>(ref T seats, ref T hours)
        {
            T temp = seats;
            seats = hours;
            hours = temp;
        }

        public T Sum<T>(T seats, T hours)
        {
            return (dynamic)seats + (dynamic)hours;
        }
        public T Substruction<T>(T seats, T hours)
        {
            T substruction =
           (dynamic)seats + (dynamic)hours;
            return substruction;
        }

        static void Main(string[] args)
        {
            string[] s = Enum.GetNames(typeof(DaysOfWeek));
            var str = string.Join(" ", s);
            Console.WriteLine(str);

            PrintDay(1);

            DaysOfWeek day1 = DaysOfWeek.Monday;
            Extensions.Passing(day1);

            DaysOfWeek day2 = DaysOfWeek.Sunday;
            Extensions.Passing(day2);



            //2
            Place<int> place1 = new Place<int>(1, 2);
            Console.WriteLine("Place1=" + place1);
            Place<float> place2 = new Place<float>(1.2f, 2.5f);
            Console.WriteLine("Place2=" + place2);
            Place<double> place3 = new Place<double>(3.4, 8.5);
            Console.WriteLine("Place3=" + place3);

            Place<int> pa1 = new Place<int> { Z = 0 };
            Place<int>.count = 3;
            Place<string> pa2 = new Place<string> { Z = "0" };
            Place<string>.count = "bar";
            Console.WriteLine(pa2);

            int seats = 50, hours = 7;
            Swap(ref seats, ref hours);
            Console.WriteLine("seats = " + seats + " hours = " + hours);

            Program program = new Program();
            int result = program.Sum(seats, hours);
            Console.WriteLine("result = " + result);
            string resultStr = program.Sum("seats", "hours");
            Console.WriteLine("resultStr = " + resultStr);
            resultStr = program.Substruction("seats", "hours");
            Console.WriteLine("resultStr = " + resultStr);

            Console.Read();
        }
    }
}