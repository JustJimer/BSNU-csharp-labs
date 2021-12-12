using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab09
{
    class RootException : Exception
    {
        readonly double rootNumber;
        public RootException(string mess, double rootNumber) : base(mess)
        {
            this.rootNumber = rootNumber;
        }
        public string NegativeNumberRoot(double rootNumber)
        {
            if (rootNumber < 0)
            {
                return $"It is forbidden to find the root of a negative number!";
            }
            else
            {
                return "Error: The number under the root is positive!";
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int[] array1 = { 10, 20, 30, 40 };

            try
            {
                array1[3] = 44;
                foreach (int item in array1)
                {
                    Console.Write(item + "  ");
                }
                Console.WriteLine();
                array1[10] = 100;

                int zeroDivide = array1[0] / 0;
            }


            catch (IndexOutOfRangeException exOutOfRange)
            {
                Console.WriteLine(exOutOfRange.Message);
            }
            catch (Exception)
            {
                Console.WriteLine("System.Exception");
            }


            try
            {
                Console.WriteLine("try 1");
                try
                {
                    int division = array1[0] / 0;
                }
                catch (DivideByZeroException exZero)
                {
                    Console.WriteLine($"try 2 cannot be divided by 0! - {exZero.StackTrace}");
                    throw new DivideByZeroException("DivideByZeroException", exZero);
                }
                finally
                {
                    Console.WriteLine("Hello world {finally}");
                }
            }
            catch (DivideByZeroException exZero)
            {
                Console.WriteLine(exZero.InnerException);
            }
            catch
            {
                Console.WriteLine("deprecated catch without parameters");
            }
            finally
            {
                Console.WriteLine("finally2 in try1");
            }


            int i = 84;
            try
            {
                array1[i] = 48;
            }


            catch (IndexOutOfRangeException exIndex) when (i > 50)
            {
                Console.WriteLine($"i = {i}");
            }
            catch (IndexOutOfRangeException exIndex)
            {
                Console.WriteLine($"i = {i} \t {exIndex.Message}");
            }
            double number = -48;
            try
            {
                Math.Sqrt(number);
                throw new RootException("NegativeNumberRoot", number);
            }
            catch (RootException exRoot)
            {
                Console.WriteLine(exRoot.Message + exRoot.NegativeNumberRoot(number));
            }
            try
            {
                int[] values = null;
                for (int ind = 0; ind <= 5; ind++)
                {
                    values[ind] = ind * 2;
                }
            }
            catch (NullReferenceException exNullRef)
            {
                Console.WriteLine(exNullRef);
            }


            string[] s = null;
            try
            {
                string j = string.Join("   ", s);
            }
            catch (ArgumentNullException exArgNull)
            {
                Console.WriteLine(exArgNull);
            }


            try
            {
                object obj = "Hello world!";
                int num = (int)obj;
            }


            catch (InvalidCastException exInvalid)
            {
                Console.WriteLine(exInvalid);
            }

            try
            {
                array1[148] = 148;
            }
            finally
            {
                Console.WriteLine("Hello world {finally}");
            }

            Console.Read();
        }
    }
}