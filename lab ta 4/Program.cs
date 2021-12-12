using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
namespace TA_4
{

    public static class SortingAlgorithms
    {

        public static ulong compareCount = 0;
        public static ulong swapCount = 0;


        public static void InsertSortAlphabetical(IComparable[] array)
        {
            int i, j;
            for (i = 1; i < array.Length; i++)
            {
                IComparable value = array[i];
                j = i - 1;
                while ((j >= 0) && (array[j].CompareTo(value) > 0))
                {
                    ++compareCount;
                    ++swapCount;
                    array[j + 1] = array[j];
                    j--;
                }
                ++swapCount;
                array[j + 1] = value;
            }
        }

        public static void ShellSortAlphabetical(IComparable[] array)
        {
            int i, j, pos;
            pos = 3;
            while (pos > 0)
            {
                for (i = 0; i < array.Length; i++)
                {
                    j = i;
                    IComparable value = array[i];

                    while ((j >= pos) && (array[j - pos].CompareTo(value) > 0))
                    {
                        ++compareCount;
                        ++swapCount;
                        array[j] = array[j - pos];
                        j = j - pos;
                    }
                    ++swapCount;
                    array[j] = value;
                }
                if (pos / 2 != 0)
                    pos = pos / 2;
                else if (pos == 1)
                    pos = 0;
                else
                    pos = 1;
            }
        }

        static public void MainMergeAlphabetical(IComparable[] values, int left, int mid, int right, int n)
        {
            IComparable[] temp = new IComparable[n];
            int i, eol, num, pos;

            eol = (mid - 1);
            pos = left;
            num = (right - left + 1);

            while ((left <= eol) && (mid <= right))
            {
                ++compareCount;
                ++compareCount;
                ++swapCount;
                if (values[left].CompareTo(values[mid]) < 0)
                    temp[pos++] = values[left++];
                else
                    temp[pos++] = values[mid++];
            }

            while (left <= eol)
            {
                ++compareCount;
                ++swapCount;
                temp[pos++] = values[left++];
            }



            while (mid <= right)
            {
                ++compareCount;
                ++swapCount;
                temp[pos++] = values[mid++];
            }


            for (i = 0; i < num; i++)
            {
                ++swapCount;
                values[right] = temp[right];
                right--;
            }
        }

        static public void MergeSortAlphabetical(IComparable[] values, int left, int right, int n)
        {
            int mid;
            ++compareCount;
            if (right > left)
            {
                mid = (right + left) / 2;
                MergeSortAlphabetical(values, left, mid, n);
                MergeSortAlphabetical(values, (mid + 1), right, n);

                MainMergeAlphabetical(values, left, (mid + 1), right, n);
            }
        }


        public static void InsertSortQuantitative(string[] array)
        {
            int i, j;
            for (i = 1; i < array.Length; i++)
            {
                string value = array[i];
                j = i - 1;
                while ((j >= 0) && (array[j].Length > value.Length))
                {
                    ++compareCount;
                    ++swapCount;
                    array[j + 1] = array[j];
                    j--;
                }


                ++swapCount;
                array[j + 1] = value;
            }
        }

        public static void ShellSortQuantitative(string[] array)
        {
            int i, j, pos;
            pos = 3;
            while (pos > 0)
            {
                for (i = 0; i < array.Length; i++)
                {
                    j = i;
                    string value = array[i];
                    while ((j >= pos) && (array[j - pos].Length > value.Length))
                    {
                        ++compareCount;
                        ++swapCount;
                        array[j] = array[j - pos];
                        j = j - pos;
                    }
                    ++swapCount;
                    array[j] = value;
                }
                if (pos / 2 != 0)
                    pos = pos / 2;
                else if (pos == 1)
                    pos = 0;
                else
                    pos = 1;
            }
        }

        static public void MainMergeQuantitative(string[] values, int left, int mid, int right, int n)
        {
            string[] temp = new string[n];
            int i, eol, num, pos;

            eol = (mid - 1);
            pos = left;
            num = (right - left + 1);

            while ((left <= eol) && (mid <= right))
            {
                ++compareCount;
                ++compareCount;
                ++swapCount;


                if (values[left].Length < values[mid].Length)
                    temp[pos++] = values[left++];
                else
                    temp[pos++] = values[mid++];
            }

            while (left <= eol)
            {
                ++compareCount;
                ++swapCount;
                temp[pos++] = values[left++];
            }

            while (mid <= right)
            {
                ++compareCount;
                ++swapCount;
                temp[pos++] = values[mid++];
            }

            for (i = 0; i < num; i++)
            {
                ++swapCount;
                values[right] = temp[right];
                right--;
            }
        }

        static public void MergeSortQuantitative(string[] values, int left, int right, int n)
        {
            int mid;
            ++compareCount;
            if (right > left)
            {
                mid = (right + left) / 2;
                MergeSortQuantitative(values, left, mid, n);
                MergeSortQuantitative(values, (mid + 1), right, n);

                MainMergeQuantitative(values, left, (mid + 1), right, n);
            }
        }
    }



    class Program
    {

        private static string docPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        private static Random random = new Random();

        public static void StringGen(int n)
        {
            int randomStrLength = 0;
            File.WriteAllText(Path.Combine(docPath, "ta4Source.txt"), "");
            for (int i = 0; i < n; i++)
            {
                randomStrLength = random.Next(2, 250);
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789 -";
                string RandomStr = new string(Enumerable.Repeat(chars, randomStrLength).Select(s => s[random.Next(s.Length)]).ToArray());
                File.AppendAllText(Path.Combine(docPath, "ta4Source.txt"), RandomStr + "\n");
            }
        }

        public static void ResultFileOutput(string[] res)
        {
            File.WriteAllText(Path.Combine(docPath, "ta4Result.txt"), "");
            for (int i = 0; i < res.Length; i++)
            {
                File.AppendAllText(Path.Combine(docPath, "ta4Result.txt"), res[i] + "\n");
            }
        }

        static void Main(string[] args)
        {

            Stopwatch stopWatch = new Stopwatch();
            string sourceFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "ta4Source.txt");
            int n = 0;
            File.AppendAllText(sourceFilePath, "");

            if (PromptConfirmation("Create a new sequence of lines?"))
            {
                Console.WriteLine("Enter number of lines: ");
                n = Int32.Parse(Console.ReadLine());
                StringGen(n);
                Console.WriteLine($"A new sequence of {n} lines has been created.");
            }

            string[] sourceFile = File.ReadAllLines(sourceFilePath);


            if (PromptConfirmation("Sort alphabetically?"))
            {
                if (PromptConfirmation("Use insertion sort?"))
                {
                    stopWatch.Start();
                    SortingAlgorithms.InsertSortAlphabetical(sourceFile);
                    stopWatch.Stop();
                    Console.WriteLine("sort complete, creating result file...");
                    ResultFileOutput(sourceFile);
                    Console.WriteLine($"array of {n} lines was sorted successfully");
                    Console.WriteLine("alphabetical insertion sort time " + stopWatch.Elapsed.TotalMilliseconds);
                }
                else if (PromptConfirmation("Use shell sort?"))
                {
                    stopWatch.Start();
                    SortingAlgorithms.ShellSortAlphabetical(sourceFile);
                    stopWatch.Stop();
                    Console.WriteLine("sort complete, creating result file...");
                    ResultFileOutput(sourceFile);
                    Console.WriteLine($"array of {n} lines was sorted successfully");
                    Console.WriteLine("alphabetical shell sort time " + stopWatch.Elapsed.TotalMilliseconds);
                }
                else if (PromptConfirmation("Use merge sort?"))
                {
                    stopWatch.Start();
                    SortingAlgorithms.MergeSortAlphabetical(sourceFile, 0, n - 1, n);
                    stopWatch.Stop();
                    Console.WriteLine("sort complete, creating result file...");
                    ResultFileOutput(sourceFile);
                    Console.WriteLine($"array of {n} lines was sorted successfully");
                    Console.WriteLine("merge shell sort time " + stopWatch.Elapsed.TotalMilliseconds);
                }
            }
            else if (PromptConfirmation("Sort by number of characters?"))
            {
                if (PromptConfirmation("Use insertion sort?"))
                {
                    stopWatch.Start();
                    SortingAlgorithms.InsertSortQuantitative(sourceFile);
                    stopWatch.Stop();
                    Console.WriteLine("sort complete, creating result file...");
                    ResultFileOutput(sourceFile);
                    Console.WriteLine($"array of {n} lines was sorted successfully");
                    Console.WriteLine("quantitative insertion sort time " + stopWatch.Elapsed.TotalMilliseconds);
                }
                else if (PromptConfirmation("Use shell sort?"))
                {
                    stopWatch.Start();
                    SortingAlgorithms.ShellSortQuantitative(sourceFile);
                    stopWatch.Stop();
                    Console.WriteLine("sort complete, creating result file...");
                    ResultFileOutput(sourceFile);
                    Console.WriteLine($"array of {n} lines was sorted successfully");
                    Console.WriteLine("quantitative shell sort time " + stopWatch.Elapsed.TotalMilliseconds);
                }
                else if (PromptConfirmation("Use merge sort?"))
                {
                    stopWatch.Start();
                    SortingAlgorithms.MergeSortQuantitative(sourceFile, 0, n - 1, n);
                    stopWatch.Stop();
                    Console.WriteLine("sort complete, creating result file...");
                    ResultFileOutput(sourceFile);
                    Console.WriteLine($"array of {n} lines was sorted successfully");
                    Console.WriteLine("quantitative merge sort time " + stopWatch.Elapsed.TotalMilliseconds);
                }
            }
            Console.WriteLine("Swaps " + SortingAlgorithms.swapCount);
            Console.WriteLine("Compares " + SortingAlgorithms.compareCount);

            bool PromptConfirmation(string confirmText)
            {
                Console.Write(confirmText + " [y/n] : ");
                ConsoleKey response = Console.ReadKey(false).Key;
                Console.WriteLine();
                return (response == ConsoleKey.Y);
            }
            Console.Read();
        }
    }
}
