using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab08
{

    interface IPerson
    {
        int Age { get; set; }
        int Expierence { get; set; }
        string Name { get; set; }

        int YearsToPromotion();
    }

    class Worker : IPerson, IComparable, IComparable<Worker>
    {
        int age, expierence;
        string name;

        public Worker(int age, int expierence, string name)
        {
            this.age = age; this.expierence = expierence; this.name = name;
        }

        public int Age { get => age; set => age = value; }
        public int Expierence { get => expierence; set => expierence = value; }
        public string Name { get => name; set => name = value; }

        public int YearsToPromotion()
        {
            if (age > 20)
                return Expierence / 10;
            else
                return 5;
        }

        public int CompareTo(object obj)
        {
            Worker worker = (Worker)obj;
            return name.CompareTo(worker.name);
        }



        public int CompareTo(Worker worker)
        {
            return name.CompareTo(worker.name);
        }

        public override string ToString()
        {
            return "age - " + age + " \texpierence - " + expierence + " \tname - " + name;
        }
    }

    class Engineer : IPerson
    {
        int age, expierence;
        string name;

        public Engineer(int age, int expierence, string name)
        {
            this.age = age; this.expierence = expierence; this.name = name;
        }

        public int Age { get => age; set => age = value; }
        public int Expierence { get => expierence; set => expierence = value; }
        public string Name { get => name; set => name = value; }

        public int YearsToPromotion()
        {
            if (age > 30)
                return Expierence / 15;
            else
                return 3;
        }
    }

    class WorldRegion
    {
        Country[] countries =
        {
            new Country("Ukraine", 40, 100),
            new Country("Poland", 30, 70),
            new Country("Germany", 140, 85)
        };
    }



    class Country
    {
        public Country(string name, int population, double area)
        {
            this.Name = name; this.Population = population; this.Area = area;
        }

        public string Name { get; set; }

        public int Population { get; set; }

        public double Area { get; set; }
    }

    class Program
    {
        public static void DoubleAge(IPerson person)
        {
            Console.WriteLine("Doubled age - " + person.Age * 2);
        }

        static void Main(string[] args)
        {
            IPerson engeneer1 = new Engineer(32, 12, "Ivan");
            DoubleAge(engeneer1);

            Worker[] workers = {
                new Worker(32, 10, "Oleg"),
                new Worker(24, 4, "Vlad"),
                new Worker(56, 24, "Oles"),
                new Worker(31, 6, "Taras"),
                new Worker(17, 1, "Petro")
            };

            Array.Sort(workers);
            foreach (Worker item in workers)
                Console.WriteLine(item);

            Console.WriteLine("\n");

            Array.Sort(workers);
            foreach (Worker item in workers)
                Console.WriteLine(item);

            Console.Read();
        }
    }
}