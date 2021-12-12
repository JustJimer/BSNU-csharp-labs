using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab05
{
    class Program
    {

        private class Place : Restourant
        {
            public string Name { set; get; }
            public int Seats { set; get; }
            public int Hours { set; get; }


            public Place(string name, int seats, int hours) : base(name, seats)
            {
                Hours = hours;
            }

            public override void Print()
            {
                Console.WriteLine($"name - {Name} | seats - {Seats} | hours - {Hours}");
            }

        }


        abstract class Restourant
        {

            public string Name { set; get; }
            public int Seats { set; get; }
            protected Restourant(string name, int seats)
            {
                Seats = seats;
                Name = name;
            }

            public virtual void Print()
            {
                Console.WriteLine($"name - {Name} | seats - {Seats}");
            }
        }


        private sealed partial class Bar
        {
            public string Name { get; set; }
            public int Seats { get; set; }
        }

        private partial class Bar
        {
            public override string ToString()
            {
                return $"name - {Name} | seats - {Seats}";
            }
        }



        private static void RenameBuilding(object obj)
        {
            var building = obj as Building;
            if (building != null)
                building.Name = string.Empty;
        }

        private static void PrintArr(Building republic)
        {
            republic.Print();
        }


        private class Building
        {
            public Building(string name, double area, double population)
            {
                Name = name;
                Area = area;
                Population = population;
            }

            public string Name { get; set; }
            public double Area { get; set; }
            public double Population { get; set; }

            public void Print()
            {
                Console.WriteLine($"name - {Name} | area - {Area} | population - {Population}");
            }
        }

        private class Cinema : Building
        {

            public Cinema(string name, double area, double population) : base(name, area, population)
            {
            }

            public new void Print()
            {
                Console.WriteLine($"name - {Name} | area - {Area} | population - {Population}");
            }
        }

        private class House : Building
        {

            public House(string name, double area, double population) : base(name, area, population)
            {
            }

            public new void Print()
            {
                Console.WriteLine($"name - {Name} | area - {Area} | population - {Population}");
            }
        }

        static void Main(string[] args)
        {
            Restourant restourant = new Place("Rest", 8, 50);
            restourant.Print();
            Place place = (Place)restourant;
            place.Print();


            Bar bar = new Bar();
            bar.Name = "BArrrrr";
            bar.Seats = 999;
            Console.WriteLine(bar);

            string str1 = new string('1', 10);
            string str2 = new string("54325234536".ToCharArray(), 2, 3);

            Console.WriteLine(str2.Length);
            Console.WriteLine(str2.Insert(2, "END"));
            Console.WriteLine(str2.Replace("5", "[five]"));
            Console.WriteLine(str2);
            str2 = "6457367346747654767465465";
            Console.WriteLine(str2.Substring(1, 4));
            foreach (var item in str2.Split('6')) Console.WriteLine($"str: {item}");

            string str3 = "6847";
            string str4 = "6847";
            string str5 = "34567";
            Console.WriteLine(str3.Equals(str5));
            Console.WriteLine(string.Equals(str3, str5));
            Console.WriteLine(str3.Equals(str4));
            Console.WriteLine(string.Equals(str3, str4));

            string str6 = "7644428767265456";
            string str7 = str6;
            string str8 = str6.Replace("2", "0000000000");
            Console.WriteLine(string.IsInterned(str7));
            Console.WriteLine(string.IsInterned(str8));
            string.Intern(str8);
            Console.WriteLine(string.IsInterned(str8));


            Building bld = new Building("buiding", double.Epsilon, double.PositiveInfinity);
            Cinema cnm = new Cinema("cinema", double.NegativeInfinity, double.NaN);
            RenameBuilding(bld);
            RenameBuilding(cnm);

            var buildings = new[]
            {
                new Building("buiding", double.Epsilon, double.PositiveInfinity),
                new Cinema ("cinema", double.NegativeInfinity, double.NaN),
                new House("house", double.PositiveInfinity, double.Epsilon)
            };

            foreach (var item in buildings) PrintArr(item);


            Console.Read();
        }
    }
}
