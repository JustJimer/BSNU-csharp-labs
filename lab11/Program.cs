using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11
{

    class SteamBoat : IComparable
    {
        public string Name { get; set; }
        public float Weight { get; set; }
        public int AssembleYear { get; set; }
        public bool IsActive { get; set; }

        public int CompareTo(object obj)
        {
            SteamBoat sb = (SteamBoat)obj;
            return Name.CompareTo(sb.Name);
        }

        public override bool Equals(object obj)
        {
            SteamBoat sb = (SteamBoat)obj;
            return Name == sb.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return $"name - {Name}\tweight - {Weight}\tassemble year - {AssembleYear}\tis active - {IsActive}";
        }
    }





    public class Country : IComparable<Country>
    {
        public string Name { get; set; }
        public int Population { get; set; }
        public float Area { get; set; }

        public int CompareTo(Country other)
        {
            return Name.CompareTo(other.Name);
        }

        public override string ToString()
        {
            return $"name - {Name}\tpopulation - {Population}\tarea - {Area}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7 };
            var list1 = new ArrayList();

            list1.Add("Hello");
            list1.Add(100500);
            list1.Add(false);
            list1.Add(arr);
            list1.Add(new SteamBoat { AssembleYear = 1998, Name = "Lodka", Weight = 5467.3f, IsActive = true });
            list1.Add("World!");
            list1.Add(100500);
            list1.Add(new SteamBoat { AssembleYear = 2018, Name = "New Lodka", Weight = 67981.1f, IsActive = true });
            list1.Add(new SteamBoat { AssembleYear = 1645, Name = "Old Lodka", Weight = 666.7f, IsActive = false });

            foreach (var item in list1)
                Console.WriteLine(item);

            list1.Reverse();
            Console.WriteLine("\nrewerse");

            foreach (var item in list1)
                Console.WriteLine(item);

            list1.Remove(100500);
            Console.WriteLine("\nremove 100500");

            foreach (var item in list1)
                Console.WriteLine(item);

            list1.Clear();
            list1.Add(new SteamBoat { AssembleYear = 1998, Name = "x_Lodka", Weight = 5467.3f, IsActive = true });
            list1.Add(new SteamBoat { AssembleYear = 2018, Name = "a_New Lodka", Weight = 67981.1f, IsActive = true });
            list1.Add(new SteamBoat { AssembleYear = 1645, Name = "z_Old Lodka", Weight = 666.7f, IsActive = false });
            Console.WriteLine("\nbefore sort");

            foreach (var item in list1)
                Console.WriteLine(item);

            list1.Sort();
            Console.WriteLine("\nafter sort");
            foreach (var item in list1)
                Console.WriteLine(item);

            float sum = 0;
            foreach (SteamBoat item in list1)
                sum += item.Weight;
            Console.WriteLine("\nweight sum - " + sum);

            Console.WriteLine("\n\n\n");


            List<Country> list2 = new List<Country>(20);
            list2.Add(new Country { Area = 345245.2f, Population = 56745, Name = "Sharpland" });
            list2.Add(new Country { Area = 6454324.6f, Population = 87324, Name = "Neverland" });
            list2.Add(new Country { Area = 893792.9f, Population = 12345678, Name = "Ukraine" });
            list2.Add(new Country { Area = 1231254.3f, Population = 45454545, Name = "Estonia" });

            list2.ForEach(x => Console.WriteLine(x));

            Console.Write("\nfind");
            Console.WriteLine(list2.Find(x => x.Name == "USA"));
            Console.WriteLine(list2.Find(y => y.Population < 100000));

            Console.WriteLine("\nsort");
            list2.Sort();
            list2.ForEach(x => Console.WriteLine(x));

            Console.WriteLine("\n\n\n");

            HashSet<SteamBoat> steamBoats = new HashSet<SteamBoat>();
            steamBoats.Add(new SteamBoat { AssembleYear = 1998, Name = "x_Lodka", Weight = 5467.3f, IsActive = true });
            steamBoats.Add(new SteamBoat { AssembleYear = 2018, Name = "a_New Lodka", Weight = 67981.1f, IsActive = true });
            steamBoats.Add(new SteamBoat { AssembleYear = 1645, Name = "z_Old Lodka", Weight = 666.7f, IsActive = false });
            steamBoats.Add(new SteamBoat { AssembleYear = 1646, Name = "z_Old Lodka", Weight = 222.7f, IsActive = true });

            foreach (var item in steamBoats)
                Console.WriteLine(item);

            Console.Read();
        }
    }
}
