using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab04
{
    static class Program
    {
        private class Place
        {
            public const string Type = "Bar";
            public readonly string Name;


            public static readonly int Task2c;
            static Place()
            {
                Task2c = 1;
            }

            public Place(string name, double hours, int seats)
            {
                Name = name;
                Hours = hours;
                Seats = seats;
                Names = new[] { "Beer Garden", "Stag Nite Bar", "New Jack Swing Bar", "The High Five Bar" };
            }

            public double Hours { get; set; }
            public int Seats { get; set; }
            private string[] Names { get; set; }


            public void SetNames(params string[] names)
            {
                Names = names;
            }

            public string GetNames(ref int index)
            {
                return Names[index];
            }

            public void GetHoursPerName(out double obj)
            {
                obj = Hours / Seats;
            }

            public void RebuildPlace(int seats, double hours)
            {
                Hours = hours;
                Seats = seats;
            }


            public bool IsNameInPlace(string name)
            {
                return Array.Exists(Names, s => s == name);
            }

            public void ChangeNameFromTo(int index, int length)
            {
                Array.Clear(Names, index, length);
            }

            public void SortNames()
            {
                Array.Sort(Names);
            }

            public override string ToString()
            {
                return $"name - {Name} | hours - {Hours} | seats - {Seats}";
            }
        }

        private static class PlaceStatic
        {
            public static void WipeHours(Place place)
            {
                place.Hours = 0;
            }

            public static void PlaceRenovation(int seats)
            {
                seats -= 10;
            }

            public static void ShowPlace(Place place, params Place[] places)
            {
                Console.WriteLine(place);
                foreach (var item in places) Console.WriteLine(item);
            }
        }

        public static void Main(string[] args)
        {
            // 1
            int SeatsPlc1 = 34;
            Place place = new Place("Beer Garden", 7.5, SeatsPlc1);
            Console.WriteLine(place);
            PlaceStatic.WipeHours(place);
            Console.WriteLine(place);
            Console.WriteLine(SeatsPlc1);
            PlaceStatic.PlaceRenovation(SeatsPlc1);
            Console.WriteLine(SeatsPlc1);

            int index = 1;
            Console.WriteLine(place.GetNames(ref index));
            place.GetHoursPerName(out double hoursPerName1);
            Console.WriteLine(hoursPerName1);
            double hoursPerName2;
            place.GetHoursPerName(out hoursPerName2);
            Console.WriteLine(hoursPerName2);

            Console.WriteLine(place.GetNames(ref index));
            place.SetNames("New Jack Swing Bar", "Beer Garden", "Stag Nite Bar");
            Console.WriteLine(place.GetNames(ref index));

            Console.WriteLine(place);
            place.RebuildPlace(hours: 5.7d, seats: 58);
            Console.WriteLine(place);

            Console.WriteLine(place);
            Console.WriteLine(place);

            PlaceStatic.ShowPlace(place, new Place("Restouran", 4, 20), new Place("Club", 10, 200));



            Console.WriteLine("\n\n\n\n\n");


            // 2
            Console.WriteLine(place.IsNameInPlace("Bar778"));
            Console.WriteLine(place);
            place.ChangeNameFromTo(1, 2);
            Console.WriteLine(place);
            place.SetNames("Beer Garden", "Stag Nite Bar", "New Jack Swing Bar");
            Console.WriteLine(place);
            place.SortNames();
            Console.WriteLine(place);

            Console.WriteLine(Place.Task2c);

            Console.Read();
        }
    }
}