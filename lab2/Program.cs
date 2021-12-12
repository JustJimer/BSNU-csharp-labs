using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab02
{
    class Place
    {
        public float hours;
        public string name;
        public int seats;

        public Place(string name, float hours, int seats)
        {
            this.name = name;
            this.hours = hours;
            this.seats = seats;
        }

        public override string ToString()
        {
            return $"name - {name} | hours - {hours} | seats - {seats}";
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Place plc = (Place)obj;
                return (name == plc.name) && (seats == plc.seats) && (hours == plc.hours);
            }
        }
    }

    struct PlaceStruct
    {
        public float hours;
        public string name;
        public int seats;

        public PlaceStruct(string name, float hours, int seats)
        {
            this.name = name;
            this.hours = hours;
            this.seats = seats;
        }

        public override string ToString()
        {
            return $"name - {name} | hours - {hours} | seats - {seats}";
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            // 1
            int[] arr1 = new int[3];
            int[] arr2 = new[] { 1, 2, 3 };
            int multiply = 1;

            foreach (var item in arr2) multiply *= item;
            Console.WriteLine("[TASK 1 result]: " + multiply);

            // 2
            int[,] arr3 = new int[5, 4];
            int[,] arr4 = new[,] { { 6, 2, 1, 6 }, { 2, 7, 1, 8 }, { 1, 2, 3, 4 } };
            int sum1 = 0;
            for (var i = 0; i < arr4.GetLength(0); ++i)
                for (var j = 0; j < arr4.GetLength(1) - 1; j += 2)
                    sum1 += arr4[i, j + 1];

            Console.WriteLine("[TASK 2 result]: " + sum1);

            // 3
            int[][] arr5 = new int[2][];
            arr5[0] = new[] { 6, 7, 1, 4, 8, 3, 5, 1, 1, 4, 6, 8, 9, 3, 1, 4, 5, 7, 9, 0, 4, 2, 1, 2 };
            arr5[1] = new[] { 1, 2, 3, 4, 65, 7 };
            int sum2 = 0;

            foreach (var item in arr5)
                for (var i = 0; i < item.Length - 1; i += 2)
                    sum2 += item[i + 1];
            Console.WriteLine("[TASK 3 result]: " + sum2);

            // 4
            Console.Write("[TASK 4 input]: ");
            int searchValue = Convert.ToInt32(Console.ReadLine());
            int counter = 0;

            foreach (var item in arr2)
                if (item == searchValue)
                    counter++;

            foreach (var item in arr4)
                if (item == searchValue)
                    counter++;

            foreach (var item in arr5)
                foreach (var value in item)
                    if (value == searchValue)
                        counter++;

            Console.WriteLine("[TASK 4 result]: " + counter);

            // 5
            Place plc1 = new Place("Bar", 7.5f, 34);
            Place plc2 = new Place("Club", 12, 34);
            Console.WriteLine("[TASK 5] Is plc1 equals plc2? " + plc1.Equals(plc2));
            Console.WriteLine("[TASK 5] " + plc1);
            Console.WriteLine("[TASK 5] " + plc2);

            // 6
            PlaceStruct plcStruct1 = new PlaceStruct("Restouran", 4.5f, 18);
            PlaceStruct plcStruct2 = new PlaceStruct();
            Console.WriteLine("[TASK 6] Is plcStruct1 equals plcStruct2? " + plcStruct1.Equals(plcStruct2));
            Console.WriteLine("[TASK 6] " + plcStruct1);
            Console.WriteLine("[TASK 6] " + plcStruct2);

            Console.Read();
        }
    }
}
