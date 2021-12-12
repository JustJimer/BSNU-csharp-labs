using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.IO;

namespace lab10
{
    class Sea : IDisposable
    {
        private bool dispVal1 = false;
        string Name { get; set; }

        public Sea(string name)
        {
            this.Name = name;
        }

        public void Print()
        {
            Console.WriteLine("name - " + Name);
        }

        public void Dispose()
        {
            Print();
            dispVal1 = true;
            Console.WriteLine("disposing of Sea class");
            GC.SuppressFinalize(this);
        }

        ~Sea()
        {
            if (dispVal1 == false)
                Dispose();
            Console.WriteLine("sea class destructor example");
        }
    }


    class SeaDispose : IDisposable
    {
        private bool dispVal2;
        string Name { get; set; }


        public SeaDispose(string name)
        {
            this.Name = name;
        }

        public void Print()
        {
            Console.WriteLine("name - " + Name);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (dispVal2 == false)
            {
                if (disposing)
                {
                    Console.WriteLine("disposing of managed objects");
                }
                Console.WriteLine("disposing of unmanaged objects");
                dispVal2 = true;
            }
        }

        public void Dispose()
        {
            Print();
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        ~SeaDispose()
        {
            Print();
            Console.WriteLine("finalize of SeaDispose class");
            Dispose(disposing: false);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            Sea sea1 = new Sea("Black Sea (1)");
            sea1 = null;
            GC.Collect(0, GCCollectionMode.Optimized);

            Sea sea2 = new Sea("Red Sea(2)");
            sea2.Dispose();

            FileStream file = new FileStream(Path.Combine(docPath, "LR_10_FILE.txt"), FileMode.Open);

            using (StreamReader strRead = new StreamReader(file))
                Console.WriteLine(strRead.ReadToEnd());


            using (SeaDispose seaDisp1 = new SeaDispose("sea Dispose #1")) { }

            SeaDispose seaDisp2 = new SeaDispose("sea Dispose #2");
            seaDisp2 = null;
            GC.Collect(2, GCCollectionMode.Forced);

            Console.Read();
        }
    }
}
