using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab12
{
    delegate void Delegate(ref int x);
    delegate void DelegateWithoutParams();

    class Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public override string ToString()
        {
            return "x = " + X + "\t y =" + Y;
        }
    }


    class Program
    {
        public void Index(ref int x) => x *= 5;
        public void PrintHello() => Console.WriteLine("Hello");
        public void ReverseString(string str)
        {
            char[] ch = str.ToCharArray();
            Array.Reverse(ch);
            Console.WriteLine(ch);
        }
        static void Main(string[] args)
        {


            //1
            Console.WriteLine("\t[TASK 1]");
            Program program = new Program();
            int x = 5;
            Console.WriteLine($"x = {x}");
            Delegate delegate1 = program.Index;
            delegate1(ref x);
            Console.WriteLine($"x = {x}");

            //2
            Console.WriteLine("\n\n\t[TASK 2]");
            DelegateWithoutParams delegateWithoutParams = program.PrintHello;
            delegateWithoutParams();

            //3
            Console.WriteLine("\n\n\t[TASK 3]");
            Action<string> action1 = program.ReverseString;
            action1("Bye World");
            Action action2 = program.PrintHello;
            action2();

            //4.1
            Console.WriteLine("\n\n\t[TASK 4.1]");
            Action<string> action3 = (str) =>
            {
                char[] ch = str.ToCharArray();
                Array.Reverse(ch);
                Console.WriteLine(ch);
            };
            action3("Test Word");

            //4.2
            Console.WriteLine("\n\n\t[TASK 4.2]");
            List<Point> list = new List<Point>();
            list.Add(new Point(10, 123));
            list.Add(new Point(123, 456));
            Console.WriteLine("action ->");
            list.ForEach(item => Console.WriteLine(item));
            Console.WriteLine();
            Point[] pointsArr = { new Point ( 1243, 123 ),
                new Point ( 452, 67453 ),
                new Point ( 3412, 30 ) };
            Console.WriteLine("predicate ->");
            Point planet1 = Array.Find(pointsArr, point => point.Y == 123);
            if (planet1 != null)
                Console.WriteLine(planet1);
            else
                Console.WriteLine("No points with Y = 123");

            Console.Read();
        }
    }
}
