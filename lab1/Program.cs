using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab01
{

    class Test
    {
        public int a;
    }

    class Program
    {
        static void Main(string[] args)
        {
            //task 1 and 2
            System.Byte by1 = 15;
            byte by2 = 16;

            Single fl1 = 12.7f;
            float fl2 = 11.5f;

            System.String str1 = "hello there";
            string str2 = "bye there";

            System.Boolean flag1 = true;
            bool flag2 = false;

            //task 3
            System.String.IsNullOrEmpty("test");
            string.IsNullOrEmpty("");

            //task 4
            int int_t4 = 10;
            float fl_t4;
            fl_t4 = int_t4;
            Console.WriteLine("fl_t4 = int_t4 = " + fl_t4);

            int_t4 = (int)fl_t4;
            Console.WriteLine("int_t4 = fl_t4 = " + fl_t4);



            //task 5
            byte by3 = 250, by4 = 111, by5;
            unchecked
            {                         //exception, if checked
                by5 = (byte)(by3 + by4);
            }

            //task 6
            int l = 3;
            int? n;
            // l = null; - error
            n = null;
            Console.WriteLine("l = " + l);

            l = n ?? 56;
            Console.WriteLine("l = " + l);

            //task 7
            var int_t7 = 456;
            var fl_t7 = 75.3f;
            Console.WriteLine("type of int_t7 = " + int_t7.GetType().ToString());
            Console.WriteLine("type of fl_t7 = " + fl_t7.GetType().ToString());

            //task 8
            int age = 18;
            string name = "Valerii";

            Console.WriteLine("name - " + name);
            Console.WriteLine("age - " + age);
            Console.WriteLine("input n or a to change name or age");

            string sel_str = Console.ReadLine();

            string str = "18";



            switch (sel_str)
            {
                case "n":
                    Console.WriteLine("Your current name - " + name);
                    Console.WriteLine("Enter your new name: ");
                    name = Console.ReadLine();
                    Console.WriteLine("Your name is " + name);
                    break;
                case "a":
                    Console.WriteLine("Your current age - " + age);
                    Console.WriteLine("Enter your new name: ");
                    str = Console.ReadLine();
                    age = int.Parse(str);
                    Console.WriteLine("Your age is " + age);
                    break;
                default: Console.WriteLine("Error, wrong letter"); break;
            }

            //task 9
            bool flag = Int32.TryParse(str, out age);
            if (flag)
            {
                Console.WriteLine($"Your doubled age = {age * 2}");
            }
            else
                Console.WriteLine("Error");

            Console.Read();
        }
    }
}
